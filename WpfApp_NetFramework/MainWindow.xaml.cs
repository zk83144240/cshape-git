using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MySql.Data.MySqlClient;

namespace WpfApp_NetFramework
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;  //设置窗口居中
            InitializeComponent();     //初始化组件
            this.DataContext = this;    //绑定数据上下文
        }

        public event PropertyChangedEventHandler PropertyChanged;   //声明事件
        private void OnPropertyChanged(string propertyName)     //属性改变事件
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));   //调用事件

        }
        private string _UserName;   //用户名字段
        public string _password;    //密码字段
        public string UserName     //用户名属性
        {
            get { return _UserName; }    //获取值
            set
            { 
                _UserName = value;             //赋值
                OnPropertyChanged("UserName");    //调用属性改变事件
            }

        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }



        private void btn_click(object sender, RoutedEventArgs e)
        {
            //string uid=username.Text;  //获取用户名
            //string psd = password.Text;//获取密码
            DataSql dataSql = new DataSql();    //实例化操作数据库类
            string sql = $"select * from user where uid={UserName} and psd={Password};";     //sql语句
            dataSql.Conn();     //连接数据库
            if (UserName != "" && Password != "") {
                
                if (dataSql.Rd(sql).Read())     
                {
                    //创建一个窗口作为登录成功后的界面
                    MainWindow mainWindow2 = new MainWindow();
                    mainWindow2.ShowDialog();

                    dataSql.CloseConn();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误","提示",MessageBoxButton.YesNo,MessageBoxImage.Warning );//文本，标题，按钮，图标
                    //username.Text = "";
                    //password.Text = "";
                    //username.Focus();  //获取焦点
                }
            }
            else
            {
                MessageBox.Show("不能输入空值","提示",MessageBoxButton.YesNo,MessageBoxImage.Warning );
                //username.Text = "";
                //password.Text = "";
                //username.Focus();

            }
            
        }
    }
    //操作数据库类
    public class DataSql
    {
        static MySqlConnection conn;     //声明连接对象
        public MySqlConnection Conn()   //连接数据库

        {
            string con_sql = "server=127.0.0.1;port=3306;user=root;password=1234;database=mes;";    //连接数据库的字符串
            conn = new MySqlConnection(con_sql);       //实例化连接对象
            conn.Open();        //打开连接
            return conn;       //返回连接对象
        }
        public MySqlCommand Comm(string sql)     //执行sql语句
        {
            MySqlCommand cmd = new MySqlCommand(sql, Conn());     //实例化命令对象
            
            return cmd;
        }
        public MySqlDataReader Rd(string sql)     //执行sql语句并返回结果集
        {
   
            MySqlDataReader dr =  Comm(sql).ExecuteReader();     //执行sql语句并返回结果集
            return dr;
        }
        public void CloseConn()     //关闭连接
        {

            conn.Close();

        }

    }
}
