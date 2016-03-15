using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //第二个数字是长度，不是下标！
            string s1 = textBox1.Text.Substring(0, Convert.ToInt32(textBox2.Text));
            //string s1 = textBox1.Text.Substring(0, int.Parse(textBox2.Text));
            
            string s2 = textBox1.Text.Substring(Convert.ToInt32(textBox2.Text));
            label4.Text = s1 + textBox3.Text + s2;
        }
    }
}
