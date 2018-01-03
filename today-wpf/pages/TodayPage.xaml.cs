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
using today_wpf.dto.request;
using today_wpf.network;
using RestSharp;

namespace today_wpf.pages
{
    /// <summary>
    /// TodayPage.xaml 的交互逻辑
    /// </summary>
    public partial class TodayPage : UserControl
    {
        private TodayResponse tResponse { set; get; }

        public TodayPage()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            this.nameLabel.Content = tResponse.calendarName;
            // this.imageLabel.
            for (int i = 0; i < tResponse.good.Count; i++)
            {
                this.GoodList.Items.Add(new CalendarActivity(tResponse.good[i]));
            }
            for (int i = 0; i < tResponse.bad.Count; i++)
            {
                this.BadList.Items.Add(new CalendarActivity(tResponse.bad[i]));
            }
            for (int i = 0; i < tResponse.recommend.Count; i++)
            {
                this.ItemList.Items.Add(new CalendarItem(tResponse.recommend[i]));
            }
        }

        public async void loadToday(long calendarId)
        {
            GetTodayById request = new GetTodayById(calendarId);
            RestfulClient<TodayResponse> restful = new RestfulClient<TodayResponse>(request);

            TodayResponse rsp = await restful.GetResponse();

            if (rsp != null)
            {
                System.Console.WriteLine(rsp.ToString());
                this.tResponse = rsp;
                refresh();
            }
        }
    }
}
