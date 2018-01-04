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

namespace today_wpf.Squre
{
    /// <summary>
    /// SqureCard.xaml 的交互逻辑
    /// </summary>
    public partial class SqureCard : UserControl
    {
        public CalendarModel calendar { get; set; }
        public SqureCard(CalendarModel calendarModel)
        {
            InitializeComponent();
            calendar = calendarModel;
            this.card_name.Content = calendar.title;
            this.img_calendar.Source = new BitmapImage(new Uri(calendar.picture, UriKind.Absolute));
        }
    }
}
