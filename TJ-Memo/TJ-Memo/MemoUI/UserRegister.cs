using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TJ_Memo.MemoUI
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {


        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空，请重新输入");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空，请重新输入");
                textBox2.Focus();
            }
            else
            {
                if (MemoDAL.MemoDAL.usernameCheck(textBox1.Text))
                {
                    MessageBox.Show("用户名已存在，请重新输入");
                    textBox1.Focus();
                }
                else
                {
                    string password = MemoBLL.UserCtrl.passwordEncryption(textBox2.Text);
                    MemoBLL.UserCtrl.AddUser(textBox1.Text, password);
                    MessageBox.Show("注册成功，请返回登录。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.ShowDialog();
        }
    }
}
