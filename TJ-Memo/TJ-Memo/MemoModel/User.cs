using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJ_Memo.MemoModel
{
    public class User
    {
        public string username,password;
        public User(string username,string password)
        {
            this.username = username;
            this.password = password;
        }

    }
}
