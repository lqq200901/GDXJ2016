using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object
{
    public class TreeObject
    {
        public string ID
        {
            get
            {
                if (RollObject != null)
                {
                    return RollObject.ID;
                }
                else
                    return string.Empty;
            }
        }
        public string ParentID
        {
            get
            {
                if (RollObject != null)
                {
                    return RollObject.ParentID;
                }
                else
                    return string.Empty;
            }
        }
        public bool Checked { get; set; }
        public string Name
        {
            get
            {
                if (RollObject != null)
                {
                    return RollObject.Name;
                }
                else
                    return string.Empty;
            }
        }

        public string Type
        {
            get
            {
                if (RollObject != null)
                {
                    string result = string.Empty;
                    switch (RollObject.Type)
                    {
                        case setting.@const.RollObjType.grade:
                            result= "年级";
                            break;
                        case setting.@const.RollObjType.@class:
                            result= "班级";
                            break;
                        case setting.@const.RollObjType.student:
                            result= "学生";
                            break;
                    }
                    return result;
                }
                else
                    return string.Empty;
            }
        }

        public IRollObj RollObject { get; set; }
    }
}
