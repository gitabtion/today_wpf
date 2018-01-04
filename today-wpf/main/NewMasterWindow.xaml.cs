using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

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
        }

        private void TodayPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SqurePage_Loaded(object sender, RoutedEventArgs e)
        {
            
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
