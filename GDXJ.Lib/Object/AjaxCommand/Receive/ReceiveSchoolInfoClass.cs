using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    class ReceiveDictDataClass //: IReceiveDataClass
    {
        public string javaClass { get; set; }
        public bool success { get; set; }
        public Receive.MetaData metaData { get; set; }
        public List<DictData> rows { get; set; }
    }

    class DictData
    {
        public string code { get; set; }
        public bool deleted { get; set; }
        public string javaClass { get; set; }
        public bool modified { get; set; }
        public bool @new { get; set; }
        public int state { get; set; }
        public string text { get; set; }
        public string value { get; set; }
    }
}
