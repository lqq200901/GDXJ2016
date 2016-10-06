using GDXJ.Lib;
using GDXJ.Lib.Object;
using QQLib.Collection;
using System;
using System.Threading;
using ViewModelLibrary;

namespace GDXJ2016.ViewModels
{
    class StudentManagementViewModel : ViewModelBase
    {
        private Gdxj gdxj;

        public AsyncObservableCollection<TreeObject> Members { get; set; }
        public AsyncObservableCollection<Student> SelectMembers { get; set; }

        public StudentManagementViewModel(Gdxj gdxj)
        {
            this.gdxj = gdxj;

            Thread t = new Thread(BuildObjectTree) { IsBackground = true };
            t.Start();
        }

        private void RefreshSelectMembers()
        {
            if (SelectMembers == null)
                SelectMembers = new AsyncObservableCollection<Student>();
            else
                SelectMembers.Clear();

            foreach (var m in Members)
            {
                if (m.Checked)
                    if (m.RollObject.GetType() == typeof(Student))
                    {
                        ((Student)m.RollObject).GetFamilyMembers(ref gdxj.GdxjCookie.cookie);
                        ((Student)m.RollObject).GetPhoto(ref gdxj.GdxjCookie.cookie);
                        ((Student)m.RollObject).hkszd = GDXJ.Lib.Object.setting.Dict.GetOrganName(gdxj, new GDXJ.Lib.Object.AjaxCommand.Send.GetOrganDictClass(((Student)m.RollObject).hkszdm));
                        SelectMembers.Add((Student)m.RollObject);
                    }
            }
        }

        /// <summary>
        /// 创建学生信息的树状数据结构
        /// </summary>
        private void BuildObjectTree()
        {
            if (Members == null)
                Members = new AsyncObservableCollection<TreeObject>();

            try
            {
                gdxj.QueryGrade().ForEach(g =>
                {
                    Members.Add(new TreeObject { RollObject = g });
                    g.QueryClasses(ref gdxj.GdxjCookie.cookie).ForEach(c =>
                    {
                        Members.Add(new TreeObject { RollObject = c });
                        c.QueryStudent(ref gdxj.GdxjCookie.cookie).ForEach(s =>
                        {
                            Members.Add(new TreeObject { RollObject = s });
                        });
                    });
                });

            }
            catch (System.Exception e)
            {
                throw (e);
            }
        }
    }
}
