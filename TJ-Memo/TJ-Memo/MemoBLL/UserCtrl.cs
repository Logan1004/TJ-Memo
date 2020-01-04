using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJ_Memo.MemoBLL
{
    class UserCtrl
    {
        public static Boolean AddUser(String userName, String password)
        {
            String sql = "insert into MemoUser values('" + userName + "','" + password +  "')";
            MemoDAL.MemoDAL.executeNonQuery(sql);
            return true;
        }
    }
}
