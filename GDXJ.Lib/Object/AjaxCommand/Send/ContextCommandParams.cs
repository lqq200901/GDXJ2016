using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class ContextCommandParams : CommandParams
    {
        public Context context { get; set; }

        public ContextCommandParams()
        {
            context = new Context();
        }
    }

    class Context
    {
        public string javaClass { get; set; }
        public Dictionary<string, object> map { get; set; }
        public int length
        {
            get { return map.Count; }
        }

        public Context()
        {
            javaClass = "HashMap";
            map = new Dictionary<string, object>();
        }
    }
}
