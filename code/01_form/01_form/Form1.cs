using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundImage = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            BackgroundImage = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //销毁窗口
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
            BackgroundImage = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置可见性
            label1.Visible = false;
            textBox1.Visible = false;
            button9.Visible = false;
            label2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button9.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            label2.Text = textBox1.Text;
            MessageBox.Show("保存成功！"); //弹出消息提示框
            button9.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //font是一个类  要先声明
            Font ff = new Font("微软雅黑",28);
            label2.Font = ff;
            label2.ForeColor = Color.Red;//设置前背景，文字颜色
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();  //打开文件选择窗口
            //用系统的画图打开  文件名
            try
            {
              BackgroundImage = System.Drawing.Bitmap.FromFile(opf.FileName);
            }
            catch
            {
                ;
            }
			/*
			使用if处理异常
			if(opf.FileName != ""){
              BackgroundImage = System.Drawing.Bitmap.FromFile(opf.FileName);
			}else{
				;
			}
			*/
        }
    }
}
