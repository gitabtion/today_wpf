using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace today_wpf.custom
{
    /// <summary>
    /// UserMain.xaml 的交互逻辑
    /// </summary>
    public partial class UserMain : MetroWindow
    {

        private static UserMain singleInstance;


        //界面被初始化才能显示
        
        private static readonly object locker = new object();
        public static UserMain GetInstance()
        {

            if (singleInstance == null)
            {
                lock (locker)
                {

                    if (singleInstance == null)
                    {
                        singleInstance = new UserMain();
                    }
                }
            }
            return singleInstance;
        }
        public UserMain()
        {
            InitializeComponent();
            singleInstance = this;
        }


        // 窗体关闭后
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
            MainWindow main = MainWindow.GetInstance();
            main.Show();
        }

     
    }
}
