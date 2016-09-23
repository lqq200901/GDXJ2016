using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Receive
{
    public class ReceiveSchoolInfoClass //: IReceiveDataClass
    {
        public string javaClass { get; set; }
        public bool success { get; set; }
        public Receive.MetaData metaData { get; set; }
        public List<SchoolInfo> rows { get; set; }
    }

    public class SchoolInfo
    {
        public string bgdh { get; set; }
        public string czdh { get; set; }
        public string czrxnl { get; set; }
        public string czxz { get; set; }
        public string dlszssmzxxdm { get; set; }
        public string dwdzxx { get; set; }
        public string fddbr { get; set; }
        public string frdjzh { get; set; }
        public string fsgxxxbs { get; set; }
        public string fzjxyydm { get; set; }
        public string gxr { get; set; }
        public string gxsj { get; set; }
        public string gzrxnl { get; set; }
        public string gzxz { get; set; }
        public string hbgd { get; set; }
        public string javaClass { get; set; }
        public string jszxsdm { get; set; }
        public string jxnf { get; set; }
        public string lrr { get; set; }
        public string lrsj { get; set; }
        public string lsyg { get; set; }
        public string permitorgan { get; set; }
        public string rownum { get; set; }
        public string sdgljyxzdm { get; set; }
        public string sdgljyxzmc { get; set; }
        public string sfzxxbz { get; set; }
        public string sjlybzm { get; set; }
        public string sszgdwm { get; set; }
        public string sszgjyxzdm { get; set; }
        public string sszgjyxzmc { get; set; }
        public string sszxxId { get; set; }
        public string state { get; set; }
        public string szddysxdm { get; set; }
        public string szdjjsxdm { get; set; }
        public string szdmzsxdm { get; set; }
        public string tbryx { get; set; }
        public string tdzh { get; set; }
        public string wzzydz { get; set; }
        public string xqr { get; set; }
        public string xxbsm { get; set; }
        public string xxbxlxdm { get; set; }
        public string xxdz { get; set; }
        public string xxdzdm { get; set; }
        public string xxJbxxId { get; set; }
        public string xxjbzdm { get; set; }
        public string xxjd { get; set; }
        public string xxmc { get; set; }
        public string xxrxnl { get; set; }
        public string xxtdcq { get; set; }
        public string xxwd { get; set; }
        public string xxxz { get; set; }
        public string xxywmc { get; set; }
        public string xxzdcxlxdm { get; set; }
        public string xxztm { get; set; }
        public string xymym { get; set; }
        public string xzsjhm { get; set; }
        public string xzxm { get; set; }
        public string yzbm { get; set; }
        public string zjxyydm { get; set; }
        public string zsbj { get; set; }
        public string zzjgdm { get; set; }
    }
}
