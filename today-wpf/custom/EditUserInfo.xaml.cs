using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using today_wpf.main;

namespace today_wpf.custom
{
    /// <summary>
    /// EditUserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class EditUserInfo : UserControl
    {
        public NewMasterWindow window {get;set;}
        public EditUserInfo()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.window.edit.Visibility = Visibility.Hidden;
            MainWindow mainWindow = MainWindow.GetInstance();


            mainWindow.notifyIcon.BalloonTipTitle =Env.PROJECT_NAME;
            mainWindow.notifyIcon.BalloonTipText = "个人信息修改成功";
            mainWindow.notifyIcon.ShowBalloonTip(1);
            this.window.userInfo.Visibility = Visibility.Visible;
        }
    }
}
