using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    public class SendDataClass:ISendDataClass
    {
        public string JavaClass { get; set; }
        public Dictionary<string, object> map { get; set; }
        public int Length
        {
            get
            {
                int lenght = map.Count;
                if (map.ContainsKey("defaultSort"))
                {
                    lenght += 1;
                }
                return lenght;
            }
        }

        public SendDataClass()
        {
            map=new Dictionary<string,object>();
        }

        public void AddMapData(string key, object value)
        {
            if (map.ContainsKey(key))
            {
                map[key] = value;
            }
            else
                map.Add(key, value);
        }
    }
}
