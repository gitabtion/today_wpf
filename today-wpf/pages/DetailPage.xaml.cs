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
        private List<CommentModel> comment;
        private DetailResponse detailResponse;
        public DetailPage()
        {
            InitializeComponent();

        }

        public async void loadDetail(long calendarId)
        {
            this.calendarId = calendarId;
            GetComment commentRequest = new GetComment(calendarId);
            DetailRequest detailRequest = new DetailRequest(calendarId);
            RestfulClient<DetailResponse> detailRestful = new RestfulClient<DetailResponse>(detailRequest);
            RestfulClient<List<CommentModel>> commentRestful = new RestfulClient<List<CommentModel>>(commentRequest);
            comment = await commentRestful.GetResponse();
            detailResponse = await detailRestful.GetResponse();
            if(comment!=null&&detailResponse!=null)
            {
                System.Console.WriteLine(comment.ToString());
                initUI();
            }
        }
    
        public void initUI()
        {
            for(int i =0;i<comment.Count;i++)
            {
                lv_comment.Items.Add(new CommentItem(comment[i].userName,comment[i].comment,"2018-1-1",""));
            }
            txt_author.Content = detailResponse.creatorName;
            txt_content.Content = detailResponse.description;
            txt_title.Content = detailResponse.title;
        }

        private void btn_subscribe_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_comment_Click(object sender, RoutedEventArgs e)
        {
            if (!edit_content.Text.Equals(""))
            {
                AddCommentRequest request = new AddCommentRequest(calendarId, edit_content.Text);
                RestfulClient<String> detailRestful = new RestfulClient<String>(request);
                System.Console.WriteLine("successcomment");
                lv_comment.Items.Add(new CommentItem("yonghu",edit_content.Text,"2018-2-1",""));
            }
        }
    }
}
