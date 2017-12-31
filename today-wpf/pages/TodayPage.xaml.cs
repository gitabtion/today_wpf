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
    /// TodayPage.xaml 的交互逻辑
    /// </summary>
    public partial class TodayPage : UserControl
    {
        public TodayPage()
        {
            InitializeComponent();
            CalendarActivity act = new CalendarActivity("打游戏", "ALL Failed");
            CalendarActivity act2 = new CalendarActivity("fff", "ALL Failed");
            this.GoodList.Items.Add(act);
            this.GoodList.Items.Add(act2);
            CalendarActivity bact = new CalendarActivity("使用ie", "你将痛苦无比");
            CalendarActivity bact2 = new CalendarActivity("锻炼身体","不深骨折");
            this.BadList.Items.Add(bact);
            this.BadList.Items.Add(bact2);
            CalendarItem it = new CalendarItem("今日宜吃","汉堡 可乐 炸鸡");
            CalendarItem it2 = new CalendarItem("今日宜饮","果汁 汽水 白开水");
            this.ItemList.Items.Add(it);
            this.ItemList.Items.Add(it2);
        }
    }
}
