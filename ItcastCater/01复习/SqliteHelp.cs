using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01复习
{
    public static class SqliteHelp
    {
        // 定义一个静态的连接字符串,从app.config中获取:
        // 1.在app.config中添加<connectionStrings>节点
        // 2.在<connectionStrings>节点中添加<add name="connStr" connectionString="Data Source=Data.db;Version=3;" />
        //3.引入程序集：在代码中添加using System.Configuration;
        private static string connStr= ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString;
        //执行命令的方法:insert,update,delete
        //params:可变参数,可以传入任意个参数,也可以不传参数，省略手动构造数组的过程。
        //[SQLiteParameter]：指定参数类型为SQLiteParameter
        
        public static int ExecutNonQuery(string sql, params SQLiteParameter[] ps)
        {
            //创建连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //创建命令对象
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //添加参数
                cmd.Parameters.AddRange(ps);
                //打开连接
                conn.Open();
                //执行命令，返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
        }
        //获取首行首列值的方法
        public static object ExecuteScalar(string sql, params SQLiteParameter[] ps)
        {
            //创建连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //创建命令对象
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //添加参数
                cmd.Parameters.AddRange(ps);
                //打开连接
                conn.Open();
                //执行命令，返回查询结果中的首行首列值
                return cmd.ExecuteScalar();
            }
        }
        //查询结果集
        public static DataTable GetDataTable(string sql, params SQLiteParameter[] ps)
        {
            //创建连接对象
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //创建适配器对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                //构造数据表，用于接收存储查询结果
                DataTable dt = new DataTable();
                //添加参数
                adapter.SelectCommand.Parameters.AddRange(ps);
                //填充数据表
                adapter.Fill(dt);
                //返回数据表
                return dt;

            }
        }
    }

}

