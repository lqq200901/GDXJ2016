namespace JumpKick.HttpLib
{
    using JumpKick.HttpLib.Provider;
    using System;
    using System.IO;
    using System.Net;
    using JumpKick.HttpLib.Streams;
    using System.Text;

    public class Request
    {
        protected string url;
        protected HttpVerb method = HttpVerb.Get;
        protected HeaderProvider headers;
        protected AuthenticationProvider auth;
        protected BodyProvider body;

        protected ActionProvider action;

        public Request()
        {
            
        }


        public String Url
        {
            set
            {
                this.url = value;
            }
            get
            {
                return this.url;
            }
        }

        public HttpVerb Method
        {
            set
            {
                this.method = value;
            }

            get
            {
                return this.method;
            }
        }

        public HeaderProvider Headers
        {
            set
            {
                this.headers = value;
            }
            get
            {
                return this.headers;
            }
        }

        public AuthenticationProvider Auth
        {
            set
            {
                this.auth = value;
            }
            get
            {
                return this.auth;
            }
        }

        public ActionProvider Action
        {
            set
            {
                this.action = value;
            }
            get
            {
                return this.action;
            }
        }

        public BodyProvider Body
        {
            set
            {
                this.body = value;
            }
            get
            {
                return this.body;
            }
        }

        public RequestData RealTimeGo()
        {
            return MakeRealTimeRequest(); ;
        }

        private RequestData MakeRealTimeRequest()
        {
            Stream stream=null;
            try
            {
                HttpWebRequest request = CreateNewRequest();

                if (method == HttpVerb.Get || method == HttpVerb.Head)
                {
                    stream = (request.GetResponse()).GetResponseStream();
                }
                else
                {
                    if (request.ContentType == null) request.ContentType = body.GetContentType();

                    using (Stream myRequestStream = request.GetRequestStream())
                    {
                        var contentLength = body.GetBody().Length;
                        byte[] bodyBytes = new byte[contentLength];
                        body.GetBody().Read(bodyBytes, 0, bodyBytes.Length);
                        body.GetBody().Seek(0, SeekOrigin.Begin);

                        int maxLength = 500;
                        int ec;
                        for (int i = 0; i < contentLength; i += maxLength)
                        {
                            if (i + maxLength < contentLength) ec = 500; else ec = (int)contentLength - i;
                            myRequestStream.Write(bodyBytes, i, ec);
                        }
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        stream = response.GetResponseStream();

                        //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        //{
                        //    stream = response.GetResponseStream();
                        //}
                    }
                }
            }
            catch (WebException webEx)
            {
                if (action.Fail != null)
                    action.Fail(webEx);
                else
                    throw webEx;
            }
            return new RequestData(stream);
        }

        public void Go()
        {
            MakeRequest();
        }


        protected virtual HttpWebRequest GetWebRequest(string url)
        {
            return (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        }

        protected void MakeRequest()
        {
            try
            {
                HttpWebRequest request = CreateNewRequest();

                if (method == HttpVerb.Get || method == HttpVerb.Head) 
                {
                    ExecuteRequestWithoutBody(request);
                } 
                else 
                {
                    if(request.ContentType==null) request.ContentType = body.GetContentType();
                    ExecuteRequestWithBody(request);
                }
            }
            catch (WebException webEx)
            {
                action.Fail(webEx);
            }
        }

        private HttpWebRequest CreateNewRequest()
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url is empty");
            }
            /*
             * Create new Request
             */
            HttpWebRequest request = this.GetWebRequest(url);
            request.CookieContainer = Cookies.Container;
            request.Method = method.ToString().ToUpper();

            if (Headers != null)
            {
                var headersArray = Headers.GetHeaders();
                if (headersArray != null)
                {
                    var headersList = new System.Collections.Generic.List<Header>(headersArray);
                    foreach (var h in headersList)
                    {
                        switch (h.Name.ToLower())
                        {
                            case "referer":
                                request.Referer = h.Value;
                                break;
                            case "content-type":
                                request.ContentType = h.Value;
                                break;
                            default:
                                request.Headers.Set(h.Name, h.Value);
                                break;
                        }
                    }
                }
            }
            return request;
        }

        protected virtual void ExecuteRequestWithoutBody(HttpWebRequest request)
        {
            request.BeginGetResponse(ProcessCallback(action.Success, action.Fail), request);
        }

        protected virtual void ExecuteRequestWithBody(HttpWebRequest request)
        {
            request.BeginGetRequestStream(new AsyncCallback((IAsyncResult callbackResult) =>
            {
                HttpWebRequest tmprequest = (HttpWebRequest)callbackResult.AsyncState;
                
      
                ProgressCallbackHelper copy = body.GetBody().CopyToProgress(tmprequest.EndGetRequestStream(callbackResult),null);
                copy.ProgressChanged += (bytesSent, totalBytes) => { body.OnProgressChange(bytesSent, totalBytes); };
                copy.Completed += (totalBytes) => { body.OnCompleted(totalBytes); };
                copy.Go();

                // Start the asynchronous operation to get the response
                tmprequest.BeginGetResponse(ProcessCallback(action.Success, action.Fail), tmprequest);


            }), request);
        }


        protected AsyncCallback ProcessCallback(Action<WebHeaderCollection, Stream> success, Action<WebException> fail)
        {
            return new AsyncCallback((callbackResult) =>
            {
                HttpWebRequest webRequest = (HttpWebRequest)callbackResult.AsyncState;

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)webRequest.EndGetResponse(callbackResult))
                    {
                       // if (response.ContentLength > 0) { response.Headers.Add("Content-Length", response.ContentLength.ToString()); }
                        if (success!=null )
                            success(response.Headers, response.GetResponseStream());
                    }

                }
                catch (WebException webEx)
                {
                    fail(webEx);
                }
            });
        }
    }

   
}
