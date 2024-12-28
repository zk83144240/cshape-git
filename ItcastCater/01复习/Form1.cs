using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 手动写查询代码
            //操作数据库的类：
            //SQLiteConnection：数据库连接对象
            //SQLiteCommand：数据库操作对象
            //SQLiteDataReader：数据库查询结果集对象
            //SQLiteDataAdapter：数据库操作适配器对象
            //DataSet：数据集对象
            //DataTable：数据表对象
            //SQLiteParameter：数据库参数对象
            //SQLiteTransaction：数据库事务对象
            //SQLiteException：数据库异常对象

            //连接Sqlite数据库,从ManagerInfo表中查询数据
            //0.创建接收数据集
            List<ManagerInfo> list = new List<ManagerInfo>();
            //1.创建数据库连接字符串
            string connStr = @"Data Source=D:\ItcastCater.db;version=3;";
            //2.创建数据库连接对象
            //需要在项目同级建library文件夹，将System.Data.SQLite.dll文件和
            //System.Data.SQLite.xml文件拷贝到该文件夹中，右键引用右键引用，添加引用
            //System.Data.SQLite.dll文件，然后就可以using System.Data.SQLite了
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //3.创建Command对象
                SQLiteCommand cmd = new SQLiteCommand("select * from ManagerInfo", conn);
                //4.打开数据库连接
                conn.Open();
                //5.执行查询
                SQLiteDataReader reader = cmd.ExecuteReader();
                //6.遍历结果集
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new ManagerInfo()
                        {
                            Mid = Convert.ToInt32(reader["mid"]),
                            Mname = reader["mname"].ToString(),
                            Mpwd = reader["mpwd"].ToString(),
                            Mtype = Convert.ToInt32(reader["mtype"]),
                        });
                    }
                }
                reader.Close();
                //7.将数据显示到DataGridView控件中
                dataGridView1.DataSource = list;



            } 
            #endregion
           //使用封装的SQLiteHelp类的GetDataTable方法查询数据
           dataGridView1.DataSource = SqliteHelp.GetDataTable("select * from ManagerInfo");
            //
        }
    }
}
