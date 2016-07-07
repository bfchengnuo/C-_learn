using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Files
{
    public partial class Form1 : Form
    {
        //声明四个线程
        private Thread t1;
        private Thread t2;
        private Thread t3;
        private Thread t4;
        //定义委托 用于更新UI的文件表和文件数
        private delegate void updateListDele(string str);
        private delegate void updateLabelDele();
        //线程结束标志
        private bool flag = false;
        //定义变量的路径
        private string[] strFilePath = new string[] { "c:\\", "d:\\", "e:\\" };
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="filePath">遍历的路径</param>
        private void getFilesInfo(object filePath)
        {
            DirectoryInfo di = new DirectoryInfo((string)filePath);
            getFiles(di);
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="di">文件目录</param>
        private void getFiles(DirectoryInfo di)
        {
            if (flag)
            {
                //遍历路径下的文件
                foreach (FileInfo f in di.GetFiles())
                {
                    //由于操作UI频繁 造成程序假死 暂未找到合适方法修复，先让线程睡眠10毫秒
                    Thread.Sleep(10); 
                    //利用委托更新界面
                    if (flag)
                        this.listBox1.Invoke(new updateListDele(updateList), new object[] { f.FullName });
                }
                //遍历路径下的文件夹---->递归
                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    //异常捕获  如果访问了系统文件夹
                    try
                    {
                        if (flag)
                            getFiles(d);
                    }
                    catch
                    {
                        // 暂未处理
                    }
                }
            }
        }


        /// <summary>
        /// 更新UI中的list列表
        /// 将搜索到的文件添加进list
        /// </summary>
        /// <param name="str">文件名</param>
        private void updateList(string str)
        {
            lock (this)
            {
                listBox1.Items.Add(str);
                //设置list一直在底部
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }

        /// <summary>
        /// 用于在UI中更新文件数
        /// </summary>
        private void getCount()
        {
            while (true)
            {
                this.label1.Invoke(new updateLabelDele(updateLabel));
            }
        }

        private void updateLabel()
        {
            label1.Text = "已搜索到文件 " + listBox1.Items.Count + " 个";
        }

        //按钮事件

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new Thread(new ParameterizedThreadStart(getFilesInfo));
            t2 = new Thread(new ParameterizedThreadStart(getFilesInfo));
            t3 = new Thread(new ParameterizedThreadStart(getFilesInfo));
            flag = true;
            t1.Start(strFilePath[0]);
            t2.Start(strFilePath[1]);
            t3.Start(strFilePath[2]);
            t4 = new Thread(new ThreadStart(getCount));
            t4.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            t1.Abort();
            t2.Abort();
            t3.Abort();
            t4.Abort();
        }
    }
}
