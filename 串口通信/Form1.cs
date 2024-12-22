using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口通信
{
    public partial class 串口通信 : Form
    {
        public 串口通信()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 串口通信_Load(object sender, EventArgs e)
        {
            //获取串口名
            string[] ports = SerialPort.GetPortNames();
            //添加串口名到下拉框
            comboBox1.Items.AddRange(ports);
            //设置默认值
            comboBox1.SelectedIndex = comboBox1.Items.Count>0?0:-1;
            comboBox2.SelectedIndex = 3;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="打开串口")
            {
                try
                {
                    //获取串口名
                    serialPort1.PortName=comboBox1.Text;
                    //设置波特率
                    serialPort1.BaudRate = Convert.ToInt32(comboBox5.Text);
                    //设置数据位
                    serialPort1.DataBits = Convert.ToInt32(comboBox2.Text);
                    //设置校验位
                    if(comboBox3.Text=="无")
                    {
                        serialPort1.Parity = Parity.None;
                    }
                    else if(comboBox3.Text=="奇校验")
                    {
                        serialPort1.Parity = Parity.Odd;
                    }
                    else if(comboBox3.Text=="偶校验")
                    {
                        serialPort1.Parity = Parity.Even;
                    }
                    //设置停止位
                    if(comboBox4.Text=="1")
                    {
                        serialPort1.StopBits = StopBits.One;
                    }
                    else if(comboBox4.Text=="1.5")
                    {
                        serialPort1.StopBits = StopBits.OnePointFive;
                    }
                    else if(comboBox4.Text=="2")
                    {
                        serialPort1.StopBits = StopBits.Two;
                    }
                    //打开串口
                    serialPort1.Open();
                    button1.Text = "关闭串口";
                    //设置串口数据接收事件
                    serialPort1.DataReceived += serialPort1_DataReceived;
                }
                catch (Exception ex)
                {
                    //打开失败
                    MessageBox.Show("打开失败！"+ex.ToString(),"提示");
                }
            }
            else
            {
                //关闭串口
                try
                {
                    serialPort1.Close();
                }
                catch (Exception)
                {
                    //按钮显示“打开”
                    button1.Text = "打开串口";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //发送数据
            string str = textBox3.Text;
            try
            {
                if(str.Length>0)
                {
                    //发送数据
                    serialPort1.Write(str);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("发送失败！"+ex.ToString(),"提示");
            }
        }
        //接收数据
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           /* //获取可以读取的字节数
            int len= serialPort1.BytesToRead;
            //创建缓存数据数组
            byte[] buffer = new byte[len];
            //读取数据到buffer数组
            serialPort1.Read(buffer, 0, len);
            Invoke((new Action(() =>
            {
                //将接收到的数据转换为字符串
                string str = Encoding.Default.GetString(buffer);
                //将接收到的数据添加到接收框
                //textBox1.Text += str;
                textBox1.AppendText(str);
            })));
           */
           string data= serialPort1.ReadExisting();
           Invoke((new Action(() => { textBox1.AppendText(data); })));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //清空接收框
           // textBox1.Text = "";
           textBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //清空发送框
            //textBox3.Text = "";
            textBox3.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
