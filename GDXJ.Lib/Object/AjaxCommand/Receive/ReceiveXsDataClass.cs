using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    class ReceiveXsDataClass //: IReceiveDataClass
    {
        public int total { get; set; }
        public string javaClass { get; set; }
        public bool success { get; set; }
        public Receive.MetaData metaData { get; set; }
        public List<XsRecord> rows { get; set; }
    }
}
