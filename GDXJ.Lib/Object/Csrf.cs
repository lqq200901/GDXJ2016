using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using QQLib.Http;
using System.Text.RegularExpressions;
using QQLib.Decoded;
using JumpKick.HttpLib;

namespace GDXJ.Lib.Object
{
    public class Csrf
    {
        private static string csrfToken;
        public static string GetCsrfToken()
        {
            try
            {
                if (csrfToken == string.Empty || csrfToken == null)
                {
                    var html = Http.Get(setting.url.mainRUrl).RealTimeGo().RequestString;
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
