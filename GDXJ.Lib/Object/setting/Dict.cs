using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QQLib.Http;
using GDXJ.Lib;
using GDXJ.Lib.Object.AjaxCommand.Send;
using GDXJ.Lib.Object.AjaxCommand.Send.SendSetting;
using Newtonsoft.Json;
using GDXJ.Lib.Object.AjaxCommand.Receive;

namespace GDXJ.Lib.Object.setting
{
    public class Dict
    {
        #region 获取信息代码字典
        /// <summary>
        /// 班级码
        /// </summary>
        public static Dictionary<string, string> ClassDict;
        /// <summary>
        /// 获取国籍码
        /// </summary>
        public static Dictionary<string, string> Country;
        /// <summary>
        /// 获取证件类型的命令字串
        /// </summary>
        public static Dictionary<string, string> CertificateType;
        /// <summary>
        /// 获取港澳台外的命令字串
        /// </summary>
        public static Dictionary<string, string> GATQ;
        /// <summary>
        /// 获取健康状况的命令字串
        /// </summary>
        public static Dictionary<string, string> ZXSKJ;
        /// <summary>
        /// 获取户口性质的命令字串
        /// </summary>
        public static Dictionary<string, string> HKXZ;
        /// <summary>
        /// 获取是或否代码的命令字串
        /// </summary>
        public static Dictionary<string, string> YesOrNo;
        /// <summary>
        /// 获取留守儿童代码的命令字串
        /// </summary>
        public static Dictionary<string, string> LSET;
        /// <summary>
        /// 获取性别代码的命令字串
        /// </summary>
        public static Dictionary<string, string> XB;
        /// <summary>
        /// 获取民族的命令字串
        /// </summary>
        public static Dictionary<string, string> MZ;
        /// <summary>
        /// 学校名
        /// </summary>
        public static string schoolName;
        public static ReceiveSchoolInfoClass schoolInfo;
        #endregion

        public static void GetDictionarys(Gdxj xj)
        {
            ClassDict = GetData(xj, new GetGeneralDictClass(xj.GdxjUser.organ.organCode));
            Country= GetData(xj,new GetDictClass(SendDataSetting.CountryID));
            CertificateType= GetData(xj,new GetDictClass(SendDataSetting.CertificateType));
            GATQ= GetData(xj,new GetDictClass(SendDataSetting.GATQ));
            ZXSKJ= GetData(xj,new GetDictClass(SendDataSetting.ZXSKJ));
            HKXZ= GetData(xj,new GetDictClass(SendDataSetting.HKXZ));
            YesOrNo= GetData(xj,new GetDictClass(SendDataSetting.YesOrNo));
            LSET= GetData(xj,new GetDictClass(SendDataSetting.LSET));
            XB= GetData(xj,new GetDictClass(SendDataSetting.XB));
            MZ= GetData(xj,new GetDictClass(SendDataSetting.MZ));
            schoolName = xj.GdxjUser.organ.organName;
            schoolInfo = GetSchoolInfo(xj, xj.GdxjUser.organ.organCode);
        }

        private static Dictionary<string, string> GetData(Gdxj xj, SendDataClass gdc)
        {
            Dictionary<string, string> result=new Dictionary<string,string>();
            string url = (gdc.GetType() == typeof(GetGeneralDictClass)) ? setting.url.QueryGeneralDicUrl : setting.url.QueryForDicUrl;
                
            try
            {
                AjaxCommand.Send.ContextCommandParams ccp = new AjaxCommand.Send.ContextCommandParams() { @params = gdc };
                string json = JsonConvert.SerializeObject(ccp, Formatting.Indented);
                string html = RequestHelper.GetByPostJsonWithCsrf(url, json, ref xj.GdxjCookie.cookie, Csrf.GetCsrfToken(ref xj.GdxjCookie.cookie), setting.url.QueryGradeRefererUrl);
                ReceiveDictDataClass receiveStudentData = JsonConvert.DeserializeObject<ReceiveDictDataClass>(html);
                receiveStudentData.rows.ForEach(r =>
                    {
                        result.Add(r.value, r.text);
                    });
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        public static string GetOrganName(Gdxj xj, GetOrganDictClass godc)
        {
            string result = string.Empty;

            try
            {
                AjaxCommand.Send.ContextCommandParams ccp = new AjaxCommand.Send.ContextCommandParams() { @params = godc };
                string json = JsonConvert.SerializeObject(ccp, Formatting.Indented);
                string html = RequestHelper.GetByPostJsonWithCsrf(setting.url.QueryOrganDicUrl, json, ref xj.GdxjCookie.cookie, Csrf.GetCsrfToken(ref xj.GdxjCookie.cookie), setting.url.QueryGradeRefererUrl);
                ReceiveOrganNameClass receiveData = JsonConvert.DeserializeObject<ReceiveOrganNameClass>(html);
                if(receiveData.map!=null)
                       result = receiveData.map.text;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        private static ReceiveSchoolInfoClass GetSchoolInfo(Gdxj xj, string schoolID)
        {
            ReceiveSchoolInfoClass result =new ReceiveSchoolInfoClass();
            GetSchoolInfoClass gsic = new GetSchoolInfoClass(schoolID);
            try
            {
                AjaxCommand.Send.ContextCommandParams ccp = new AjaxCommand.Send.ContextCommandParams() { @params = gsic };
                string json = JsonConvert.SerializeObject(ccp, Formatting.Indented);
                string html = RequestHelper.GetByPostJsonWithCsrf(setting.url.QuerySchoolInfoUrl, json, ref xj.GdxjCookie.cookie, Csrf.GetCsrfToken(ref xj.GdxjCookie.cookie), setting.url.QueryGradeRefererUrl);
                result = JsonConvert.DeserializeObject<ReceiveSchoolInfoClass>(html);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }
    }
}
