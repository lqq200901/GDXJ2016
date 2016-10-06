using GDXJ.Lib;
using GDXJ2016.Module;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModelLibrary;

namespace GDXJ2016.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private List<IModule> Models = new List<IModule>();
        private Gdxj gdxj;
        

        #region 命令
        public DelegateCommand SetupCommand { get; private set; }
        public DelegateCommand AllCommand { get; private set; }
        public DelegateCommand MailCommand { get; private set; }
        public DelegateCommand DocumentCommand { get; private set; }
        public DelegateCommand DeliveryCommand { get; private set; }
        public DelegateCommand LoginCommand { get; private set; }
        #endregion


        private int selectedModuleNumber = 0;
        public int SelectedModuleNumber
        {
            get { return selectedModuleNumber; }
            set { selectedModuleNumber = value; OnPropertyChanged("UserInterface"); }
        }

        public string Title
        {
            get
            {
                return Models[selectedModuleNumber].Name;
            }
        }

        public UserControl UserInterface
        {
            get
            {
                return Models[selectedModuleNumber].UserInterface;
            }
        }

        public MainViewModel()
        {
            try
            {
                gdxj = new Gdxj();

                Initialization();

                #region 初始化文件夹

                #endregion

                LoginCommand = new DelegateCommand(() => SelectedModuleNumber = 0) { IsEnabled = false };
                AllCommand = new DelegateCommand(() => SelectedModuleNumber = 1) { IsEnabled = false };
                MailCommand = new DelegateCommand(() => SelectedModuleNumber = 2) { IsEnabled = false };
                DocumentCommand = new DelegateCommand(() => SelectedModuleNumber = 3) { IsEnabled = false };
                DeliveryCommand = new DelegateCommand(() => SelectedModuleNumber = 4) { IsEnabled = false };
                SetupCommand = new DelegateCommand(() => SelectedModuleNumber = 5) { IsEnabled = true };

                Models.Add(new LoginModule(gdxj));
                Models.Add(new StudentManagementModule(gdxj));
                //Models.Add(new MailModule(ccoa));
                //Models.Add(new NewMailBoxModule(ccoa));
                //Models.Add(new DepartmentSetupModule(ccoa));
                //Models.Add(new PrintTaskListModule(ccoa));
                //Models.Add(new SetupModule(ccoa));

                //ccoa.Subscribe(Login);
            }
            catch (Exception e)
            {
                if (gdxj != null)
                    gdxj.Login.Logout();
                MessageBox.Show("系统初始化失败\n"+e.Message,"系统运行错误",MessageBoxButton.OK,MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

        }

        private bool Initialization()
        {
            bool result = true;
            try
            {
                //ccoa.AttachSavePath = System.IO.Directory.GetCurrentDirectory() + Setting.System.GetSystemSetting("AttachSavePath");
                //ccoa.AttachTempPath = System.IO.Directory.GetCurrentDirectory() + Setting.System.GetSystemSetting("AttachTempPath");
                //System.IO.Directory.CreateDirectory(ccoa.AttachSavePath);
                //System.IO.Directory.CreateDirectory(ccoa.AttachTempPath);
                gdxj.Subscribe(Login);
            }
            catch(Exception e)
            {
                result = false;
                throw (e);
            }
            return result;
        }

        private void Login(object sender, GDXJEvens.GDXJEvenArgs e)
        {
            if (e.ResultToRaiseEvent == 0)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    SetupCommand.IsEnabled = true;
                    AllCommand.IsEnabled = true;
                    MailCommand.IsEnabled = true;
                    DocumentCommand.IsEnabled = true;
                    DeliveryCommand.IsEnabled = true;
                    LoginCommand.IsEnabled = true;
                    SelectedModuleNumber = 1;
                }), null);
            }
        }
    }
}
