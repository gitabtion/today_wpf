using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using today_wpf.dto.response;
using today_wpf.network;
using today_wpf.Squre;

namespace today_wpf.main
{
    /// <summary>
    /// NewMasterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewMasterWindow : MetroWindow
    {
        public NewMasterWindow()
        {
            InitializeComponent();
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("./user.me", FileMode.Open, FileAccess.Read, FileShare.Read);
            var user = (UserLoginResponse)formatter.Deserialize(stream);
            stream.Close();
            
            
        }

        private void TodayPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        

        private void squreTab_Loaded(object sender, RoutedEventArgs e)
        {
            squrePage.window = this;
            squrePage.Visibility = Visibility.Visible;
            detailPage.Visibility = Visibility.Hidden;
        }

        private void header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            subPage.window = this;
            subPage.Visibility = Visibility.Visible;
            subDetailPage.Visibility = Visibility.Hidden;
        }
        // 窗体关闭后
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
            MainWindow main = MainWindow.GetInstance();
            main.Close();
        }
    }
}
