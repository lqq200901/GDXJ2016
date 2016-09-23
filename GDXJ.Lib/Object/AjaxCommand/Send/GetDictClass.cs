using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class GetDictClass : SendDataClass
    {
        public GetDictClass(string param)
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("defaultSort", new DefaultSort());
            AddMapData("dir", SendSetting.SendDataSetting.QS_dir);
            AddMapData("dicType", param);
        }
    }

    class GetGeneralDictClass : SendDataClass
    {
        public GetGeneralDictClass(string JBXX_ID)
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("defaultSort", new DefaultSort());
            AddMapData("dic", "ZXXS_XX_BJXX");
            AddMapData("dir", SendSetting.SendDataSetting.QS_dir);           
            AddMapData("filterSql", string.Format(@"XX_JBXX_ID='{0}' AND YXBZ='1'", JBXX_ID));
            AddMapData("limit", 10);
            AddMapData("start", 0); 
            AddMapData("text", "XX_BJXX_ID"); 
            AddMapData("value", "BJMC");
        }
    }

    public class GetOrganDictClass : SendDataClass
    {
        public GetOrganDictClass(string organID)
            : base()
        {
            JavaClass = "ParameterSet";
            AddMapData("dic", "V_COM_MEMS_ORGAN");
            AddMapData("valueCode", organID);
            AddMapData("text", "REGION_CODE");
            AddMapData("value", "REGION_NAME");
        }
    }

    class GetSchoolInfoClass : SendDataClass
    {
        public GetSchoolInfoClass(string JBXX_ID)
            : base()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
            AddMapData("defaultSort", new DefaultSort());
            AddMapData("dir", SendSetting.SendDataSetting.QS_dir);
            AddMapData("limit", 10);
            AddMapData("start", 0);
            AddMapData("XX_JBXX_ID@=", JBXX_ID);
        }
    }
}
