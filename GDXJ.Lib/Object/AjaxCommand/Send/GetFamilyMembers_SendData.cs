using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class GetFamilyMembers_SendData : SendDataClass
    {
        public GetFamilyMembers_SendData(string studentId)
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("dir", SendSetting.SendDataSetting.QS_dir);
            AddMapData("limit", SendSetting.SendDataSetting.QS_limit);
            AddMapData("start", SendSetting.SendDataSetting.QS_start);
            AddMapData("defaultSort", new DefaultSort());
            AddMapData("XS_JBXX_ID@=", studentId);
        }

        public void SetStudent(string studentId)
        {
            AddMapData("XS_JBXX_ID@=", studentId);
        }

        public void SetStart(string start)
        {
            AddMapData("start", start);
        }

        public void SetLimit(string limit)
        {
            AddMapData("limit", limit);
        }
    }
}
