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
using TJ_Memo.MemoBLL;
using TJ_Memo.MemoModel;

namespace TJ_Memo.MemoUI
{
    public partial class MemoMain : MaterialForm
    {
        public MemoMain()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            //this.BackgroundImage = Image.FromFile("D:\\PROGRAM\\STEAM\\steamapps\\workshop\\content\\431960\\828722349\\preview.jpg");

        }

        private void MemoMain_Load(object sender, EventArgs e)
        {

            DateTime date = monthCalendar1.SelectionStart;
            Utils.curDate = date;
            materialLabel1.Text = date.ToShortDateString();
            AddCtrl.ShowNotes(listView1, date, Utils.name);
            //checkbox List
            MainCtrl.AddCheckListBox(checkedListBox1, Utils.curDate, Utils.name);
            MainCtrl.ShowReminder(Utils.name, listView2);
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendar1.SelectionStart;
            Utils.curDate = date;
            materialLabel1.Text = date.ToShortDateString();
            AddCtrl.ShowNotes(listView1, date, Utils.name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = Utils.curDate;
            DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            String title = textBox2.Text;
            AddCtrl.AddNote(Utils.name, date, textBox1.Text,title);
            AddCtrl.ShowNotes(listView1, Utils.curDate, Utils.name);
            MainCtrl.AddCheckListBox(checkedListBox1, today, Utils.name);
            MessageBox.Show("添加成功", "正确", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的数据行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                AddCtrl.DeleteNote(Utils.name, Utils.curDate, listView1.SelectedItems[0].SubItems[1].Text);
                listView1.SelectedItems[0].Remove();
                MainCtrl.AddCheckListBox(checkedListBox1, today, Utils.name);
                MessageBox.Show("删除成功", "正确", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的数据行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                AddCtrl.ModifyNote(Utils.name, Utils.curDate, listView1.SelectedItems[0].SubItems[1].Text , textBox1.Text,textBox2.Text);
                AddCtrl.ShowNotes(listView1, Utils.curDate, Utils.name);
                MainCtrl.AddCheckListBox(checkedListBox1, today, Utils.name);
                MessageBox.Show("修改成功", "正确", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
   

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            materialLabel2.Text = string.Format(DateTime.Now.ToLongTimeString());
            DateTime date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            String title = MainCtrl.Judge(date);
            if (title!="")
            {
                MessageBox.Show(title+"到时间啦！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainCtrl.ShowReminder(Utils.name, listView2);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要显示详情的数据行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox1.Text = AddCtrl.SelectContext(Utils.name, listView1.SelectedItems[0].SubItems[1].Text, Utils.curDate);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainCtrl.UpdateMemo(checkedListBox1, Utils.curDate, Utils.name);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            AddCtrl.AddReminder(Utils.name, textBox2.Text, dateTimePicker1.Value);
            MainCtrl.ShowReminder(Utils.name,listView2);
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
