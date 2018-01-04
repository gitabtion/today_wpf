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
using today_wpf.dto.request;
using today_wpf.dto.response;
using today_wpf.network;

namespace today_wpf.custom
{
    /// <summary>
    /// register.xaml 的交互逻辑
    /// </summary>
    public partial class register : UserControl
    {
        public register()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
          
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(userpassword.Password != passwordConfirm.Password)
            {
                MainWindow mainWindow = MainWindow.GetInstance();
                mainWindow.notifyIcon.BalloonTipTitle = Env.PROJECT_NAME;
                mainWindow.notifyIcon.BalloonTipText = "两次密码输入不一致";
                mainWindow.notifyIcon.ShowBalloonTip(1);
            }
            else
            {
                UserRegisterRequest userRegister = new UserRegisterRequest(userName.Text,userpassword.Password,signature.Text);
                RestfulClient<string> restfulClient = new RestfulClient<string>(userRegister);
                string userId = await restfulClient.GetResponse();
                if (userId != null)
                {
                    MainWindow mainWindow = MainWindow.GetInstance();

                    mainWindow.notifyIcon.BalloonTipTitle = Env.PROJECT_NAME;
                    mainWindow.notifyIcon.BalloonTipText = "注册成功";
                    mainWindow.notifyIcon.ShowBalloonTip(1);
                    UserMain.GetInstance().Close();
                    MainWindow.GetInstance().Show();
                }
                
            }
        }
    }
}
