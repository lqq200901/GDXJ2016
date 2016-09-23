using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    public class MetaData
    {
        public string totalProperty { get; set; }
        public string root { get; set; }
        public string successProperty { get; set; }
        public List<Field> fields { get; set; }
    }
}
