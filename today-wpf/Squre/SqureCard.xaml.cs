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
using today_wpf.dto.response;

namespace today_wpf.Squre
{
    /// <summary>
    /// SqureCard.xaml 的交互逻辑
    /// </summary>
    public partial class SqureCard : UserControl
    {
        public CalendarModel calendar { get; set; }
        public TodayResponse toCalendar { get; set; }
        public SqureCard(CalendarModel calendarModel)
        {
            InitializeComponent();
            calendar = calendarModel;
            this.card_name.Content = calendar.title;
            this.img_calendar.Source = new BitmapImage(new Uri(calendar.picture, UriKind.Absolute));
        }
        public SqureCard(TodayResponse todayResponse)
        {
            InitializeComponent();
            toCalendar = todayResponse;
            this.card_name.Content = toCalendar.calendarName;
            this.img_calendar.Source = new BitmapImage(new Uri(toCalendar.calendarPicture, UriKind.Absolute));
            calendar = new CalendarModel();
            calendar.title = toCalendar.calendarName;
            calendar.isSubcribed = true;
            calendar.picture = toCalendar.calendarPicture;
            calendar.id = toCalendar.calendarId;
        }
    }
}
