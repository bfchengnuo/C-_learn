using System;
using System.Data;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLTools.getDT("select distinct(provinceName) from Data_Province");
            SQLTools.addBOX(comboBox1, dt, "provinceName");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断数据表是否为空，如果不为空则置为null
            if(dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            DataTable dtTemp = SQLTools.getDT("select provinceCode,provinceName from Data_Province where provinceName='" + comboBox1.SelectedItem + "'");
            DataTable dt = SQLTools.getDT("select * from Data_City where ProvinceCode='" + dtTemp.Rows[0]["provinceCode"] + "'");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("先选择省份");
                return ;
            }
            string temp = textBox1.Text;
            DataTable dtTemp = SQLTools.getDT("select provinceCode,provinceName from Data_Province where provinceName='" + comboBox1.SelectedItem + "'");
            DataTable dt = SQLTools.getDT("select * from Data_City where ProvinceCode='" + dtTemp.Rows[0]["provinceCode"] + "' and CityName like '%"+temp+"%'");
            dataGridView1.DataSource = dt;
        }
    }
}
