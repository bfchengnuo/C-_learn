using System;
using System.Data;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLTools.getDT("select distinct(provinceName) from Data_Province");
            SQLTools.addBOX(comboBox1, dt, "provinceName");
            comboBox1.Text = dt.Rows[0][0].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断选择框是否有内容，如果有则清除
            if (comboBox2.Items.Count != 0)
                comboBox2.Items.Clear();
            DataTable dtTemp = SQLTools.getDT("select provinceCode,provinceName from Data_Province where provinceName='" + comboBox1.SelectedItem + "'");
            //MessageBox.Show(dtTemp.Rows[0]["provinceCode"].ToString());
            DataTable dt = SQLTools.getDT("select distinct(CityName) from Data_City where ProvinceCode='" + dtTemp.Rows[0]["provinceCode"] + "'");
            SQLTools.addBOX(comboBox2, dt, "CityName");
            comboBox2.Text = dt.Rows[0][0].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Items.Count != 0)
                comboBox3.Items.Clear();
            DataTable dtTemp = SQLTools.getDT("select CityCode,CityName from Data_City where CityName='" + comboBox2.SelectedItem + "'");
            DataTable dt = SQLTools.getDT("select distinct(AreaName) from Data_Area where CityCode='" + dtTemp.Rows[0]["CityCode"] + "'");
            SQLTools.addBOX(comboBox3, dt, "AreaName");
            comboBox3.Text = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show();
        }
    }
}
