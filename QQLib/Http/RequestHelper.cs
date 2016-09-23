using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace QQLib.Http
{
    public class RequestHelper
    {

        #region 同步通过POST方式发送数据

        /// <summary>
        /// 通过POST方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">Post数据</param>
        /// <param name="cookie">Cookie容器</param>
        /// <returns></returns>
        private static string SendDataByPost(string postDataStr,ref CookieContainer cookie, HttpWebRequest request,
            Encoding encoded)
        {
            if (encoded == null) encoded = Encoding.GetEncoding("UTF-8");
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            //ServicePointManager.Expect100Continue = false;
            request.Method = "POST";

            request.AllowWriteStreamBuffering = true;
            long contentLength = encoded.GetByteCount(postDataStr);
            request.ContentLength = contentLength;
            //request.AllowAutoRedirect = true;
            string retString = "";
            try
            {
                using (Stream myRequestStream = request.GetRequestStream())
                {
                    int maxLength = 500;
                    int ec;
                    for (int i = 0; i < contentLength; i += maxLength)
                    {
                        if (i + maxLength < contentLength) ec = 500; else ec = (int)contentLength - i;
                        myRequestStream.Write(encoded.GetBytes(postDataStr), i, ec);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream myResponseStream = response.GetResponseStream();
                        StreamReader myStreamReader = new StreamReader(myResponseStream, encoded);
                        retString = myStreamReader.ReadToEnd();
                        myStreamReader.Close();
                        myResponseStream.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw (e);
            }
            return retString;
        }

        #endregion

        public static string GetAppDataByPost(string Url, string postDataStr,ref CookieContainer cookie,
            Encoding encoded = null, string referer = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "application/x-www-form-urlencoded";
            if (referer != "")
                request.Referer = referer;
            return SendDataByPost(postDataStr,ref cookie, request, encoded);
        }

        public static string GetAttachByPost(string Url, string postDataStr,ref CookieContainer cookie, string fileName,
            Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Referer = Url;

            if (encoded == null) encoded = Encoding.GetEncoding("UTF-8");
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            ServicePointManager.Expect100Continue = false;
            request.Method = "POST";

            request.AllowWriteStreamBuffering = true;
            long contentLength = encoded.GetByteCount(postDataStr);
            request.ContentLength = contentLength;
            string retString = "";
            try
            {
                using (Stream myRequestStream = request.GetRequestStream())
                {
                    int maxLength = 500;
                    int ec;
                    for (int i = 0; i < contentLength; i += maxLength)
                    {
                        if (i + maxLength < contentLength) ec = 500; else ec = (int)contentLength - i;
                        myRequestStream.Write(encoded.GetBytes(postDataStr), i, ec);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream myResponseStream = response.GetResponseStream();
                        try
                        {
                            using (FileStream fs = new FileStream(fileName, FileMode.Create))
                            {
                                byte[] bytes = new byte[1024];
                                int len = 0;
                                try
                                {
                                    while ((len = myResponseStream.Read(bytes, 0, bytes.Length)) > 0)
                                    {
                                        fs.Write(bytes, 0, len);
                                    }
                                }
                                catch
                                {
                                    fs.Close();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            System.Windows.MessageBox.Show(e.Message, "操作提示", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        }
                        myResponseStream.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw (new Exception("Request error!"));
            }
            return retString;
        }

        public static string GetXmlDataByPost(string Url, string postDataStr,ref CookieContainer cookie, string referer = "",
            Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = @"application/x-www-form-urlencoded";
            request.Referer = referer == "" ? Url : referer;
            request.AllowAutoRedirect = false;
            return SendDataByPost(postDataStr,ref cookie, request, encoded);
        }

        public static string GetByPostJsonWithCsrf(string Url, string postDataStr, ref CookieContainer cookie,string csrf, string referer = "",
                    Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Accept = "*/*";
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.Headers.Add("Origin: http://gdxj.edugd.cn");
            request.Headers.Add("Accept-Encoding: gzip,deflate,sdch");
            request.Headers.Add("Accept-Language: zh-CN,zh;q=0.8");
            request.ContentType = @"application/json";
            request.Headers.Add("_ccrf.token", csrf);
            request.KeepAlive = true;
            request.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36 SE 2.X MetaSr 1.0";
            request.Referer = referer == "" ? Url : referer;
            request.AllowAutoRedirect = false;
            return SendDataByPost(postDataStr, ref cookie, request, encoded);
        }

        public static string GetByPostJson(string Url, string postDataStr,ref CookieContainer cookie, string referer = "",
                    Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Accept = "*/*";
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.Headers.Add("Origin: http://gdxj.edugd.cn");
            request.Headers.Add("Accept-Encoding: gzip,deflate,sdch");
            request.Headers.Add("Accept-Language: zh-CN,zh;q=0.8");
            request.ContentType = @"application/json";
            request.KeepAlive = true;
            request.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36 SE 2.X MetaSr 1.0";
            request.Referer = "http://gdxj.edugd.cn/jsp/mems/xsxxgl/xjqgl/xjqgl.jsp";// referer == "" ? Url : referer;
            request.AllowAutoRedirect = false;
            return SendDataByPost(postDataStr,ref cookie, request, encoded);
        }
        public static string GetDataByPostAndUnGzip(string url, string postDataStr,ref CookieContainer cookie,
            Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";

            if (encoded == null) encoded = Encoding.GetEncoding("UTF-8");
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }
            ServicePointManager.Expect100Continue = false;
            request.Method = "POST";
            request.AllowWriteStreamBuffering = true;
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr.ToCharArray());
            string retString = "";
            using (Stream myRequestStream = request.GetRequestStream())
            {
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.Default);
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();
                using (MemoryStream dms = new MemoryStream())
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream myResponseStream = response.GetResponseStream();
                        if (myResponseStream != null)
                        {
                            using (
                                System.IO.Compression.GZipStream gzip =
                                    new System.IO.Compression.GZipStream(myResponseStream,
                                        System.IO.Compression.CompressionMode.Decompress))
                            {
                                byte[] bytes = new byte[1024];
                                int len = 0;
                                //读取压缩流，同时会被解压
                                while ((len = gzip.Read(bytes, 0, bytes.Length)) > 0)
                                {
                                    dms.Write(bytes, 0, len);
                                }
                            }
                            myResponseStream.Close();
                        }
                    }
                    retString = Encoding.UTF8.GetString(dms.ToArray());
                }
            }
            return retString;
        }

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public static string SendDataByGET(string Url, string postDataStr,ref CookieContainer cookie, string referer = "", Encoding encoded = null)
        {
            return SendDataByGETS(Url, postDataStr,ref cookie, referer, encoded).ReadToEnd();
        }
        #endregion

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public static StreamReader SendDataByGETS(string Url, string postDataStr,ref CookieContainer cookie, string referer = "", Encoding encoded = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }
            request.Method = "GET";
            request.Referer = referer == "" ? Url : referer;
            //request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream(), encoded ?? Encoding.GetEncoding("UTF-8"));

            //using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
            //{
            //    return streamReader;
            //}
        }
        #endregion

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 获取Url指定地址的数据流
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static Stream GetStream(string Url,ref CookieContainer cookie, string refererStr = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.UserAgent = @"User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36 SE 2.X MetaSr 1.0";
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }
            request.Method = "GET";
            //request.Timeout = 5000;
            if (refererStr != null) request.Referer = refererStr;

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return response.GetResponseStream();
        }
        #endregion
    }
}
