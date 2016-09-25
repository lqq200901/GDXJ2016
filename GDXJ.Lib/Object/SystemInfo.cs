using System.Net;
using Newtonsoft.Json;
using QQLib.Http;
using System;
using System.Collections.Generic;
using GDXJ.Lib.Object.AjaxCommand.Send;

namespace GDXJ.Lib.Object
{
    public class SystemInfo
    {
        public static string GetRegionName(ref CookieContainer cookie, string regionCode)
        {
            string result = "";
            try
            {
                GetRegionName_CommandSendData g = new GetRegionName_CommandSendData();
                g.SetRegionCode(regionCode);
                AjaxCommand.Send.ContextCommandParams param = new AjaxCommand.Send.ContextCommandParams() { @params = g };
                string json = JsonConvert.SerializeObject(param, Formatting.Indented);
                string html = RequestHelper.GetByPostJson(setting.url.GetRegionNameUrl, json, ref cookie, setting.url.QueryGradeRefererUrl);
                GetRegionName_CommandReceiveData receive = JsonConvert.DeserializeObject<GetRegionName_CommandReceiveData>(html);
                result = receive.map.text;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

    }

    public class GetRegionName_CommandSendData : SendDataClass
    {
        public GetRegionName_CommandSendData()
                : base()
            {
                JavaClass = "ParameterSet";
                AddMapData("dic","V_COM_MEMS_ORGAN");
                AddMapData("text","REGION_CODE");
                AddMapData("value","REGION_NAME");
            }

        public void SetRegionCode(string regionCode)
            {
                AddMapData("valueCode", regionCode);
            }
    }

    public class GetRegionName_CommandReceiveData
    {
        public string javaClass { get; set; }
        public DataMap map { get; set; }
        public struct DataMap
        {
            public string text { get; set; }
        }
    }
}
