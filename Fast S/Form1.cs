using KMCCC.Launcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace Fast_S
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = KMCCC.Tools.SystemTools.FindJava().Last();//textbox1显示我们找到的最后一个Java（也是最近安装的一个）
            
                var versions = Program.Core.GetVersions().ToArray();
            comboBox1.DataSource = versions;//绑定数据源
            comboBox1.DisplayMember = "Id";//设置comboBox显示的为版本Id
            var versions2 = Program.Core.GetVersions().ToArray();
            comboBox2.DataSource = versions2;//绑定数据源
            comboBox2.DisplayMember = "Id";//设置comboBox显示的为版本Id
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ver = (KMCCC.Launcher.Version)comboBox1.SelectedItem;
            var result = Program.Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 3111 ,
                Authenticator = new KMCCC.Authentication.OfflineAuthenticator(textBox3.Text),
                                                                      //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动，最后一个为是否twitch登录
             VersionType =("Fast_S"),
                Mode = LaunchMode.BmclMode , //启动模式，这个我会在后面解
                Size = new WindowSize { Height = 480, Width = 854 } //设置窗口大小，可以不要
            });



            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ver = (KMCCC.Launcher.Version)comboBox2.SelectedItem;
            var result = Program.Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                VersionType = ("Fast_S"),
                MaxMemory = 3333, //最大内存，int类型
                Authenticator = new KMCCC.Authentication.YggdrasilLogin(textBox1 .Text , textBox4 .Text , true), //离线启动，ZhaiSoul那儿为你要设置的游戏名
                                                                      //Authenticator = new YggdrasilLogin("邮箱", "密码", true), // 正版启动，最后一个为是否twitch登录
                Mode = LaunchMode.BmclMode , //启动模式，这个我会在后面解释有哪几种
                
            

            });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}