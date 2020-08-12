using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MxDrawXLib;
using ToolkipCAD.fig;

namespace ToolkipCAD
{
    public partial class Form1 : Form
    {
        private static AutoResize asc = new AutoResize();
        public Form1()
        {
            InitializeComponent();
        }
        /*修改按钮的功能可以通过改写命令,重新注册此命令
         *
         * 
         */
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择文件窗口
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dwg 文件(*.dwg)|*.dwg";//设置可以打开的文件类型
            DialogResult dialogResult= openFileDialog.ShowDialog();
            //点击了窗口中的打开按钮
            if (dialogResult == DialogResult.OK)
            {
                //文件打开的处理
                MessageBox.Show(openFileDialog.FileName);
                //axMxDrawX1.OpenDwgFile(openFileDialog.FileName);//MX打开文件
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2020/08/12,MXDraw测试1","关于");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //大小自适应
            //asc.controlAutoSize(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 直接绘制一个实线
            axMxDrawX1.DrawLine(100, 100, 100, 0);
            
           
            //bool a =axMxDrawX1.LoadToolBar("aa.mxt", true);
            // MessageBox.Show(a.ToString());
        }

        private void axMxDrawX1_ImplementCommandEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEvent e)
        {
            MessageBox.Show(e.iCommandId.ToString());
        }
        private void axMxDrawX1_InitComplete(object sender, EventArgs e)
        {
            // 在控件加载完成后，注册一个MyTest命令，命令id 55.
            axMxDrawX1.RegistUserCustomCommand("test",11);
        }
    }
}
