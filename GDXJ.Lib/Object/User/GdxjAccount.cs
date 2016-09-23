using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.User
{
    class GdxjAccount
    {
        static List<AccountObj> accountList;
        public static List<AccountObj> Account
        {
            get
            {
                if (accountList == null)
                {
                    accountList = new List<AccountObj>();
                    accountList.Add(new AccountObj() { Account = "1529553", LoginString = "07EE60FFB05AF83DDD4EF2D1959C6FDA" });
                    accountList.Add(new AccountObj() { Account = "1529554", LoginString = "07EE60FFB05AF83D473007B8F7429973" });
                    accountList.Add(new AccountObj() { Account = "1529555", LoginString = "07EE60FFB05AF83D209F19D567FE844E" });
                    accountList.Add(new AccountObj() { Account = "1529556", LoginString = "07EE60FFB05AF83D20E00D77369AD21B" });
                    accountList.Add(new AccountObj() { Account = "1529557", LoginString = "07EE60FFB05AF83D12BCB778ECBE3209" });
                    //accountList.Add(new AccountObj() { Account = "1529558", LoginString = "07EE60FFB05AF83D6F5812F7CF930949" });
                }
                return accountList;
            }
        }
    }
}
