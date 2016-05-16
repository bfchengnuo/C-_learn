using System;
using BLL;
using System.Windows.Forms;

namespace UI
{
    public partial class Landed : Form
    {
        public Landed()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = SQLTools.isLoad(textBox1.Text, textBox2.Text);
            if(flag)
            {
                Owner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("登陆失败，请检查！");
            }
        }
    }
}
