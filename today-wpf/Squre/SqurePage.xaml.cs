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
using today_wpf.network;

namespace today_wpf.Squre
{
    /// <summary>
    /// SqurePage.xaml 的交互逻辑
    /// </summary>
    public partial class SqurePage : UserControl
    {
        public List<CalendarModel> recommendListData { get; set; }
        public List<CalendarModel> allListData { get; set; }
        public SqurePage()
        {
            InitializeComponent();
            loadDataAsync();

            

        }

        private void recommendList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqureCard squre = recommendList.SelectedItem as SqureCard;
            Console.WriteLine(squre.calendar.title);
        }

        private void allList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqureCard squre = recommendList.SelectedItem as SqureCard;
        }
        private async void loadDataAsync()
        {
            RestfulClient<List<CalendarModel>> recommendListRest = new RestfulClient<List<CalendarModel>>("/piazza/most-subscribed");
            recommendListRest.AddParameter("size", "500");
            RestfulClient<List<CalendarModel>> allListRest = new RestfulClient<List<CalendarModel>>("/piazza/all");
            allListRest.AddParameter("size", "500");
            this.recommendListData = await recommendListRest.GetResponse();
            this.allListData = await allListRest.GetResponse();
            Console.Write("ended");

            Console.Write(allListData[0]);
            for (int i = 0; i < this.recommendListData.Count; i++)
            {
                this.recommendList.Items.Add(new SqureCard(recommendListData[i]));
            }

            for (int i = 0; i < this.allListData.Count; i++)
            {
                this.allList.Items.Add(new SqureCard(allListData[i]));
            }
        }
    }
}
