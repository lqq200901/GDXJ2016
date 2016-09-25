using GDXJ2016.ViewModels;
using System.Windows;

namespace GDXJ2016
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainVM = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainVM;
        }
    }
}
