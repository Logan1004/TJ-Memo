using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using TJ_Memo.MemoModel;

namespace TJ_Memo.MemoDAL
{
    class MemoDAL
    {
       static OleDbConnection conn = new OleDbConnection();
        static MemoDAL()
        {
            string path = Application.StartupPath;
            string file = path + "\\" + "config.txt";
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            conn.ConnectionString = line;
        }

        public static User userCheck(string username,string password)
        {
            string sql = "select * from MemoUser where username='" + username;
            sql += "'and password ='" + password + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            User u;
            try
            {
                conn.Open();
                OleDbDataReader dbReader = cmd.ExecuteReader();
                if (!dbReader.HasRows)
                {
                    return null;                   //用户名或密码不正确，返回空用户
                }
                else
                {
                    while (dbReader.Read())
                    {
                        object[] values = new object[dbReader.FieldCount];
                        dbReader.GetValues(values);   //将一行的数据读进values数组中
                        u = new User(values[0].ToString(), values[1].ToString());
                        return u;
                    }
                }
            }
            catch (OleDbException ex)
            {
                string s = ex.Message;
                MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return null;  
  
        }

        public static void executeNonQuery(string sql)   //执行非查询
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();   //执行该非查询sql语句
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.Close();  
            }
        }
        public static List<object[]> executeQuery(string sql)//执行查询
        {
            List<object[]> result = new List<object[]>();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                OleDbDataReader dbReader = cmd.ExecuteReader();
                while (dbReader.Read())
                {
                    object[] values = new object[dbReader.FieldCount];
                    dbReader.GetValues(values);//将一行的数据读进values数组中
                    result.Add(values);
                }
            }
            catch (OleDbException ex)
            {
                string s = ex.ToString();
            }
            finally { conn.Close(); }
            return result;     
        }

        public static System.Data.DataTable GetDataTableFromSqlServer(string sql)
        {

            OleDbDataAdapter daReaders = new OleDbDataAdapter(sql, conn);
            conn.Open();
            DataSet ds = new DataSet("TJ-Memo");
            daReaders.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        public static void fillListView(ListView lv, String sql, string[] ch)
        {
            lv.View = View.Details;    //定义列表显示的方式
            lv.MultiSelect = false; // 不可以多行选择
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.Visible = true;
            lv.GridLines = true;//画表格线
            lv.FullRowSelect = true;//点击时整行选中
            lv.Columns.Clear(); //将原有的列清空
            lv.Items.Clear();// 将原有的行清空
            if (ch != null)
            {
                for (int i = 0; i < ch.Length; i++)
                { //     设置表头信息
                    lv.Columns.Add(ch[i], 100, HorizontalAlignment.Center);
                }
            }
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                OleDbDataReader dbReader = cmd.ExecuteReader();
                object[] values = new object[dbReader.FieldCount]; // 对应一条记录
                if (ch == null)
                {
                    for (int i = 0; i < dbReader.FieldCount; i++)
                    {
                        lv.Columns.Add(dbReader.GetName(i), 100, HorizontalAlignment.Center);
                    }
                }
                int id = 0;
                while (dbReader.Read())
                {
                    id++;
                    dbReader.GetValues(values);//将一样的数据读进values数组中
                    ListViewItem li = new ListViewItem();//形成一个表项
                    li.SubItems.Clear();
                    li.SubItems[0].Text = id.ToString();//设置第一列
                    li.SubItems.Add(values[0].ToString());
                    for (int i = 1; i < values.Length; i++)
                        li.SubItems.Add(values[i].ToString()); //其余的列
                    lv.Items.Add(li);
                }
            }
            catch (OleDbException ex)
            {
                string s = ex.ToString();
                MessageBox.Show(s);
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}
