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
            today_page.Visibility = Visibility.Visible;
            detail_page.Visibility = Visibility.Hidden;
        }

        private void todayButton_Click(object sender, RoutedEventArgs e)
        {
            detail_page.Visibility = Visibility.Hidden;
            today_page.Visibility = Visibility.Visible;
            this.today_page.loadTodayList();
        }

        private void piazzaButton_Click(object sender, RoutedEventArgs e)
        {
            detail_page.loadDetail(1,true);
            today_page.Visibility = Visibility.Hidden;
            detail_page.Visibility = Visibility.Visible;
        }
    }
}
