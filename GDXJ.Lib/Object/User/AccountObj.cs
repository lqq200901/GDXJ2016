using QQLib.Encoded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.User
{
    public class AccountObj
    {
        public string Account { get; set; }
        public string LoginString
        {
            get
            {
                return Des.strEnc(Account, UsernameKey1, UsernameKey2, UsernameKey3);
            }
        }

        public string UsernameKey1 { get; set; }
        public string UsernameKey2 { get; set; }
        public string UsernameKey3 { get; set; }
        public string PasswordKey { get; set; }

        public AccountObj(string account,string uk1,string uk2,string uk3 ,string pwk)
        {
            Account = account;
            UsernameKey1 = uk1;
            UsernameKey2 = uk2;
            UsernameKey3 = uk3;
            PasswordKey = pwk;
        }
    }
}
