using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDXJ.Lib.Object.AjaxCommand.Send
{
    class ListStudentClass : SendDataClass
    {
        public ListStudentClass()
        {
            JavaClass = "org.loushang.next.data.ParameterSet";
        }

        public ListStudentClass(string schoolId, string classId)
            : this(schoolId, classId, SendSetting.SendDataSetting.QS_start, SendSetting.SendDataSetting.QS_limit, "")
        {
        }

        /// <summary>
        /// 初始化查找学生列表对象
        /// </summary>
        /// <param name="schoolId">学校ID</param>
        /// <param name="classId">班级ID</param>
        /// <param name="start">从第几个学生开始列表</param>
        /// <param name="limit">获取学生的最大数目</param>
        public ListStudentClass(string schoolId, string classId, int start, int limit)
            : this(schoolId, classId, SendSetting.SendDataSetting.QS_start, SendSetting.SendDataSetting.QS_limit, "")
        {
        }

        /// <summary>
        /// 初始化查找学生列表对象
        /// </summary>
        /// <param name="schoolId">学校ID</param>
        /// <param name="classId">班级ID</param>
        /// <param name="start">从第几个学生开始列表</param>
        /// <param name="limit">获取学生的最大数目</param>
        /// <param name="grbsm">全国学籍号</param>
        public ListStudentClass(string schoolId, string classId, int start, int limit, string grbsm)
            : this()
        {
            SetValue(schoolId, classId, grbsm, SendSetting.SendDataSetting.QS_XM, SendSetting.SendDataSetting.QS_SFZJH
                , SendSetting.SendDataSetting.QS_JDFSM, SendSetting.SendDataSetting.QS_RXFSM, SendSetting.SendDataSetting.QS_CCZT, SendSetting.SendDataSetting.QS_SFZX,
                 start, limit, new DefaultSort(), SendSetting.SendDataSetting.QS_dir);
        }

        public void SetValue(string jbId, string bjId, string GRBSM, string XM, string SFZJH, string JDFSM, string RXFSM, string CCZT, string SFZX,
            int start, int limit, DefaultSort defaultSort, string dir)
        {
            AddMapData("XX_JBXX_ID@=", jbId);
            AddMapData("XX_BJXX_ID@=", bjId);
            AddMapData("GRBSM@=", GRBSM);
            AddMapData("XM@LIKE", XM);
            AddMapData("SFZJH@=", SFZJH);
            AddMapData("JDFSM@=", JDFSM);
            AddMapData("RXFSM@=", RXFSM);
            AddMapData("CCZT@=", CCZT);
            AddMapData("SFZX@=", SFZX);
            AddMapData("start", start);
            AddMapData("limit", limit);
            AddMapData("defaultSort", defaultSort);
            AddMapData("dir", dir);
        }
    }

    public class DefaultSort
    {
        public string javaClass { get; set; }
        public List<string> list { get; set; }
        public DefaultSort()
        {
            javaClass = "ArrayList";
            list = new List<string>();
        }
    }
}
