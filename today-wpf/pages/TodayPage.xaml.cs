﻿using System;
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
  
        }
    }
}
