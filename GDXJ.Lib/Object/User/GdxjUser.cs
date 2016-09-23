using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GDXJ.Lib.Object.User
{
    public class GdxjUser
    {
        public string userId{ get; set; }
        public string userName{ get; set; }
        public string userType{ get; set; }
        public string employeeId{ get; set; }
        public string regionCode{ get; set; }
        public string regionName{ get; set; }
        public Organ organ { get; set; }
        public ZxxsUsersExt zxxsUsersExt { get; set; }
    }
}
