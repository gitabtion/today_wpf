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

namespace today_wpf.pages
{
    /// <summary>
    /// CommentItem.xaml 的交互逻辑
    /// </summary>
    public partial class CommentItem : UserControl
    {
        public CommentItem(string name ,string avatar,string content,string data) 
        {

            InitializeComponent();
     
            tv_content.Content = content;
            tv_data .Content= data;
            tv_name.Content = name; 
        }
        public CommentItem()
        {
            InitializeComponent();
        }
    }
}
