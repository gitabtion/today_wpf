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
    /// SqurePage.xaml 的交互逻辑
    /// </summary>
    public partial class SqurePage : UserControl
    {
        public SqurePage()
        {
            InitializeComponent();
            CalendarModel calendarModel1 = new CalendarModel();
            calendarModel1.id = 0;
            calendarModel1.name = "test";
            calendarModel1.uri = "/resource/head.jpg";
            SqureCard squreCard = new SqureCard(calendarModel1);
            SqureCard squreCard2 = new SqureCard(calendarModel1);
            SqureCard squreCard3 = new SqureCard(calendarModel1);
            SqureCard squreCard4 = new SqureCard(calendarModel1);
            SqureCard squreCard5 = new SqureCard(calendarModel1);
            this.recommendList.Items.Add(squreCard);
            this.recommendList.Items.Add(squreCard2);
            this.recommendList.Items.Add(squreCard3);
            this.recommendList.Items.Add(squreCard4);
            this.recommendList.Items.Add(squreCard5);

            for (int i = 0; i < 20; i++)
            {
                this.allList.Items.Add(new SqureCard(calendarModel1));
            }

        }

        private void recommendList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqureCard squre = recommendList.SelectedItem as SqureCard;
            Console.WriteLine(squre.calendar.name);
        }

        private void allList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqureCard squre = recommendList.SelectedItem as SqureCard;
        }
    }
}
