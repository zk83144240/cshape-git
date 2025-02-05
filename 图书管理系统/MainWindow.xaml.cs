using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 图书管理系统
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable dt = new DataTable();
        
        public MainWindow()
        {
            InitializeComponent();
        //显示数据
        dt = SqliteHelp.GetDataTable("select * from BooksInfo");
        listView.ItemsSource = dt.DefaultView;
            
        }

        //查询数据的方法
        
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            dt = SqliteHelp.GetDataTable("select * from BooksInfo");
            
            listView.ItemsSource = dt.DefaultView;
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox1.Text;
            string author = textBox2.Text;
            string time = DateTime.Now.ToString();
            SqliteHelp.AddBook( name, author, time);
            //刷新列表
            dt = SqliteHelp.GetDataTable("select * from BooksInfo");
            listView.ItemsSource = dt.DefaultView;
            //清空文本框
            textBox1.Clear();
            textBox2.Clear();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //获取选中的行
            int index = listView.SelectedIndex;
            //获取选中的行的id
            int id = Convert.ToInt32(dt.Rows[index]["BId"]);
           
            //执行删除操作
            SqliteHelp.ExecutNonQuery("delete from BooksInfo where BId=@id", new SQLiteParameter("@id", id));
            //刷新列表
            dt = SqliteHelp.GetDataTable("select * from BooksInfo");
            listView.ItemsSource = dt.DefaultView;
           



        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //获取选中的行
            int index = listView.SelectedIndex;
            //获取选中的行的id
            int id = Convert.ToInt32(dt.Rows[index]["BId"]);
            //设置BTime为当前时间
            string time = DateTime.Now.ToString();
            //执行更新操作
            if (textBox1.Text != ""&&textBox2.Text != "")
            {
                SqliteHelp.UpdateBook("update BooksInfo set BName=@name,BAuthor=@author,BTime=@time where BId=@id",
                    new SQLiteParameter("@name", textBox1.Text), new SQLiteParameter("@author", textBox2.Text),
                    new SQLiteParameter("@time", time), new SQLiteParameter("@id", id));
                //刷新列表
                dt = SqliteHelp.GetDataTable("select * from BooksInfo");
                listView.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("请输入要修改的内容");
            }
            //清空文本框
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}