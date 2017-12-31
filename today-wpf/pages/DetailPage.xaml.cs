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

namespace today_wpf.pages
{
    /// <summary>
    /// DetailPage.xaml 的交互逻辑
    /// </summary>
    public partial class DetailPage : UserControl
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        private void btn_detail_Click(object sender, RoutedEventArgs e)
        {
            today_page.Visibility = Visibility.Visible;
            comment_page.Visibility = Visibility.Hidden;
        }

        private void btn_comment_Click(object sender, RoutedEventArgs e)
        {
            today_page.Visibility = Visibility.Hidden;
            comment_page.Visibility = Visibility.Visible;
        }
    }
}
