using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    class XsRecord : DataRecord
    {
        /// <summary>
        /// 曾用名
        /// </summary>
        public string cym { get; set; }

        public string gxr { get; set; }//1514017",

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
        /// 现住址
        /// </summary>
        public string xzz { get; set; }
        /// <summary>
        /// 户口性质码
        /// </summary>
        public string hkxzm { get; set; }
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
        /// 上下学距离
        /// </summary>
        public string sxxjl { get; set; }
        /// <summary>
        /// 性别码
        /// </summary>
        public string xbm { get; set; }

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
        public string gxsj { get; set; }
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
        public int state { get; set; }
        public string lrr { get; set; }//1529551
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
        /// 是否接受学前教育
        /// </summary>
        public string sfjssm { get; set; }

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
        /// 通信地址
        /// </summary>
        public string txdz { get; set; }
        /// <summary>
        /// 港澳台侨码
        /// </summary>
        public string gatqwm { get; set; }
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
        /// 学校ID
        /// </summary>
        public string xxJbxxId { get; set; }//84C4513D09734F41BD7D3CCBD816E6F6
        /// <summary>
        /// 户口所在地码
        /// </summary>
        public string hkszdm { get; set; }
    }
}
