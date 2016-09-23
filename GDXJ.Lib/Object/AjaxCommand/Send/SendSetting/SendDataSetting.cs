using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send.SendSetting
{
    class SendDataSetting
    {
        #region 获取年级信息参数
        public static string QueryGrade_NJZT="1";
        public static string QueryGrade_sort="JYJD, RXNF";
        public static string QueryGrade_dir = "DESC";
        #endregion

        #region 获取班级信息参数
        public static string QueryClass_YXBZ="1";
        public static string QueryClass_sort = "bh";
        #endregion
        
        #region 获取学生信息参数
        public static string QS_GRBSM = "";
        public static string QS_XM = "";
        public static string QS_SFZJH = "";
        public static string QS_JDFSM = "";
        public static string QS_RXFSM = "";
        public static string QS_CCZT = "";
        public static string QS_SFZX = "";
        public static int QS_start = 0;
        public static int QS_limit = 20;
        public static string QS_defaultSort = @"{""javaClass"": ""ArrayList"",""list"": []}";
        public static string QS_dir = "ASC";
        #endregion

        #region 获取字典信息参数
        /// <summary>
        /// 获取班级码
        /// </summary>
        public static string ClassID = "ZD_BBX_BJXX";
        /// <summary>
        /// 获取国籍码
        /// </summary>
        public static string CountryID = "ZD_GB_GJDQM";
        /// <summary>
        /// 获取证件类型的命令字串
        /// </summary>
        public static string CertificateType = "ZD_BB_SFZJLXM";
        /// <summary>
        /// 获取港澳台外的命令字串
        /// </summary>
        public static string GATQ = "ZD_BB_GATQWM";
        /// <summary>
        /// 获取健康状况的命令字串
        /// </summary>
        public static string ZXSKJ = "ZD_XJ_ZXSKJ";
        /// <summary>
        /// 获取户口性质的命令字串
        /// </summary>
        public static string HKXZ = "ZD_BB_HKXZ";
        /// <summary>
        /// 获取是或否代码的命令字串
        /// </summary>
        public static string YesOrNo = "ZD_BB_YESORNO";
        /// <summary>
        /// 获取留守儿童代码的命令字串
        /// </summary>
        public static string LSET = "ZD_BB_SFLSETM";
        /// <summary>
        /// 获取性别代码的命令字串
        /// </summary>
        public static string XB = "ZD_GB_XBM";
        /// <summary>
        /// 获取民族的命令字串
        /// </summary>
        public static string MZ = "ZD_GB_MZM";
        #endregion
    }
}
