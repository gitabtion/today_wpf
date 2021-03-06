﻿using System;
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
using MahApps.Metro.Controls;
using RestSharp;
using today_wpf.custom;
using today_wpf.dto.request;
using today_wpf.dto.response;
using today_wpf.main;
using today_wpf.network;
namespace today_wpf
{
    public partial class MainWindow : MetroWindow
    {
        private static MainWindow singleInstance;


        //界面被初始化才能显示
        public MainWindow()
        {
            InitNotfyIconMenu();
            InitializeComponent();
            singleInstance = this;
        }
        private static readonly object locker = new object();
        public static MainWindow GetInstance()
        {
            
            if (singleInstance == null)
            {
                lock (locker)
                {
                   
                    if (singleInstance == null)
                    {
                        singleInstance = new MainWindow();
                    }
                }
            }
            return singleInstance;
        }
        public System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitNotfyIconMenu();
            ShowSystemNotice("Today", "你的专属日历", 1);
            ShowSystemNotice("Today", "程序信息初始化完成", 1);
        }

        private void InitNotfyIconMenu()
        {

            System.Windows.Forms.ContextMenuStrip contextMenu = new System.Windows.Forms.ContextMenuStrip();

            var menuArrs = new string[] { "打开主界面", "-", "关于", "-", "退出" };

            for (int i = 0; i < menuArrs.Length; i++)
            {
                string item = menuArrs[i];
                if (item != "-")
                {
                    System.Windows.Forms.ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem();
                    menuItem.Text = menuArrs[i];
                    menuItem.Click += menuItem_Click;

                    contextMenu.Items.Add(menuItem);
                }
                else
                {
                    contextMenu.Items.Add("-");
                }
            }
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.Text = "你的专属日历";
            notifyIcon.Icon = Properties.Resources.calendar;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            notifyIcon.Visible = true;
        }

        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowMain();
            }
        }
        // 窗体状态发生改变后
        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem menuItem = sender as System.Windows.Forms.ToolStripMenuItem;

            switch (menuItem.Text)
            {
                case "打开主界面":
                    ShowMain();
                    break;
                case "关于":
                    ShowMain();
                   
                    break;
                case "退出":
                    ShowMain();
                    this.Close();
                    break;
            }
        }

        private void ShowMain()
        {
            this.Show();

            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }

            this.Topmost = true;
        }

        private void ShowSystemNotice(string title, string content, int timeOut)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = content;
            notifyIcon.ShowBalloonTip(timeOut);
        }
      
     

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserLoginRequest userLoginRequest = new UserLoginRequest(txtUserName.Text, txtPassword.Password);
            RestfulClient<UserLoginResponse> restful = new RestfulClient<UserLoginResponse>(userLoginRequest);
            
            UserLoginResponse response =await restful.GetResponse();
            
            if (response != null)
            {
                ShowSystemNotice("Today", "登录成功，欢迎 " + response.user.name, 10);
                IFormatter formatter = new BinaryFormatter();

                Stream stream = new FileStream("./user.me", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, response);
                stream.Close();

                this.Hide();
                new NewMasterWindow().Show();
            }

        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMain Main = new UserMain();
            Main.forget.Visibility = Visibility.Hidden;
            Main.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMain Main = new UserMain();
            Main.forget.Visibility = Visibility.Hidden;
            Main.Show();
        }
    }
}