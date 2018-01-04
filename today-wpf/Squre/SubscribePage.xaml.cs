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
using today_wpf.main;
using today_wpf.network;

namespace today_wpf.Squre
{
    /// <summary>
    /// SubscribePage.xaml 的交互逻辑
    /// </summary>
    public partial class SubscribePage : UserControl
    {
        public List<TodayResponse> subscribeListData;
        public NewMasterWindow window;
        public SubscribePage()
        {
            InitializeComponent();
            loadDataAsync();
        }

        private void subscribeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqureCard squre = subscribeList.SelectedItem as SqureCard;

            window.subDetailPage.loadDetail(squre.calendar.id, squre.calendar.isSubcribed);

            this.Visibility = Visibility.Hidden;
            window.subDetailPage.Visibility = Visibility.Visible;
        }

        private async void loadDataAsync()
        {
            RestfulClient<List<TodayResponse>> subListRest = new RestfulClient<List<TodayResponse>>("/calendar/subscribed");
            subListRest.AddParameter("size", "500");

            
            this.subscribeListData = await subListRest.GetResponse();
            Console.WriteLine(subscribeListData.Count);
            for (int i = 0; i < this.subscribeListData.Count; i++)
            {
                if (subscribeListData[i].calendarPicture != null)
                {
                    this.subscribeList.Items.Add(new SqureCard(subscribeListData[i]));

                }
            }

            
        }
    }
}
