using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQLib.Decoded
{
    public class Eval
    {
        public static string GetEvalString(string stringjs)
        {
            var s = stringjs.Split(new string[]{@"\x"}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            if (s.Length > 1)
                for (int i = 0; i < s.Count(); i++)
                {
                    sb.Append((char)Convert.ToInt32(s[i], 16));
                }
            return sb.ToString();
        }
    }
}
