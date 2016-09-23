using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand
{
    interface IJavaClass
    {
        string JavaClassName{get;set;}
        IMap Map { get; set; }
        int Length { get; set; }
        override string ToString();
    }
}
