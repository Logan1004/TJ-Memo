using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TJ_Memo.MemoBLL;
using TJ_Memo.MemoModel;



namespace TJ_Memo
{
    public partial class Weather_Form : Form
    {
        public Weather_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Weather_Load(object sender, EventArgs e)
        {
            // 新浪定位url
            string url = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js";
            // 请求数据
            String city = "";
            try
            {
                byte[] con = LocationCtrl.GetURLContents(url);
                // byte转string
                string str = Encoding.ASCII.GetString(con);
                // 请求到的原始string需要处理一下才能解析
                string strSp = str.Split('=')[1].Trim().TrimEnd(';');
                // 解析json字符串
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                SinaAddress sinaAddress = serializer.Deserialize<SinaAddress>(strSp);
                // 国家
                string country = sinaAddress.country;
                // 省份
                string province = sinaAddress.province;
                // 城市
                city = sinaAddress.city;
            }
            catch (Exception er)
            {
                city = "上海";
            }
            label2.Text = city;
            cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            String[] s = w.getWeatherbyCityName(city);
            label3.Text = "";
            for (int i = 10; i < 12; i++)
            {
                label3.Text += s[i] + "\r\n";
            }
            List<Object[]> list = TreeHoleCtrl.SelectAll();
            Random rd = new Random();
            int numberone = rd.Next(0, list.Count - 1);
            textBox1.Text = list[numberone][0].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Object[]> list = TreeHoleCtrl.SelectAll();
            Random rd = new Random();
            int numberone = rd.Next(0, list.Count-1);
            textBox1.Text = list[numberone][0].ToString();
        }
    }
}
