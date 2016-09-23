using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class ListGradeClass : SendDataClass
    {
        public ListGradeClass()
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("NJZT@=",SendSetting.SendDataSetting.QueryGrade_NJZT);
            AddMapData("sort", SendSetting.SendDataSetting.QueryGrade_sort);
            AddMapData("dir", SendSetting.SendDataSetting.QueryGrade_dir);
        }

        public void SetSchoolId(string schoolId)
        {
            AddMapData("XX_JBXX_ID@=",schoolId);
        }

        public void SetGradeId(string gradeId)
        {
            AddMapData("XX_NJXX_ID@=",gradeId);
        }
    }
}
