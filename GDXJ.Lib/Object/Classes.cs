using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using QQLib.Http;
using GDXJ.Lib.Object.AjaxCommand.Receive;
using JumpKick.HttpLib;

namespace GDXJ.Lib.Object
{
    public class Classes : IRollObj
    {
        public string yxbz { get; set; }
        public string xxXqxxId { get; set; }
        public string bzrid { get; set; }
        public string bjmc { get; set; }
        public string ssmzsyjxyym { get; set; }
        public string bjlxdm { get; set; }
        public string xz { get; set; }
        public string zsnd { get; set; }
        public string xxBjxxId { get; set; }
        public string ssmzsyjxmsm { get; set; }
        public string javaClass { get; set; }
        public string xxNjxxId { get; set; }
        public string bh { get; set; }
        public string bzrxm { get; set; }
        public string xxFsbxxId { get; set; }
        public string xxJbxxId { get; set; }
        public string ssmzsyjxbm { get; set; }

        #region 实现IRollObj接口
        public string ID
        {
            get
            {
                return xxBjxxId;
            }
        }

        public string ParentID
        {
            get
            {
                return xxNjxxId;
            }
        }

        public string Name
        {
            get { return bjmc; }
        }

        public setting.@const.RollObjType Type
        {
            get { return setting.@const.RollObjType.@class; }
        }

        #endregion

        public static List<Classes> QueryClassesByGrade(ref CookieContainer cookie, string gradeId)
        {
            List<Classes> result = null;
            try
            {
                AjaxCommand.Send.ListClassClass classData = new AjaxCommand.Send.ListClassClass();
                classData.SetGrade(gradeId);
                result = QueryClasses(ref cookie, classData);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        public static List<Classes> QueryClassesById(ref CookieContainer cookie, string schoolId, string classId)
        {
            List<Classes> result = null;
            try
            {
                AjaxCommand.Send.ListClassClass classData = new AjaxCommand.Send.ListClassClass();
                classData.SetSchool(schoolId);
                classData.SetClass(classId);
                result = QueryClasses(ref cookie, classData);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        private static List<Classes> QueryClasses(ref CookieContainer cookie, AjaxCommand.Send.ListClassClass lcc)
        {
            List<Classes> result = null;
            try
            {
                AjaxCommand.Send.CommandParams param = new AjaxCommand.Send.CommandParams() { @params = lcc };
                string json = JsonConvert.SerializeObject(param, Formatting.Indented);

                var req = Http.Post(setting.url.ZxxsXxBjxxQueryUrl).Body(json);
                req.AddHeader("Referer", setting.url.QueryGradeRefererUrl);
                req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());
                string html = req.RealTimeGo().RequestString;

                ReceiveClassesDataClass receiveGrade = JsonConvert.DeserializeObject<ReceiveClassesDataClass>(html);
                result = receiveGrade.rows;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        public List<Student> QueryStudent(ref CookieContainer cookie, int start = 0, int limit = 200)
        {
            return Student.QueryStudent(ref cookie, xxJbxxId, xxBjxxId,start,limit);
        }
    }
}
