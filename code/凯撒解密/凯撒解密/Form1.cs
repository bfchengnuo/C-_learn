using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 凯撒解密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("请输入要解密的字符串");
            else if (textBox2.Text == "")
                MessageBox.Show("请输入偏移字符！");
            else
                keyShow();
        }

        private void keyShow()
        {
            char[] startTemp = textBox1.Text.ToCharArray();
            int[] start = new int[startTemp.Length];
            int pianyi = textBox2.Text.ToCharArray()[0] - startTemp[0];
            string end = null;

            for (int i = 0; i < startTemp.Length; i++)
            {
                start[i] = Convert.ToInt32(startTemp[i]);
            }
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] >= 'a' && start[i] <= 'z')
                {
                    start[i] += pianyi;
                    if (start[i] < 'a')
                    {
                        start[i] += 26;
                    }
                    else if (start[i] > 'z')
                    {
                        start[i] -= 26;

                    }
                }
                else if (start[i] >= 'A' && start[i] <= 'Z')
                {
                    start[i] += pianyi;
                    if (start[i] < 'A')
                    {
                        start[i] += 26;
                    }
                    else if (start[i] > 'Z')
                    {
                        start[i] -= 26;
                    }
                }

            }

            foreach (char ch in start)
            {
                end += ch;
            }
            label4.Text = "偏移量为：" + pianyi;
            textBox3.Text = end;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                Clipboard.SetDataObject(textBox3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
