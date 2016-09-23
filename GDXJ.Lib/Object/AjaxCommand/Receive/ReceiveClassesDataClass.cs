using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    class ReceiveClassesDataClass //: IReceiveDataClass
    {
        public string javaClass { get; set; }
        public bool success { get; set; }
        public Receive.MetaData metaData { get; set; }
        public List<Classes> rows { get; set; }
    }
}
