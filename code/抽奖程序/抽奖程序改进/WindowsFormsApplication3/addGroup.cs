using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class AddGroup
    {
        //控制pic的位置
        public static int s = 0;
        
        //将已选的图片添加到容器，panel是为了显示滚动条
        public void addPic(List<string> idList,List<string> nameList,int i,Panel p,string filepath)
        {

            PictureBox pic = new PictureBox();
            pic.Top = s / 4 * 60 + 10;
            pic.Left = s % 4 * 60 + 10;
            pic.Height = 60;
            pic.Width = 60;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = System.Drawing.Bitmap.FromFile(filepath + idList[i] + ".jpg");
            //设置滚动条回到初始位置
            p.VerticalScroll.Value = p.VerticalScroll.Minimum;
            p.Controls.Add(pic);
            //删除此次取得的随机数与之对应的文件名，保证下次不在取到
            idList.RemoveAt(i);
            nameList.RemoveAt(i);
            s++;
        }
    }
}
