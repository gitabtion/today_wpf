using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using today_wpf.model;
using today_wpf.network;

namespace today_wpf.custom
{
    /// <summary>
    /// userInfo.xaml 的交互逻辑
    /// </summary>
    public partial class userInfo : UserControl
    {

        private Stream stream;
        private UserLoginResponse user;
        private List<TodayResponse> created;
        public NewMasterWindow window{get;set;}
        public  userInfo()
        {
            InitializeComponent();

            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream("./user.me", FileMode.Open, FileAccess.Read, FileShare.Read);
            this.user = (UserLoginResponse)formatter.Deserialize(stream);
            stream.Close();
            head.Source = new BitmapImage(new Uri(user.user.avatar, UriKind.Absolute));

            userName.Content = user.user.name;
            if(user.user.signature != null)
                 signature.Content = user.user.signature;

            getCreated();

          


        }


        private async void getCreated()
        {
            RestfulClient<List<TodayResponse>> restful = new RestfulClient<List<TodayResponse>>("/custom/created");

            this.created = await restful.GetResponse();

            createCount.Content = this.created.Count;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.window.userInfo.Visibility = Visibility.Hidden;
            this.window.edit.Visibility = Visibility.Visible;
        }

       
    }
}
