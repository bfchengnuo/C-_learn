using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //获取随机数，创建数组容器，随机数保存，timer次数标记
        Random id = new Random();
        PictureBox[] pic = new PictureBox[99];
        int temp;
        int t = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            temp = id.Next(1,5);  //取一个随机数，保存起来
            Label[] lab = new Label[99];
            int x = 10, y = 10;  //设置X,Y坐标，记录距离左和上的距离
            for (int i = 0; i < 99; i++)
            {
                //必须先实例化对象才能操作
                pic[i] = new PictureBox();
                pic[i].Top = 10 + y;
                pic[i].Left = 10 + x;
                pic[i].Width = 50;
                pic[i].Height = 50;
                //设置图片让其适应控件，自动缩放
                pic[i].SizeMode = PictureBoxSizeMode.StretchImage;
                //pic[i].Image = System.Drawing.Bitmap.FromFile(@"c:\" + id.Next(1, 5) + ".jpg");
                //判断如果是9的倍数则设置相同的一个保存起来的随机数
                if ((i + 1) % 9 != 0)
                    pic[i].Image = System.Drawing.Bitmap.FromFile(@"c:\" + id.Next(1, 5) + ".jpg");
                else
                    pic[i].Image = System.Drawing.Bitmap.FromFile(@"c:\" + temp + ".jpg");
                //将当前控件添加进窗体
                this.Controls.Add(pic[i]);


                //同上
                lab[i] = new Label();
                //lab[i].Text = "00000000000000000000";
                lab[i].Text = (i + 1).ToString();
                lab[i].Top = 60 + y;
                lab[i].Left = 20 + x;
                lab[i].Width = 50;
                lab[i].Height = 10;
                this.Controls.Add(lab[i]);

                x += 60;
                //如果满了一行就换行，一行11个
                if ((i + 1) % 11 == 0)
                {
                    x = 10;
                    y += 70;
                }


            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = id.Next(1, 5);//保存随机数
            //遍历控件，设置随机图片，如果是9的倍数则设置保存的随机数
            for (int i = 0; i < 99; i++)
            {
                if((i+1)%9 != 0)
                    pic[i].Image = System.Drawing.Bitmap.FromFile(@"c:\" + id.Next(1, 5) + ".jpg");
                else
                    pic[i].Image = System.Drawing.Bitmap.FromFile(@"c:\" + temp + ".jpg");

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //达到循环显示图片的动态效果
            pictureBox1.Image = System.Drawing.Bitmap.FromFile(@"c:\" + id.Next(1,5) + ".jpg");

            //闪动10次停止
            if (t++ == 10)
            {
                //停止的时候设置存储的那个随机数
                pictureBox1.Image = System.Drawing.Bitmap.FromFile(@"c:\" + temp + ".jpg");
                timer1.Enabled = false;
                //标记复位，再次点击可用
                t = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; //激活
            timer1.Interval = 100; //刷新间隔
        }
    }
}
