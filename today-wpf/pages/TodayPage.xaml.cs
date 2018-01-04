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

        private List<TodayResponse> tList { set; get; }

        private int currentIndex;

        public TodayPage()
        {
            InitializeComponent();
            currentIndex = 0;
            tList = new List<TodayResponse>();
            // 加载页面时预加载，如果没有就不刷新页面
            this.loadTodayList();
            if (tList.Count > 0)
            {
                refresh();
            }
            
        }

        public void clear()
        {
            this.GoodList.Items.Clear();
            this.BadList.Items.Clear();
            this.ItemList.Items.Clear();
        }

        public void refresh()
        {
    
            tResponse = tList[currentIndex];

            this.dateLabel.Content = DateTime.Now.ToString("yyyy-MM-dd");
            this.nameLabel.Content = tResponse.calendarName;
            this.imageLabel.Source = new BitmapImage(new Uri(tResponse.calendarPicture, UriKind.Absolute));
            clear();

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
            // 单个黄历信息的请求

            GetTodayById request = new GetTodayById(calendarId);
            RestfulClient<TodayResponse> restful = new RestfulClient<TodayResponse>(request);

            TodayResponse rsp = await restful.GetResponse();

            if (rsp != null)
            {
                this.tResponse = rsp;
                refresh();
            }
        }

        public async void loadTodayList()
        {
            // 列表的请求

            GetSubscribedToday request = new GetSubscribedToday();
            RestfulClient<List<TodayResponse>> restful = new RestfulClient<List<TodayResponse>>(request);

            List<TodayResponse> rsp = await restful.GetResponse();

            if (rsp != null)
            {
                this.tList = rsp;
                refresh();
            }
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex >= 1)
            {
                currentIndex--;
                refresh();
            }
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex < this.tList.Count - 1)
            {
                currentIndex++;
                refresh();
            }
        }
    }
}
