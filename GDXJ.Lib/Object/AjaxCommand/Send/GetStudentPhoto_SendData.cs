using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class GetStudentPhoto_SendData : SendDataClass
    {
        public GetStudentPhoto_SendData(string studentId)
            : base()
        {
            JavaClass = "ParameterSet";
            AddMapData("XS_JBXX_ID@=", studentId);
        }

        public void SetStudent(string studentId)
        {
            AddMapData("XS_JBXX_ID@=", studentId);
        }
    }
}
