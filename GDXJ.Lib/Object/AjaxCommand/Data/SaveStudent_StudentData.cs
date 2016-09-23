using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Data
{
    public class SaveStudent_StudentData : Student
    {
        public string bh { get; set; }
        public string bjmc { get; set; }
        public string csdmc { get; set; }
        public string hkszdmc { get; set; }
        public string jtcylist { get; set; }
        public string jtjjqk { get; set; }
        public string njmc { get; set; }
        public string xqh { get; set; }
        public string ygxsj { get; set; }
        public string ywlb { get; set; }

        public SaveStudent_StudentData():base()
        {
            bh = "";
            jtcylist = "";
            jtjjqk = "";
            xqh = "";
            ygxsj = "";
            ywlb = "";
        }
        public void SetValue(Student student)
        {
            #region copy the student value
            this.bnxh = student.bnxh??"";
            this.bz = student.bz??"";
            this.cczt = student.cczt??"";
            this.cjlxm = student.cjlxm??"";
            this.csdm = student.csdm??"";
            this.csrq = student.csrq??"";
            this.cym = student.cym??"";
            this.dzxx = student.dzxx??"";
            this.gatqwm = student.gatqwm??"";
            this.gjdqm = student.gjdqm??"";
            this.grbsm = student.grbsm??"";
            this.gxr = student.gxr??"";
            this.gxsj = student.gxsj??"";
            this.hkszdm = student.hkszdm??"";
            this.hkxzm = student.hkxzm??"";
            this.hyzkm = student.hyzkm??"";
            this.javaClass = student.javaClass??"";
            this.jdfsm = student.jdfsm??"";
            this.jdztm = student.jdztm??"";
            this.jg = student.jg??"";
            this.jkzkm = student.jkzkm??"";
            this.jtzz = student.jtzz??"";
            this.lrr = student.lrr??"";
            this.lrsj = student.lrsj??"";
            this.lxdh = student.lxdh??"";
            this.mzm = student.mzm??"";
            this.rxfsm = student.rxfsm??"";
            this.rxny = student.rxny??"";
            this.sbjdm = student.sbjdm??"";
            this.sfczxcm = student.sfczxcm??"";
            this.sfdsznm = student.sfdsznm??"";
            this.sffqsq = student.sffqsq??"";
            this.sfge = student.sfge??"";
            this.sfgmxwm = student.sfgmxwm??"";
            this.sfjssm = student.sfjssm??"";
            this.sflsetm = student.sflsetm??"";
            this.sflshyfzn = student.sflshyfzn??"";
            this.sfsgxqjym = student.sfsgxqjym??"";
            this.sfsqznm = student.sfsqznm??"";
            this.sftjzscl = student.sftjzscl??"";
            this.sfwlwgryznm = student.sfwlwgryznm??"";
            this.sfxsyb = student.sfxsyb??"";
            this.sfxsybm = student.sfxsybm??"";
            this.sfxsyyc = student.sfxsyyc??"";
            this.sfzjh = student.sfzjh??"";
            this.sfzjlxm = student.sfzjlxm??"";
            this.sfzjyxq = student.sfzjyxq??"";
            this.sfzx = student.sfzx??"";
            this.state = student.state;
            this.sxxfsm = student.sxxfsm??"";
            this.sxxjl = student.sxxjl??"";
            this.tc = student.tc??"";
            this.txdz = student.txdz??"";
            this.xbm = student.xbm??"";
            this.xjfh = student.xjfh??"";
            this.xm = student.xm??"";
            this.xmpy = student.xmpy??"";
            this.xsJbxxId = student.xsJbxxId??"";
            this.xslbm = student.xslbm??"";
            this.xslym = student.xslym??"";
            this.xxBjxxId = student.xxBjxxId??"";
            this.xxJbxxId = student.xxJbxxId??"";
            this.xxm = student.xxm??"";
            this.xxNjxxId = student.xxNjxxId??"";
            this.xxsszgjyxzdm = student.xxsszgjyxzdm??"";
            this.xyzjm = student.xyzjm??"";
            this.xzz = student.xzz??"";
            this.ywxm = student.ywxm??"";
            this.yzbm = student.yzbm??"";
            this.zydz = student.zydz??"";
            this.zzmmm = student.zzmmm??"";
            #endregion
        }

        public void SetValue(Grade grade)
        {
            this.njmc = grade.njmc;
        }

        public void SetValue(Classes _class)
        {
            this.bjmc = _class.bjmc;
        }
        public void SetValue(Grade grade, Classes _class, Student student)
        {
            SetValue(grade);
            SetValue(_class);
            SetValue(student);
        }
    }
}
