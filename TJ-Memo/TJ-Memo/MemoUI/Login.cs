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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            //this.skinEngine1.SkinFile = "WarmColor2.ssk";
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {

        }

        MemoBLL.VerificationCode vc = new MemoBLL.VerificationCode(5, MemoBLL.VerificationCode.CodeType.Numbers);//生成验证码实例

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromStream(vc.CreateCheckCodeImage());//加载验证码图片
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

            else if (textBox3.Text == "")
            {
                MessageBox.Show("密码不能为空，请重新输入");
                textBox3.Focus();
            }

            else if (!this.textBox3.Text.Equals(vc.CheckCode))//验证是否输入正确
            {
 
                MessageBox.Show(" 验证码错误，请重新输入");
                this.textBox3.Focus();
                this.textBox3.Text = "";
            }

            else
            {
                string password = MemoBLL.UserCtrl.passwordEncryption(textBox2.Text);//对密码进行加密后验证
                User u = MemoDAL.MemoDAL.userCheck(textBox1.Text, password);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromStream(vc.CreateCheckCodeImage());//点击图片更换验证码
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromStream(vc.CreateCheckCodeImage());
        }

    }
}
