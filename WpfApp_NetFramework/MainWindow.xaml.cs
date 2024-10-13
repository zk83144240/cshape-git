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
using MySql.Data.MySqlClient;
namespace WpfApp_NetFramework
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;  //设置窗口居中
            InitializeComponent();
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            string uid=username.Text;  //获取用户名
            string psd = password.Text;//获取密码
            DataSql dataSql = new DataSql(); 
            string sql = $"select * from user where uid={uid} and psd={psd};";
            dataSql.Conn();
            if (psd != "" && uid != "") { 
                
                if (dataSql.Rd(sql).Read())
                {
                    MessageBox.Show("数据ok");
                    dataSql.CloseConn();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误","提示",MessageBoxButton.YesNo,MessageBoxImage.Warning );//文本，标题，按钮，图标
                    username.Text = "";
                    password.Text = "";
                    username.Focus();  //获取焦点
                }
            }
            else
            {
                MessageBox.Show("不能输入空值","提示",MessageBoxButton.YesNo,MessageBoxImage.Warning );
                username.Text = "";
                password.Text = "";
                username.Focus();

            }
            
        }
    }
    //操作数据库类
    public class DataSql
    {
        static MySqlConnection conn;
        public MySqlConnection Conn()

        {
            string con_sql = "server=127.0.0.1;port=3306;user=root;password=1234;database=mes;";
            conn = new MySqlConnection(con_sql);
            conn.Open();
            return conn;
        }
        public MySqlCommand Comm(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Conn());
            
            return cmd;
        }
        public MySqlDataReader Rd(string sql)
        {
   
            MySqlDataReader dr =  Comm(sql).ExecuteReader();
            return dr;
        }
        public void CloseConn()
        {

            conn.Close();

        }

    }
}
