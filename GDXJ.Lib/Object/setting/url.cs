using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.setting
{
    public static class url
    {
        public static string domainUrl = @"http://gdxj.edugd.cn";
        public static string indexUrl = domainUrl + @"/jsp/public/login.jsp";
        public static string verificationCodeImageUrl = domainUrl + @"/jsp/public/imagegen.jsp";
        public static string loginCheckUrl = domainUrl + @"/j_bsp_security_check/caLdap";
        public static string mainRUrl = domainUrl + @"/jsp/public/mainR.jsp";
        public static string logoutUrl = domainUrl + @"/logout";

        public static string QueryGradeRefererUrl = domainUrl + @"/jsp/mems/xsxxgl/zxxsxsxjsjwh/zxxsxsxjsjwh_list.jsp";
        public static string ZxxsXxNjxxQueryUrl = domainUrl + @"/command/ajax/com.inspur.mems.xxxxgl.cmd.ZxxsXxNjxxQueryCmd";
        public static string ZxxsXxBjxxQueryUrl = domainUrl + @"/command/ajax/com.inspur.mems.xxxxgl.cmd.ZxxsXxBjxxQueryCmd";
        //获取学生列表Url
        public static string ZxxsXsJbxxQueryUrl = domainUrl + @"/command/ajax/com.inspur.mems.xsxxgl.cmd.ZxxsXsJbxxQueryCmd";
        //获取学生家庭成员列表Url
        public static string GetFamilyMembersUrl = domainUrl + @"/command/ajax/com.inspur.mems.xsxxgl.cmd.ZxxsXsJtcyQueryCmd/queryZs";
        //获取学生经济情况Url
        public static string GetEconomicsUrl = domainUrl + @"/command/ajax/com.inspur.mems.xsxxgl.cmd.ZxxsXsJtjjqkQueryCmd/queryZs";

        //获取学生照片
        public static string GetPhotoUrl = domainUrl + @"/command/ajax/com.inspur.mems.xsxxgl.cmd.ZxxsXsPicCmd/queryPhotoPath";

        //保存学生数据Url
        public static string SaveStudentInfoUrl = domainUrl + @"/command/ajax/com.inspur.mems.xsxxgl.cmd.ZxxsXsJbxxCmd/save";

        //获致地址码对应名称Url
        public static string GetRegionNameUrl = domainUrl + @"/command/ajax/com.inspur.comm.dicm.cmd.DicMemsDetailsCmd/getForGeneralDic ";

        //获取字典Url
        public static string QueryForDicUrl = domainUrl + @"/command/ajax/com.inspur.comm.dicm.cmd.DicMemsDetailsQueryCmd/queryForDic";
        public static string QuerySchoolInfoUrl = domainUrl + @"/command/ajax/com.inspur.mems.xxxxgl.cmd.ZxxsXxJbxxQueryCmd/queryForDetail";
        public static string QueryGeneralDicUrl = domainUrl + @"/command/ajax/com.inspur.comm.dicm.cmd.DicMemsDetailsQueryCmd/queryForGeneralDic";
        public static string QueryOrganDicUrl = domainUrl + @"/command/ajax/com.inspur.comm.dicm.cmd.DicMemsDetailsCmd/getForGeneralDic";
    }
}
