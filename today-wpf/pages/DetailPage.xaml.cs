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
using today_wpf.model;
namespace today_wpf.pages
{
    /// <summary>
    /// DetailPage.xaml 的交互逻辑
    /// </summary>
    public partial class DetailPage : UserControl
    {
        private long calendarId;
        private bool isSubscribe;
        private List<CommentModel> comment;
        private DetailResponse detailResponse;
        public DetailPage()
        {
            InitializeComponent();
        }

        public async void loadDetail(long calendarId,bool isSubscribe)
        {
            this.isSubscribe = isSubscribe;
            if(isSubscribe)
            {
                btn_subscribe.Content = "已订阅";
            }
            else
            {
                btn_subscribe.Content = "未订阅";
            }
            this.calendarId = calendarId;
            initCommentViewAsync();
            initDetailView();
          
    
        }
    
        private async Task initCommentViewAsync()
        {
            GetComment commentRequest = new GetComment(calendarId);
            RestfulClient<List<CommentModel>> commentRestful = new RestfulClient<List<CommentModel>>(commentRequest);
            comment = await commentRestful.GetResponse();
            lv_comment.Items.Clear();
            for (int i = 0; i < comment.Count; i++)
            {
                lv_comment.Items.Add(new CommentItem(comment[i].userName, comment[i].comment, "2018-1-1", comment[i].userAvatar));
            }
        }

        private async Task initDetailView()
        {
            DetailRequest detailRequest = new DetailRequest(calendarId);
            RestfulClient<DetailResponse> detailRestful = new RestfulClient<DetailResponse>(detailRequest);
            detailResponse = await detailRestful.GetResponse();
            this.img_picture.Source = new BitmapImage(new Uri(detailResponse.picture, UriKind.Absolute));
            txt_author.Content = detailResponse.creatorName;
            txt_content.Content = detailResponse.description;
            txt_title.Content = detailResponse.title;
        }
        private void btn_subscribe_Click(object sender, RoutedEventArgs e)
        {
            if(btn_subscribe.Content.ToString() == "未订阅")
            {
                SubscribeRequest subscribeRequest = new SubscribeRequest(calendarId);
                RestfulClient<String> request = new RestfulClient<String>(subscribeRequest);
                request.GetResponse();
                btn_subscribe.Content = "已订阅";
            }
            else
            {
              UnsubscribeReques unsubscribeRequest = new UnsubscribeReques(calendarId);
              RestfulClient<String> request = new RestfulClient<String>(unsubscribeRequest);
              request.GetResponse();
              btn_subscribe.Content = "未订阅";

            }
        }

        private void btn_comment_Click(object sender, RoutedEventArgs e)
        {
            if (!edit_content.Text.Equals(""))
            {
                AddCommentRequest request = new AddCommentRequest(calendarId, edit_content.Text);
                RestfulClient<String> detailRestful = new RestfulClient<String>(request);
                detailRestful.GetResponse();
                initCommentViewAsync();
            }
        }
    }
}
