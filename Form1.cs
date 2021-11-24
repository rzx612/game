using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        private NetworkStream stream;
        private TcpClient tcpClient = new TcpClient();
        public Form1()
        {
            InitializeComponent();
            try
            {
                //向指定的IP地址的服务器发出连接请求
                tcpClient.Connect("10.1.230.74", 3900);
                listBox1.Items.Add("连接成功！");
                stream = tcpClient.GetStream();
                byte[] data = new byte[1024];
                //判断网络流是否可读            
                if (stream.CanRead)
                {
                    int len = stream.Read(data, 0, data.Length);
                    //Encoding ToEncoding = Encoding.GetEncoding("UTF-8");
                    //Encoding FromEncoding = Encoding.GetEncoding("GB2312");
                    //data=Encoding.Convert(FromEncoding, ToEncoding, data);
                    //string msg = Encoding.UTF8.GetString(data, 0, data.Length);
                    string msg = Encoding.Default.GetString(data, 0, data.Length);
                    string str = "\r\n";
                    char[] str1 = str.ToCharArray();
                    string[] msg1 = msg.Split(str1);
                    for (int j = 0; j < msg1.Length; j++)
                    {
                        listBox1.Items.Add(msg1[j]);
                    }
                }
            }
            catch
            {
                listBox1.Items.Add("服务器未启动！");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
