using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class ListClassClass : SendDataClass
    {
        public ListClassClass()
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("YXBZ@=", SendSetting.SendDataSetting.QueryClass_YXBZ);
            AddMapData("sort", SendSetting.SendDataSetting.QueryClass_sort);
        }

        public void SetSchool(string schoolId)
        {
            AddMapData("XX_JBXX_ID@=", schoolId);
        }

        public void SetGrade(string gradeId)
        {
            AddMapData("XX_NJXX_ID@=", gradeId);
        }

        public void SetClass(string classId)
        {
            AddMapData("XX_BJXX_ID@=", classId);
        }
    }
}
