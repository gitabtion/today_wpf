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
        private CreatedResponse created;
        public  userInfo()
        {
            InitializeComponent();

            IFormatter formatter = new BinaryFormatter();
            this.stream = new FileStream("./user.me", FileMode.Open, FileAccess.Read, FileShare.Read);
            this.user = (UserLoginResponse)formatter.Deserialize(stream);
            stream.Close();
            head.Source = new BitmapImage(new Uri(user.user.avatar, UriKind.Relative));

            userName.Content = user.user.name;
            signature.Content = user.user.signature;

            getCreated();

            createCount.Content = this.created.createdList.Count;


        }


        private async void getCreated()
        {
            RestfulClient<CreatedResponse> restful = new RestfulClient<CreatedResponse>("/custom/created");

            this.created = await restful.GetResponse();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
