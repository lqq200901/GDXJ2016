using GDXJ.Lib.Object.AjaxCommand.Receive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand
{
    interface IReceiveDataClass
    {
        string javaClass { get; set; }
        bool success { get; set; }
        Receive.MetaData metaData { get; set; }
        List<DataRecord> rows { get; set; }
    }
}
