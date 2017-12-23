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
using MahApps.Metro.Controls;
using RestSharp;
using today_wpf.dto.request;
using today_wpf.dto.response;
using today_wpf.network;

namespace today_wpf
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserLoginRequest userLoginRequest = new UserLoginRequest(txtUserName.Text, txtPassword.Password);
            RestfulClient<UserLoginResponse> restful = new RestfulClient<UserLoginResponse>(userLoginRequest);
            restful.Send();
            UserLoginResponse response = restful.GetResponse();

            if (response != null)
                Console.WriteLine(response.token);

            RestfulClient<CalendarDetailResponse> restfulGet = new RestfulClient<CalendarDetailResponse>("/calendar/{calendarId}/detail");

            restfulGet.AddUrlSegment("calendarId",3);
           
            restfulGet.Send();

            CalendarDetailResponse calendarDetail = restfulGet.GetResponse();
            if (calendarDetail != null)
                Console.WriteLine(calendarDetail.creatorName);

        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();

            window.Source = new Uri("Register.xaml", UriKind.Relative);

            window.Show();
        }
    }
}