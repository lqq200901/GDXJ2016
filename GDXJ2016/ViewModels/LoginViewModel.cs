using System;
using System.Windows.Media.Imaging;
using System.Windows;
using ViewModelLibrary;
using System.Windows.Controls;
using GDXJ.Lib;
using System.Windows.Media;

namespace GDXJ2016.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Gdxj gdxj;

        #region ����
        public DelegateCommand VerificationCodeImageRefresh { get; private set; }
        public DelegateCommand LoginCommand { get; private set; }
        #endregion

        #region ��¼��Ϣ
        bool isChange = false;
        string username = string.Empty;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    if (!isChange) Password = "";
                    username = value;
                    OnPropertyChanged("username");
                }
            }
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                if (!isChange) isChange = true;
                if (password.Length > 0) LoginCommand.IsEnabled = true;
                OnPropertyChanged("Password");
            }
        }

        string verificationCode = string.Empty;
        public string VerificationCode
        {
            get { return verificationCode; }
            set
            {
                verificationCode = value;
                if (!isChange) isChange = true;
                if (verificationCode.Length > 0) LoginCommand.IsEnabled = true;
                OnPropertyChanged("VerificationCode");
            }
        }

        public ImageSource VerificationCodeImage
        {
            get
            {
                return gdxj.Login.VerificationCodeImage;
            }

            set { OnPropertyChanged("VerificationCodeImage"); }
        }

        private bool savePassword = false;
        public bool SavePassword
        {
            get { return savePassword; }
            set { savePassword = value; OnPropertyChanged("CheckCode"); }
        }

        string loginInfo = string.Empty;
        public string LoginInfo
        {
            get { return loginInfo; }
            set
            {
                loginInfo = value;
                OnPropertyChanged("LoginInfo");
            }
        }

        #endregion

        public LoginViewModel(Gdxj gdxj)
        {
            this.gdxj = gdxj;

            VerificationCodeImageRefresh = new DelegateCommand(() => { this.gdxj.Login.VerificationCodeImageRefresh(); });
            LoginCommand = new DelegateCommand(() =>
            {
                if (Username.Length < 1)
                {
                    LoginInfo = "�����˺Ų���Ϊ�գ�"; return;
                }
                gdxj.Login.Username = Username;
                gdxj.Login.Password = Password;
                gdxj.Login.VerificationCode = VerificationCode;
                gdxj.Login.Login();
            }) { IsEnabled = false };

            Username = "linqingqiang3416";
            Password = "12345678";

            gdxj.Login.Subscribe(Login);
        }

        private void Login(object sender, GDXJ.Lib.GDXJEvens.GDXJEvenArgs e)
        {
            if (e.ResultToRaiseEvent ==1)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //VerificationCodeImage = new BitmapImage();
                }));    
            }
            else if (e.ResultToRaiseEvent == 0)
            {
                LoginInfo = "";
            }
            else if (e.ResultToRaiseEvent < -1)
            {
                LoginInfo = "�������Ӱ칫ϵͳʧ�ܣ�\n"+e.MessageToRaiseEvent;
            }else if (e.ResultToRaiseEvent == -1)
            {
                LoginInfo = "����ϵͳ��ʼ��ʧ�ܣ�\n";
            }

        }
    }
}