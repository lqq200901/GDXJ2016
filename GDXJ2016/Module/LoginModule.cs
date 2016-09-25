using GDXJ.Lib;
using GDXJ2016.ViewModels;
using GDXJ2016.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ViewModelLibrary;

namespace OA.CCJY.Module
{
    class LoginModule : ModuleBase
    {
        Gdxj gdxj;
        public LoginModule(Gdxj gdxj)
        {
            this.gdxj = gdxj;
        }

        protected override UserControl CreateViewAndViewModel()
        {
            return new LoginView() { DataContext = new LoginViewModel(gdxj) };
        }

        public override string Name
        {
            get { return "登录系统"; }
        }
    }
}
