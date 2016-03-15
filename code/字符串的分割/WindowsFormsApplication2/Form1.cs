using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //指定分割顺序
            string[] ss = label1.Text.Split('-');
            string[] s1 = ss[2].Split(':');
            string[] s2 = s1[0].Split(' ');
            for (int i = 0; i < 2; i++)
            {
                MessageBox.Show(ss[i]);
            }
            MessageBox.Show(s2[0]);
            MessageBox.Show(s2[1]);

            MessageBox.Show(s1[1]);
            MessageBox.Show(s1[2]);
            /*
            for (int i = 1; i < 3;i++ )
            {
                MessageBox.Show(s1[i]);
            }
             */

        }
    }
}