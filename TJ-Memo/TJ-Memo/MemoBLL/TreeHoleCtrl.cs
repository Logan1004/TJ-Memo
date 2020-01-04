using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJ_Memo.MemoBLL
{
    class TreeHoleCtrl
    {
        public static List<Object[]> SelectAll()
        {
            String sql = "select EventNote from MemoEvent";
            List<Object[]> list = MemoDAL.MemoDAL.executeQuery(sql);
            return list;
        }
    }
}
