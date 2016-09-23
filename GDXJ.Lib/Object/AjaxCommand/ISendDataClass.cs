using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand
{
    interface ISendDataClass
    {
        string JavaClass{get;set;}
        Dictionary<string, object> map { get; set; }
        int Length { get;}
        //string ToString();
    }
}
