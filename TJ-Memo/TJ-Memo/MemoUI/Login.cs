using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using TJ_Memo.MemoModel;
using TJ_Memo.MemoUI;

namespace TJ_Memo
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           this.skinEngine1.SkinFile = "WarmColor2.ssk";
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                User u = MemoDAL.MemoDAL.userCheck(textBox1.Text, textBox2.Text);
                if (u == null)
                {

                    MessageBox.Show("输入的用户名或密码错误,请重新输入", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    Utils.name = u.username;
                    Middle center = new Middle();
                    this.Hide();
                    center.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserRegister ur = new UserRegister();
            this.Hide();
            ur.ShowDialog();
        }

    }
}
