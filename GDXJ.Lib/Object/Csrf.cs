using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using QQLib.Http;
using System.Text.RegularExpressions;
using QQLib.Decoded;

namespace GDXJ.Lib.Object
{
    public class Csrf
    {
        private static string csrfToken;
        public static string GetCsrfToken(ref CookieContainer cookie)
        {
            try
            {
                if (csrfToken == string.Empty || csrfToken == null)
                {
                    string html = RequestHelper.SendDataByGET(setting.url.mainRUrl, "", ref cookie);
                    var r = new Regex(@"eval\('(?<jsStr>.+?)'", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    var matchCollection = r.Matches(html);
                    if (matchCollection.Count > 0)
                    {
                        r = new Regex(@"(?<tokenStr>.{8}-.{4}-.{4}-.{4}-.{12})'", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        matchCollection = r.Matches( Eval.GetEvalString(matchCollection[0].Groups["jsStr"].Value));
                        if (matchCollection.Count > 0)
                        {
                            csrfToken = matchCollection[0].Groups["tokenStr"].Value;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            return csrfToken;
        }
    }
}
