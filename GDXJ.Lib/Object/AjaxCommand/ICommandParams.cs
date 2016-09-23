using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand
{
    interface ICommandParams
    {
        IJavaClass JavaClass { get; set; }
        override string ToString();
    }
}
