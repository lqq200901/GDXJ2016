using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gdxj.Object.AjaxCommand.Data;
using System.Net;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class SaveStudentCDClass : SendDataClass
    {
        public SaveStudentCDClass(SaveStudent_StudentData studentData)
        {
            xsJbxxRecord xs=new xsJbxxRecord();
            xs.data = studentData;
            map.Add("xsJbxxRecord",xs );
            JavaClass = "ParameterSet";
        }

        public void AddFamilyMember(ref CookieContainer cookie,FamilyMember fm,int id)
        {
            FamilyMemberRecord fmr = new FamilyMemberRecord(id);
            fmr.data = new FamilyMember_SendData(ref cookie, fm);
            if (!map.ContainsKey("jtcyrecords"))
            {
                map.Add("jtcyrecords", new List<FamilyMemberRecord>());
            }
            ((List<FamilyMemberRecord>)map["jtcyrecords"]).Add(fmr);
        }

        public void AddFamilyMembers(ref CookieContainer cookie,List<FamilyMember> fms)
        {
            List<FamilyMemberRecord> fmrList = new List<FamilyMemberRecord>();
            int id = 1001;
            foreach (FamilyMember fm in fms)
            {
                FamilyMemberRecord fmr = new FamilyMemberRecord(id++);
                fmr.data =new FamilyMember_SendData(ref cookie,fm);
                fmrList.Add(fmr);
            }

            if (map.ContainsKey("jtcyrecords"))
            {
                map["jtcyrecords"] = fmrList;
            }
            else
                map.Add("jtcyrecords", fmrList);
        }

        public void AddEconomicsRecord(Economics economics)
        {
            EconomicsRecord er = new EconomicsRecord();
            er.data = economics;
            if (map.ContainsKey("jtjjqkrecord"))
            {
                map["jtjjqkrecord"] = er;
            }
            else
                map.Add("jtjjqkrecord", er);
        }
    }

    public class xsJbxxRecord
    {
        public string javaClass { get; set; }
        public int id { get; set; }
        public int state{ get; set; }
        public Student data { get; set; }
        public xsJbxxRecord()
        {
            javaClass = "Record";
            id = 1003;
            state = 3;
        }
    }

    public class FamilyMemberRecord
    {
        public string javaClass { get; set; }
        public int id { get; set; }
        public int state { get; set; }
        public FamilyMember_SendData data { get; set; }
        public FamilyMemberRecord(int id)
        {
            javaClass = "Record";
            this.id = id;
            state = 0;
        }
    }

    public class EconomicsRecord
    {
        public string javaClass { get; set; }
        public int id { get; set; }
        public int state { get; set; }
        public Economics data { get; set; }
        public EconomicsRecord()
        {
            javaClass = "Record";
            this.id = 1004;
            state = 0;
        }
    }
}
