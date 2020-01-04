using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

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

        public static string passwordEncryption(string password)  //密码加密
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8); //16位MD5加密
            t2 = t2.Replace("-", "");
            return t2;
        }
    }
}
