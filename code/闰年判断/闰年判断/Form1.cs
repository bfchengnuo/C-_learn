using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 闰年判断
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = int.Parse(textBox1.Text);
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                label3.Text = "是闰年！";
            else
                label3.Text = "不是闰年！";

        }
    }
}
