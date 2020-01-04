using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using TJ_Memo.MemoModel;
using System.Data;
using TJ_Memo.MemoDAL;
using System.Windows.Forms;


namespace TJ_Memo.MemoBLL
{
    public class MainCtrl
    {
        public static List<Event> getEvent(string username,DateTime dateTime)
        {
            List<Event> list = new List<Event>();
            string sql = "select * from MemoEvent where EventDate='" + dateTime + "' and UserName='" + username + "'";
            DataTable dt = MemoDAL.MemoDAL.GetDataTableFromSqlServer(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String UserName = dt.Rows[i]["UserName"].ToString();
                DateTime eventdate = DateTime.Parse(dt.Rows[i]["eventdate"].ToString());
                String eventnote = dt.Rows[i]["eventnote"].ToString();
                Event e = new Event(UserName, eventdate, eventnote);
                list.Add(e);
            }
            return list;
        }

        public static void AddCheckListBox(CheckedListBox clb, DateTime date, String userName)
        {
            List<Event> list = new List<Event>();
            
            string sql = "select * from MemoEvent where EventDate>='" + date + "' and UserName='" + userName + "' order by EventDate";
            DataTable dt = MemoDAL.MemoDAL.GetDataTableFromSqlServer(sql);
            clb.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String title = dt.Rows[i]["NoteHead"].ToString();
                String curDate = dt.Rows[i]["EventDate"].ToString().Split(' ')[0];
                String finished = dt.Rows[i]["finished"].ToString();
                clb.Items.Add("["+curDate+"]"+" "+title);
                if (finished == "1")
                {
                    clb.SetItemChecked(i, true); 
                }
            }
        }

        public static void UpdateMemo(CheckedListBox clb, DateTime date, String userName)
        {
            String sql = "";
            for (int i = 0; i < clb.Items.Count; i++)
            {
                String title = clb.GetItemText(clb.Items[i]);
                title = title.Split(' ')[1];
                if (clb.GetSelected(i))
                {
                    sql = "update MemoEvent set Finished = " + 1 + " where UserName = '" + userName + "' and EventDate = '" + date + "' and NoteHead = '" + title + "'";
                }
                else {
                    sql = "update MemoEvent set Finished = " + 0 + " where UserName = '" + userName + "' and EventDate = '" + date + "' and NoteHead = '" + title + "'";
                }
                MemoDAL.MemoDAL.executeNonQuery(sql); 
            }
        }

        public static void ShowReminder(String userName, ListView lv)
        {
            DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            String sql = "select top 5 NoteHead,RemindTime from MemoRemind where UserName = '" + userName + "' and RemindTime > '" + today + "' order by RemindTime";
            string[] ch = { "序号", "待办事项","提醒时间" };
            MemoDAL.MemoDAL.fillListView(lv, sql, ch);
        }

        public static String Judge(DateTime current)
        {
            String s = "";
            List<Event> list = new List<Event>();

            string sql = "select * from MemoRemind";
            DataTable dt = MemoDAL.MemoDAL.GetDataTableFromSqlServer(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String curDate = dt.Rows[i]["RemindTime"].ToString();
                if (curDate == current.ToString())
                {
                    s = dt.Rows[i]["NoteHead"].ToString();
                }
            }
            return s;
        }


    }
}
