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
using today_wpf.model;

namespace today_wpf.pages
{
    /// <summary>
    /// CalendarActivity.xaml 的交互逻辑
    /// </summary>
    public partial class CalendarActivity : UserControl
    {
        public CalendarActivity(Activity activity)
        {
            InitializeComponent();
            this.activityName.Content = activity.title;
            this.activityDtail.Content = activity.description;
        }

        public CalendarActivity()
        {
            InitializeComponent();
        }
    }
}
