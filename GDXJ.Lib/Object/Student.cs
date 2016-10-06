using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using QQLib.Http;
using QQLib.Collection;
using System.Windows.Media;
using GDXJ.Lib.Object.AjaxCommand.Receive;
using GDXJ.Lib.Object.setting;
using GDXJ.Lib.Object.AjaxCommand.Data;
using JumpKick.HttpLib;

namespace GDXJ.Lib.Object
{
    public class Student : DataRecord, IRollObj
    {
        #region 学生属性
        /// <summary>
        /// 曾用名
        /// </summary>
        public string cym { get; set; }

        public string bz { get; set; }
        /// <summary>
        /// 班内学号
        /// </summary>
        public string bnxh { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string xm { get; set; }
        /// <summary>
        /// 就读方式码
        /// </summary>
        public string jdfsm { get; set; }
        /// <summary>
        /// 出生地编码
        /// </summary>
        public string csdm { get; set; }
        /// <summary>
        /// 班级编码
        /// </summary>
        public string xxBjxxId { get; set; }//cb39d84f311c47b397449cd7e51ff83b
        /// <summary>
        /// 就读班级
        /// </summary>
        public string xxBj { get { return Dict.ClassDict[xxBjxxId]; } }
        public string jdztm { get; set; }//": "3Z",
        /// <summary>
        /// 是否购买学位
        /// </summary>
        public string sfgmxwm { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        public string tc { get; set; }
        /// <summary>
        /// 入学年月
        /// </summary>
        public string rxny { get; set; }

        public string hyzkm { get; set; }
        /// <summary>
        /// 国籍地区码
        /// </summary>
        public string gjdqm { get; set; }
        /// <summary>
        /// 国籍地区
        /// </summary>
        public string gjdq { get { return Dict.Country[gjdqm]; } }
        /// <summary>
        /// 现住址
        /// </summary>
        public string xzz { get; set; }
        /// <summary>
        /// 户口性质码
        /// </summary>
        public string hkxzm { get; set; }
        /// <summary>
        /// 户口性质
        /// </summary>
        public string hkxz { get { return Dict.HKXZ[hkxzm]; } }
        /// <summary>
        /// 是否孤儿
        /// </summary>
        public string sfge { get; set; }
        /// <summary>
        /// 学生类别码
        /// </summary>
        public string xslbm { get; set; }
        /// <summary>
        /// 学籍号
        /// </summary>
        public string grbsm { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string zzmmm { get; set; }
        /// <summary>
        /// 主页地址
        /// </summary>
        public string zydz { get; set; }
        /// <summary>
        /// 民族码
        /// </summary>
        public string mzm { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string mz { get { return Dict.MZ[mzm]; } }
        /// <summary>
        /// 上下学距离
        /// </summary>
        public string sxxjl { get; set; }
        /// <summary>
        /// 性别码
        /// </summary>
        public string xbm { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string xb { get { return Dict.XB[xbm]; } }

        public string sftjzscl { get; set; }
        /// <summary>
        /// 入学方式码
        /// </summary>
        public string rxfsm { get; set; }

        public string xyzjm { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string lxdh { get; set; }
        /// <summary>
        /// 电子信箱
        /// </summary>
        public string dzxx { get; set; }
        /// <summary>
        /// 学籍辅号
        /// </summary>
        public string xjfh { get; set; }
        /// <summary>
        /// 是否受过学前教育码
        /// </summary>
        public string sfsgxqjym { get; set; }
        /// <summary>
        /// 是否受过学前教育
        /// </summary>
        public string sfsgxqjy { get { return Dict.YesOrNo[sfsgxqjym]; } }
        /// <summary>
        /// 类的类型
        /// </summary>
        public string javaClass { get; set; }

        /// <summary>
        /// 身份证件有效期
        /// </summary>
        public string sffqsq { get; set; }
        /// <summary>
        /// 身份证件号
        /// </summary>
        public string sfzjh { get; set; }
        /// <summary>
        /// 上下学交通方式码
        /// </summary>
        public string sxxfsm { get; set; }
        /// <summary>
        /// 是否乘坐校车码
        /// </summary>
        public string sfczxcm { get; set; }
        /// <summary>
        /// 身份证件类型码
        /// </summary>
        public string sfzjlxm { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string yzbm { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        //public string gxsj { get; set; }
        /// <summary>
        /// 血型码
        /// </summary>
        public string xxm { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public string lrsj { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public string xsJbxxId { get; set; }//": "8a8081823ff74e1a013ff74e1ac00039",
        /// <summary>
        /// 身份证件有效期
        /// </summary>
        public string sfzjyxq { get; set; }

        public string sfxsyyc { get; set; }
        //public int state { get; set; }
        /// <summary>
        /// 学校标识码
        /// </summary>
        public string lrr { get; set; }//1529551
        public string SchoolName { get { return Dict.schoolName; } }
        /// <summary>
        /// 是否烈士或优抚子女
        /// </summary>
        public string sflshyfzn { get; set; }
        public string sfwlwgryznm { get; set; }
        /// <summary>
        /// 是否随迁子女码
        /// </summary>
        public string sfsqznm { get; set; }
        /// <summary>
        /// 是否寄宿码
        /// </summary>
        public string sfjssm { get; set; }
        /// <summary>
        /// 是否寄宿
        /// </summary>
        public string sfjss
        {
            get
            {
                if (sfjssm == null)
                    return "否";
                else
                    return Dict.YesOrNo[sfjssm];
            }
        }

        public string ywxm { get; set; }

        public string sfzx { get; set; }
        /// <summary>
        /// 年级ID
        /// </summary>
        public string xxNjxxId { get; set; }
        /// <summary>
        /// 健康状况码
        /// </summary>
        public string jkzkm { get; set; }
        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string xmpy { get; set; }

        public string sbjdm { get; set; }

        public string xxsszgjyxzdm { get; set; }//440604000000
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string jtzz { get; set; }
        /// <summary>
        /// 是否享受一补码
        /// </summary>
        public string sfxsybm { get; set; }

        public string cczt { get; set; }
        /// <summary>
        /// 残疾人类型码
        /// </summary>
        public string cjlxm { get; set; }
        /// <summary>
        /// 是否享受一补
        /// </summary>
        public string sfxsyb { get; set; }
        /// <summary>
        /// 学生来源码
        /// </summary>
        public string xslym { get; set; }
        /// <summary>
        /// 是否留守儿童码
        /// </summary>
        public string sflsetm { get; set; }
        /// <summary>
        /// 是否留守儿童
        /// </summary>
        public string sflset { get { return Dict.YesOrNo[sflsetm]; } }
        /// <summary>
        /// 通信地址
        /// </summary>
        public string txdz { get; set; }
        /// <summary>
        /// 港澳台侨码
        /// </summary>
        public string gatqwm { get; set; }
        /// <summary>
        /// 港澳台侨
        /// </summary>
        public string gatqw { get { return Dict.GATQ[gatqwm]; } }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string jg { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string csrq { get; set; }
        /// <summary>
        /// 是否独生子女码
        /// </summary>
        public string sfdsznm { get; set; }
        /// <summary>
        /// 是否独生子女
        /// </summary>
        public string sfdszn { get { return Dict.YesOrNo[sfdsznm]; } }
        /// <summary>
        /// 学校ID
        /// </summary>
        public string xxJbxxId { get; set; }//84C4513D09734F41BD7D3CCBD816E6F6
        /// <summary>
        /// 户口所在地码
        /// </summary>
        public string hkszdm { get; set; }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string hkszd { get; set; }

        public string today
        {
            get
            {
                return DateTime.Today.ToString("yyyy年MM月dd日");
            }
        }

        public string xxbsm
        {
            get
            {
                if(Dict.schoolInfo.rows!=null)
                    if((Dict.schoolInfo.rows.Count>0))
                        return Dict.schoolInfo.rows[0].xxbsm;
                return "";
            }
        }
        #endregion


        #region 学籍卡字段
        public string StudentPhotoPath
        {
            get
            {
                return System.IO.Directory.GetCurrentDirectory()+"\\"+ Path.Temp_Path+xsJbxxId+".JPG";
            }
        }
        public ImageSource StudentPhoto { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
        #endregion

        public Student()
        {
        }

        #region 实现IRollObj接口

        public string ID
        {
            get
            {
                return xsJbxxId;
            }
        }

        public string ParentID
        {
            get
            {
                return xxBjxxId;
            }
        }

        public string Name
        {
            get { return xm; }
        }

        public setting.@const.RollObjType Type
        {
            get { return setting.@const.RollObjType.student; }
        }

        #endregion

        public static List<Student> QueryStudent(ref CookieContainer cookie, string schoolId, string classesid, int start = 0, int limit = 0)
        {
            return QueryStudent(ref cookie, schoolId, classesid, start, limit, "");
        }

        public static List<Student> QueryStudent(ref CookieContainer cookie, string schoolId, string classesid, string grbsm)
        {
            return QueryStudent(ref cookie, schoolId, classesid, 0, 0, grbsm);
        }

        public static List<Student> QueryStudent(ref CookieContainer cookie, string schoolId, string classesid, int start, int limit, string grbsm)
        {
            List<Student> result = null;
            try
            {
                if (limit == 0) limit = AjaxCommand.Send.SendSetting.SendDataSetting.QS_limit;
                AjaxCommand.Send.ContextCommandParams ccp = new AjaxCommand.Send.ContextCommandParams() { @params = new AjaxCommand.Send.ListStudentClass(schoolId, classesid, start, limit, grbsm) };
                string json = JsonConvert.SerializeObject(ccp, Formatting.Indented);

                var req = Http.Post(setting.url.ZxxsXsJbxxQueryUrl).Body(json);
                req.AddHeader("Referer", setting.url.QueryGradeRefererUrl);
                req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());
                string html = req.RealTimeGo().RequestString;

                ReceiveStudentDataClass receiveStudentData = JsonConvert.DeserializeObject<ReceiveStudentDataClass>(html);
                result = receiveStudentData.rows;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return result;
        }

        public void GetFamilyMembers(ref CookieContainer cookie)
        {
            if (this.FamilyMembers == null)
                this.FamilyMembers = new List<FamilyMember>();
            else
                this.FamilyMembers.Clear();
            Family.GetFamilyMembers(ref cookie, this.xsJbxxId).ForEach(m => this.FamilyMembers.Add(m));
        }

        public string GetPhoto(ref  CookieContainer cookie)
        {
            return Photo.SavePhotoToFile(ref cookie, this.xsJbxxId, this.xm);
        }

        public static void SaveStudent(ref CookieContainer cookie, Student student)
        {
            //List<Student> result = null;
            try
            {
                SaveStudent_StudentData studentData = new SaveStudent_StudentData();
                studentData.SetValue(student);
                List<Classes> cl = Classes.QueryClassesById(ref cookie, student.xxJbxxId, student.xxBjxxId);
                if (cl != null) if (cl.Count > 0) studentData.SetValue(cl[0]);
                List<Grade> gl = Grade.QueryGradeById(ref cookie, student.xxJbxxId, student.xxNjxxId);
                if (gl != null) if (gl.Count > 0) studentData.SetValue(gl[0]);
                studentData.csdmc = SystemInfo.GetRegionName(ref cookie, studentData.csdm);
                studentData.hkszdmc = SystemInfo.GetRegionName(ref cookie, studentData.hkszdm);
                AjaxCommand.Send.SaveStudentCDClass sscd = new AjaxCommand.Send.SaveStudentCDClass(studentData);
                sscd.AddFamilyMembers(ref cookie, Family.GetFamilyMembers(ref cookie, student.xsJbxxId));
                var e = Economics.GetEconomics(ref cookie, student.xsJbxxId);
                if (e.Count == 0) e = Economics.GetEconomics(ref cookie, student.xsJbxxId);
                Economics ee;
                if (e.Count > 0) ee = e[0];
                else
                {
                    ee = new Economics();
                    ee.xsJbxxId = student.xsJbxxId;
                    ee.xxsszgjyxzdm = student.xxsszgjyxzdm;
                }
                sscd.AddEconomicsRecord(ee);
                AjaxCommand.Send.ContextCommandParams ccp = new AjaxCommand.Send.ContextCommandParams() { @params = sscd };
                string json = JsonConvert.SerializeObject(ccp, Formatting.Indented);

                var req = Http.Post(setting.url.SaveStudentInfoUrl).Body(json);
                req.AddHeader("Referer", setting.url.QueryGradeRefererUrl);
                req.AddHeader("_ccrf.token", Csrf.GetCsrfToken());
                string html = req.RealTimeGo().RequestString;

                //ReceiveStudentDataClass receiveStudentData = JsonConvert.DeserializeObject<ReceiveStudentDataClass>(html);
                //result = receiveStudentData.rows;


            }
            catch (Exception e)
            {
                //throw (e);
            }
            //return result;
        }

        public void SaveStudent(ref CookieContainer cookie)
        {
            Student.SaveStudent(ref cookie, this);
        }

        public List<Classes> GetMyClasses(ref CookieContainer cookie)
        {
            return Classes.QueryClassesById(ref cookie, xxJbxxId, xxBjxxId);
        }
    }
}
