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
using MahApps.Metro.Controls;

namespace today_wpf.main
{
    /// <summary>
    /// MasterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MasterWindow : MetroWindow
    {
        public MasterWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.today_page.loadToday(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            detail_page.loadDetail(1);
            detail_page.Visibility = Visibility.Visible;
            today_page.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void TodayPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
