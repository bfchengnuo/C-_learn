using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_Game
{

    public partial class Form1 : Form
    {
        int i, a = 9;
        PictureBox[] pb = new PictureBox[99];  //创建picturebox类型的数组
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            a = rd.Next(1, 10);
            for (int x = 0; x < 99; x++)
            {
                pb[x].Image = Bitmap.FromFile(@"D:\" + rd.Next(1, 10).ToString() + ".jpg");
                // pb[x].SizeMode = PictureBoxSizeMode.StretchImage;
                if ((x + 1) % 9 != 0)              //为9的倍数添加相同图片
                    continue;
                pb[x].Image = Bitmap.FromFile(@"D:\" + a.ToString() + ".jpg");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            pictureBox1.Image = Bitmap.FromFile(@"D:\" + i.ToString() + ".jpg");
            if (i == 9)   //闪动九次后停止
            {
                i = 0;
                timer1.Enabled = false;
                pictureBox1.Image = System.Drawing.Bitmap.FromFile(@"D:\" + a.ToString() + ".jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rd = new Random();  //创建随机数
            Label[] lab = new Label[99];   //创建标签数组
            int y = 12, z = 12;
            for (int x = 0; x < 99; x++)   //创建99个控件存放到数组中
            {
                lab[x] = new Label();   //创建一个label
                lab[x].Location = new Point(y + 20, z + 65);  //指定位置在图片下面
                lab[x].Size = new Size(20, 10);
                lab[x].Text += (x + 1) + "";
                this.Controls.Add(lab[x]);
                pb[x] = new PictureBox(); //创建一个标签
                pb[x].Image = Image.FromFile(@"D:\" + rd.Next(1, 10).ToString() + ".jpg");
                if (pb[0].Image == null)
                    MessageBox.Show("请在D盘下放入9张图片");
                pb[x].Location = new Point(y, z);
                pb[x].Size = new Size(60, 60);
                pb[x].SizeMode = PictureBoxSizeMode.StretchImage; //图片自适应控件大小
                y += 70;                 //改变横坐标
                this.Controls.Add(pb[x]);  //添加到窗体
                if ((x + 1) % 11 != 0)   //每行11个
                    continue;
                y = 12;                 //横坐标恢复
                z += 80;                 //改变纵坐标
            }
        }
    }
}
