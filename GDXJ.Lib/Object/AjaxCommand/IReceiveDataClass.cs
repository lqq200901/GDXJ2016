using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gdxj.Object.AjaxCommand.Receive;

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
