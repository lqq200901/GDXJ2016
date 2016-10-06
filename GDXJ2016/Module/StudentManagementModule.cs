using GDXJ.Lib;
using GDXJ2016.ViewModels;
using GDXJ2016.Views;
using System.Windows.Controls;
using ViewModelLibrary;

namespace GDXJ2016.Module
{
    class StudentManagementModule : ModuleBase
    {
        Gdxj gdxj;
        public StudentManagementModule(Gdxj gdxj)
        {
            this.gdxj = gdxj;
        }

        protected override UserControl CreateViewAndViewModel()
        {
            return new StudentManagementView() { DataContext = new StudentManagementViewModel(gdxj) };
        }

        public override string Name
        {
            get { return "学生管理"; }
        }
    }
}
