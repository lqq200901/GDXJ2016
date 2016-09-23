using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    class ReceiveGradeDataClass//:IReceiveDataClass
    {
        public string javaClass { get; set; }
        public bool success { get; set; }
        public Receive.MetaData metaData { get; set; }
        public List<Grade> rows { get; set; }
    }
}
