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
            //第二个参数，指定字符串的切割规则，删除空字符
            string[] ss = richTextBox1.Text.Split(new char[] { ' ', '-','\n',',' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ss.Length; i++)
            {
                MessageBox.Show(ss[i]);
            }
        }

        
    }
}
