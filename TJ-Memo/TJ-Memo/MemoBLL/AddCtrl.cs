using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TJ_Memo.MemoBLL
{
    class AddCtrl
    {
        public static Boolean AddNote(String userName,DateTime date, String context,String title)
        {
            String sql = "insert into MemoEvent values('" + date + "','" + context + "','" + userName+"','" +title+"','"+0+"')";
            MemoDAL.MemoDAL.executeNonQuery(sql);
            return true;
        }

        public static void ShowNotes(ListView lv, DateTime date,String userName)
        {
            String sql = "select NoteHead from MemoEvent where UserName = '" + userName + "' and EventDate = '" + date + "'";
            string[] ch = {"序号","待办事项" };
            MemoDAL.MemoDAL.fillListView(lv, sql, ch);
        }

        public static Boolean DeleteNote(String userName, DateTime date, String context)
        {
            String sql = "delete from MemoEvent where UserName = '" + userName + "' and EventDate = '" + date + "' and  NoteHead = '" + context + "'";
            MemoDAL.MemoDAL.executeNonQuery(sql);
            return true;
        }

        public static Boolean ModifyNote(String userName, DateTime date, String contextInitial, String context,String title)
        {
            String sql = "update MemoEvent set EventNote = '" + context + "', NoteHead = '"+title+"' where UserName = '" + userName + "' and EventDate = '" + date + "' and NoteHead = '" + contextInitial + "'";
            MemoDAL.MemoDAL.executeNonQuery(sql); 
            return true;
        }

        public static String SelectContext(String userName, String title, DateTime date)
        {
            String sql = "select EventNote from MemoEvent where UserName = '" + userName + "' and EventDate = '" + date + "' and NoteHead = '"+title+"'";
            List<Object[]> list = MemoDAL.MemoDAL.executeQuery(sql);
            return list[0][0].ToString();
        }

        public static void AddReminder(String userName, String title, DateTime dateTime)
        {
            String sql = "insert into MemoRemind values('" + userName + "','" + title + "','" + dateTime+ "')";
            MemoDAL.MemoDAL.executeNonQuery(sql);
        }
    }
}
