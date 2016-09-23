using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using QQLib.Http;
using gdxj.Object.setting;

namespace GDXJ.Lib.Object
{
    public class Economics
    {
        public string gxr { get; set; }
        public string gxsj { get; set; }
        public string jtcrsyrs { get; set; }
        public string jtnsr { get; set; }
        public string jtqzje { get; set; }
        public string jtrk { get; set; }
        public string jttfywqk { get; set; }
        public string jtzysrly { get; set; }
        public string jxddbx { get; set; }
        public string kncdm { get; set; }
        public string ldlrk { get; set; }
        public string lrr { get; set; }
        public string lrsj { get; set; }
        public string qzyy { get; set; }
        public string sfdbm { get; set; }
        public string sffmssldnlm { get; set; }
        public string sfjlsm { get; set; }
        public string sfjtyhdbm { get; set; }
        public string sfjtzstfyw { get; set; }
        public string sfjtzszrzhm { get; set; }
        public string sfmzbmqrnctkm { get; set; }
        public string sfncjdpkjtm { get; set; }
        public string sfwbhm { get; set; }
        public string syrk { get; set; }
        public string xsJbxxId { get; set; }
        public string xsJtjjqkId { get; set; }
        public string xxsszgjyxzdm { get; set; }
        public string ygxsj { get; set; }
        public string zrzhqk { get; set; }
        public string javaClass { get; set; }
        public string state { get; set; }

        public static List<Economics> GetEconomics(ref CookieContainer cookie, string studentId)
        {
            List<Economics> result = null;
            try
            {
                AjaxCommand.Send.ContextCommandParams sendData = new AjaxCommand.Send.ContextCommandParams() { @params = new AjaxCommand.Send.GetFamilyMembers_SendData(studentId) };
                string json = JsonConvert.SerializeObject(sendData, Formatting.Indented);
                string html = RequestHelper.GetByPostJson(url.GetEconomicsUrl, json, ref cookie, url.QueryGradeRefererUrl);
                GetEconomics_ReceiveData receiveStudentData = JsonConvert.DeserializeObject<GetEconomics_ReceiveData>(html);
                result = receiveStudentData.rows;
            }
            catch (Exception e)
            {
                result = new List<Economics>();
            }
            finally
            {
                
            }
            return result;
        }
    }

    class GetEconomics_ReceiveData //: IReceiveDataClass
    {
        public int total { get; set; }
        public string javaClass { get; set; }
        public bool success { get; set; }
        public gdxj.Object.AjaxCommand.Receive.MetaData metaData { get; set; }
        public List<Economics> rows { get; set; }
    }
}
