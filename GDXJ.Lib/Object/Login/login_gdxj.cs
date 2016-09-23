using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using QQLib.Http;
using QQLib.Encoded;
using System;
using System.Text;
using System.Security.Cryptography;
using GDXJ.Lib.Object.User;
using GDXJ.Lib.Lib;
using System.Windows.Media;

namespace GDXJ.Lib.Object.Login
{
    public class Login_Gdxj
    {
        GDXJEvens LoginEvens;
        int flag = 0;

        public string Username { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
        public string LoginInfo { get; set; }
        public AccountObj SelectAccount { get; set; }

        public ImageSource VerificationCodeImage { get; private set; }

        private MyCookie myCookie;
        private GdxjUser gdxjUser;

        public bool GetKeyCompleted { get; set; }
        public bool LoginCompleted { get; set; }

        string usernameKey1 = "";
        string usernameKey2 = "";
        string usernameKey3 = "";
        string passwordKey = "";



        public Login_Gdxj(GdxjUser gdxjUser, MyCookie cookie)
        {
            try
            {
                this.myCookie = cookie;
                this.gdxjUser = gdxjUser;
                this.LoginCompleted = false;
                GetKeyCompleted = false;
                GetKey();
                VerificationCodeImageRefresh();
            }
            catch
            {
                flag = -1;
            } 
        }

        public void Subscribe(GDXJEvens.GDXJEventHandler handler)
        {
            if (LoginEvens != null)
                LoginEvens.Subscribe(handler);
        }
        //取消订阅事件
        public void UnSubscribe(GDXJEvens.GDXJEventHandler handler)
        {
            if (LoginEvens != null)
                LoginEvens.UnSubscribe(handler);
        }

        /// <summary>
        /// 获取登录所需的Key值
        /// </summary>
        void GetKey()
        {
            try
            {
                string html = RequestHelper.SendDataByGET(setting.url.indexUrl, "", ref myCookie.cookie);
                var r = new Regex(@"var.=?salt.+?""(?<pwKey>.+?)"".+?_username.value,'(?<key1>.+?)','(?<key2>.+?)','(?<key3>.+?)'", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var matchCollection = r.Matches(html);
                if (matchCollection.Count > 0)
                {
                    passwordKey = matchCollection[0].Groups["pwKey"].Value;
                    usernameKey1 = matchCollection[0].Groups["key1"].Value;
                    usernameKey2 = matchCollection[0].Groups["key2"].Value;
                    usernameKey3 = matchCollection[0].Groups["key3"].Value;
                    GetKeyCompleted = true;
                }
            }
            catch
            {
                throw (new Exception("Get key error!"));
            }
        }

        ImageSource GetVerificationCodeImage()
        {
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            try
            {
                image.BeginInit();
                image.StreamSource = RequestHelper.GetStream(setting.url.verificationCodeImageUrl, ref myCookie.cookie);
                image.EndInit();
            }
            catch
            {
                throw (new Exception("Get VerificationCodeImage error!"));
            }
            return image;
        }

        public bool Login()
        {
            if (flag == -1) LoginEvens.RaiseEvent(-1, "初始化失败");

            bool result = false;
            try
            {
                string html = RequestHelper.GetXmlDataByPost(setting.url.loginCheckUrl, LoginPostString(), ref myCookie.cookie, setting.url.loginCheckUrl);

                var r = new Regex(@"""(?<url>http:.+?)""", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var matchCollection = r.Matches(html);
                string url;
                if (matchCollection.Count > 0)
                {
                    url = matchCollection[0].Groups["url"].Value;
                    html = RequestHelper.SendDataByGET(url, LoginPostString(), ref myCookie.cookie, setting.url.loginCheckUrl);
                    r = new Regex("userId:'(?<userId>.+?)',userName:'(?<userName>.+?)',userType:'(?<userType>.+?)',employeeId:'(?<employeeId>.+?)',regionCode:'(?<regionCode>.+?)',regionName:'(?<regionName>.+?)',organ:{organCode:'(?<organCode>.+?)',organName:'(?<organName>.+?)',organType:'(?<organType>.+?)',parentCode:'(?<parentCode>.+?)',level:(?<level>.+?)},zxxsUsersExt:{userAlias:'(?<userAlias>.+?)',userId:'(?<userAliasId>.+?)',userAliasName:'(?<userAliasName>.+?)',createTime:'(?<createTime>.+?)',skinPath:'(?<skinPath>.+?)'}}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    matchCollection = r.Matches(html);

                    if (matchCollection.Count > 0)
                    {
                        gdxjUser.employeeId = matchCollection[0].Groups["employeeId"].Value;
                        gdxjUser.regionCode = matchCollection[0].Groups["regionCode"].Value;
                        gdxjUser.regionName = matchCollection[0].Groups["regionName"].Value;
                        gdxjUser.userId = matchCollection[0].Groups["userId"].Value;
                        gdxjUser.userName = matchCollection[0].Groups["userName"].Value;
                        gdxjUser.userType = matchCollection[0].Groups["userType"].Value;

                        gdxjUser.organ = new User.Organ()
                        {
                            level = matchCollection[0].Groups["level"].Value,
                            organCode = matchCollection[0].Groups["organCode"].Value,
                            organName = matchCollection[0].Groups["organName"].Value,
                            organType = matchCollection[0].Groups["organType"].Value,
                            parentCode = matchCollection[0].Groups["parentCode"].Value
                        };
                        gdxjUser.zxxsUsersExt = new User.ZxxsUsersExt()
                        {
                            createTime = matchCollection[0].Groups["createTime"].Value,
                            skinPath = matchCollection[0].Groups["skinPath"].Value,
                            userAlias = matchCollection[0].Groups["userAlias"].Value,
                            userAliasName = matchCollection[0].Groups["userAliasName"].Value,
                            userId = matchCollection[0].Groups["userAliasId"].Value
                        };
                        result = true;
                        this.LoginCompleted = true;
                        LoginEvens.RaiseEvent(0, "");
                    }
                    else
                    {
                        this.LoginCompleted = false;
                        r = new Regex("UNSELECTABLE.+?>(?<info>.+?)<", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        matchCollection = r.Matches(html);
                        if (matchCollection.Count > 0)
                        {
                            LoginInfo= matchCollection[0].Groups["info"].Value;
                            if (flag == -1) LoginEvens.RaiseEvent(-1, LoginInfo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LoginEvens.RaiseEvent(-1, e.Message);
            }
            return result;
        }

        private string LoginPostString()
        {
            string postData = @"_j_username=&j_username={0}&j_password={1}&rdmCode={2}";
            MD5 md5 = new MD5CryptoServiceProvider();
            //string nameStr = Des.strEnc(Username, usernameKey1, usernameKey2, usernameKey3);
            //string nameStr = Des.strEnc(SelectAccount.Account, usernameKey1, usernameKey2, usernameKey3);
            return string.Format(postData, SelectAccount.LoginString,//"07EE60FFB05AF83DDD4EF2D1959C6FDA",
                (BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(Password + "{" + passwordKey + "}"))).Replace("-", "")).ToLower(),
                VerificationCode);
        }

        public ImageSource VerificationCodeImageRefresh()
        {
            VerificationCodeImage = GetVerificationCodeImage();
            return VerificationCodeImage;
        }

        public void Logout()
        {
            string html = RequestHelper.SendDataByGET(setting.url.logoutUrl, "", ref myCookie.cookie, setting.url.loginCheckUrl);
        }
    }
}
