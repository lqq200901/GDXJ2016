using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using QQLib.Http;
using System.Net;
using GDXJ.Lib.Object.setting;
using GDXJ.Lib.Object.AjaxCommand.Receive;
using JumpKick.HttpLib;

namespace GDXJ.Lib.Object
{
    public class Family
    {
        public static List<FamilyMember> GetFamilyMembers(ref CookieContainer cookie, string studentId)
        {
            List<FamilyMember> result = null;
            try
            {
                AjaxCommand.Send.ContextCommandParams sendData = new AjaxCommand.Send.ContextCommandParams() { @params = new AjaxCommand.Send.GetFamilyMembers_SendData(studentId) };
                string json = JsonConvert.SerializeObject(sendData, Formatting.Indented);

                var req = Http.Post(setting.url.GetFamilyMembersUrl).Body(json);
                req.AddHeader("Referer", setting.url.QueryGradeRefererUrl);
                req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());
                string html = req.RealTimeGo().RequestString;

                GetFamilyMembers_ReceiveData receiveStudentData = JsonConvert.DeserializeObject<GetFamilyMembers_ReceiveData>(html);
                result = receiveStudentData.rows;
            }
            catch (Exception e)
            {
                result = new List<FamilyMember>();
            }
            finally
            {

            }
            return result;
        }
    }

    public class FamilyMember
    {
        public string gxr { get; set; }
        public string gxsj { get; set; }
        public string gxsm { get; set; }
        public string lrsj { get; set; }
        public string xsJbxxId { get; set; }
        public int state { get; set; }
        public string lrr { get; set; }
        public string zw { get; set; }
        public string dh { get; set; }
        public string sfjhrm { get; set; }
        public string gjdqm { get; set; }
        public string cyxm { get; set; }
        public string xzz { get; set; }
        public string xsJtcyId { get; set; }
        public string sm { get; set; }
        public string yxbz { get; set; }
        public string gzdw { get; set; }
        public string xxsszgjyxzdm { get; set; }
        public string csny { get; set; }
        public string mzm { get; set; }
        public string lxdh { get; set; }
        public string javaClass { get; set; }
        public string sfzjh { get; set; }
        public string hkszd { get; set; }
        public string sfzjlxm { get; set; }
        public string gxm { get; set; }
        public string gx
        {
            get
            {
                switch (gxm)
                {
                    case "1":
                        return "父亲";
                    case "2":
                        return "母亲";
                    default:
                        return "其他";
                }
            }
        }
    }

    public class FamilyMember_SendData : FamilyMember
    {
        public string csdmc { get; set; }
        public string hkszdmc { get; set; }
        new private string javaClass { get; set; }
        public FamilyMember_SendData(ref CookieContainer cookie, FamilyMember fm)
            : base()
        {
            this.csdmc = "";
            this.gxr = fm.gxr ?? "";
            this.gxsj = fm.gxsj ?? "";
            this.gxsm = fm.gxsm ?? "";
            this.lrsj = fm.lrsj ?? "";
            this.xsJbxxId = fm.xsJbxxId ?? "";
            this.state = fm.state;
            this.lrr = fm.lrr ?? "";
            this.zw = fm.zw ?? "";
            this.dh = fm.dh ?? "";
            this.sfjhrm = fm.sfjhrm ?? "";
            this.gjdqm = fm.gjdqm ?? "";
            this.cyxm = fm.cyxm ?? "";
            this.xzz = fm.xzz ?? "";
            this.xsJtcyId = fm.xsJtcyId ?? "";
            this.sm = fm.sm ?? "";
            this.yxbz = fm.yxbz ?? "";
            this.gzdw = fm.gzdw ?? "";
            this.xxsszgjyxzdm = fm.xxsszgjyxzdm ?? "";
            this.csny = fm.csny ?? "";
            this.mzm = fm.mzm ?? "";
            this.lxdh = fm.lxdh ?? "";
            this.javaClass = fm.javaClass ?? "";
            this.sfzjh = fm.sfzjh ?? "";
            this.hkszd = fm.hkszd ?? "";
            this.sfzjlxm = fm.sfzjlxm ?? "";
            this.gxm = fm.gxm ?? "";
            this.hkszdmc = SystemInfo.GetRegionName(ref cookie, fm.hkszd);
        }
    }

    class GetFamilyMembers_ReceiveData //: IReceiveDataClass
    {
        public int total { get; set; }
        public string javaClass { get; set; }
        public bool success { get; set; }
        public MetaData metaData { get; set; }
        public List<FamilyMember> rows { get; set; }
    }
}
