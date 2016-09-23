using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QQLib.Collection;

namespace GDXJ.Lib.Object
{
    public interface IRollObj
    {
        string ID { get;}
        string ParentID { get;}
        string Name { get; }
        setting.@const.RollObjType Type { get; }
    }
}
