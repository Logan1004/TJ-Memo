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
    public partial class Middle : Form
    {
        public Middle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoMain memoMain = new MemoMain();
            this.Hide();
            memoMain.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WeatherForm weather = new WeatherForm();
            this.Hide();
            weather.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalCenter pc = new PersonalCenter();
            this.Hide();
            pc.ShowDialog();
        }

        private void Middle_Load(object sender, EventArgs e)
        {

        }
    }
}
