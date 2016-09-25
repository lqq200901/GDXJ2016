using System.Net;
using QQLib.Http;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using QQLib.Collection;
using System.Windows;
using GDXJ.Lib.Object.AjaxCommand.Receive;

namespace GDXJ.Lib.Object
{
    public class Grade : IRollObj
    {
        public string njmc { get; set; }
        public string sjsj { get; set; }
        public string xz { get; set; }
        public string jyjd { get; set; }
        public string rxnf { get; set; }
        public string javaClass { get; set; }
        public string xxNjxxId { get; set; }
        public string xjnjdm { get; set; }
        public string xxJbxxId { get; set; }
        public string njzt { get; set; }


        #region 实现IRollObj接口
        public string ID
        {
            get
            {
                return xxNjxxId;
            }
        }

        public string ParentID
        {
            get
            {
                return xxJbxxId;
            }
        }

        public string Name
        {
            get { return njmc; }
        }

        public setting.@const.RollObjType Type
        {
            get { return setting.@const.RollObjType.grade; }
        }

        #endregion

        public static List<Grade> QueryGradeBySchool(ref CookieContainer cookie, string schoolId)
        {
            return QueryGradeById(ref cookie, schoolId, "");
            //List<Grade> result = null;
            //try
            //{
            //    AjaxCommand.Send.ListGradeClass g=new AjaxCommand.Send.ListGradeClass();
            //    g.SetSchoolId(schoolId);
            //    result=QueryGrade(ref cookie, g);
            //    //AjaxCommand.Send.CommandParams param = new AjaxCommand.Send.CommandParams() { @params =  g};
            //    //string json = JsonConvert.SerializeObject(param, Formatting.Indented);
            //    //string html = RequestHelper.GetByPostJson(setting.url.ZxxsXxNjxxQueryUrl, json,ref cookie, setting.url.QueryGradeRefererUrl);
            //    //ReceiveGradeDataClass receiveGrade = JsonConvert.DeserializeObject<ReceiveGradeDataClass>(html);
            //    //result = receiveGrade.rows;
            //}
            //catch(Exception e)
            //{
            //    throw (e);
            //}
            //return result;
        }

        public static List<Grade> QueryGradeById(ref CookieContainer cookie, string schoolId, string gradeId)
        {
            List<Grade> result = null;
            try
            {
                AjaxCommand.Send.ListGradeClass g = new AjaxCommand.Send.ListGradeClass();
                g.SetSchoolId(schoolId);
                if(gradeId!=string.Empty)g.SetGradeId(gradeId);
                result = QueryGrade(ref cookie, g);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "获取数据错误", MessageBoxButton.OK, MessageBoxImage.Error);
                throw (e);
            }
            return result;
        }

        private static List<Grade> QueryGrade(ref CookieContainer cookie, AjaxCommand.Send.ListGradeClass lgc)
        {
            List<Grade> result = null;
            try
            {
                AjaxCommand.Send.CommandParams param = new AjaxCommand.Send.CommandParams() { @params = lgc };
                string json = JsonConvert.SerializeObject(param, Formatting.Indented);
                string html = RequestHelper.GetByPostJsonWithCsrf(setting.url.ZxxsXxNjxxQueryUrl, json, ref cookie,Csrf.GetCsrfToken(ref cookie) , setting.url.QueryGradeRefererUrl);
                ReceiveGradeDataClass receiveGrade = JsonConvert.DeserializeObject<ReceiveGradeDataClass>(html);
                result = receiveGrade.rows;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        public List<Classes> QueryClasses(ref CookieContainer cookie)
        {
            return Classes.QueryClassesByGrade(ref cookie, this.xxNjxxId);
        }
    }
}
