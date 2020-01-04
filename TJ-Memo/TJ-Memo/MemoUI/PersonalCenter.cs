using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TJ_Memo.MemoUI
{
    public partial class PersonalCenter : Form
    {
        public PersonalCenter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean b=MemoDAL.MemoDAL.passwordChanged(textBox1.Text,textBox2.Text);
            if (b)
            {
                MessageBox.Show("原密码错误，请重新输入");
            }
            else
            {
                MessageBox.Show("密码修改成功，请返回重新登录");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Middle m = new Middle();
            this.Hide();
            m.ShowDialog();

        }
    }
}
