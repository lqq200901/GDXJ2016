using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JumpKick.HttpLib
{
    public class RequestData
    {
        public Stream RequestStream { get;private set; }
        public String RequestString {
            get {
                StreamReader myStreamReader = new StreamReader(RequestStream, Code);
                return myStreamReader.ReadToEnd();
            }
        }

        public Encoding Code { get; set; }

        public RequestData(Stream stream)
        {
            RequestStream = stream;
            Code = Encoding.GetEncoding("UTF-8");
        }
    }
}
