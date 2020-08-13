using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MxDrawXLib;
using ToolkipCAD.fig;
using ToolkipCAD.Toolbar;

namespace ToolkipCAD
{
    public partial class Form1 : Form
    {
        private static MyToolBar bar_state=new MyToolBar();
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
            axMxDrawX1.Size = new Size(Form1.ActiveForm.Width-15, Form1.ActiveForm.Height-68);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axMxDrawX1.LoadToolBar("Toolkip_toolbar.mxt",true);
            axMxDrawX1.OpenDwgFile(@"D:\Program Files (x86)\MXDraw\MxDraw52\Bin\vc100\管道安装大样图.dwg");
        }

        private void axMxDrawX1_ImplementCommandEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEvent e)
        {
            bar_state.state = !bar_state.state;
            bar_state.id = e.iCommandId;
            //通过命令id执行命令
            //MyToolBar.CommandRun(ref axMxDrawX1, e.iCommandId);
        }
        private void axMxDrawX1_InitComplete(object sender, EventArgs e)
        {
            //在控件加载完成后，注册命令
            CommandList list = new CommandList(ref axMxDrawX1);
        }
        //鼠标点击事件
        private void axMxDrawX1_MouseEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_MouseEventEvent e)
        {
            /*
             * 事件类型,1鼠标移动，2是鼠标左键按下，3是鼠标右键按下，4是鼠标左键双击 
             * 5是鼠标左键释放 6是鼠标右键释放 7是鼠标中键按下 8是鼠标中键释放 
             * 9是鼠标中键双击 10是鼠标中键滚动
             */
            switch (e.lType)
            {
                case 2://左键选择元素图层--所有元素
                    if(bar_state.state==true&& bar_state.id == 1001)
                    {
                        MxDrawSelectionSet mxDrawSelection = new MxDrawSelectionSet();
                        MxDrawResbuf filter = new MxDrawResbuf();
                        MxDrawPoint point = new MxDrawPoint();
                        point.x = e.dX; point.y = e.dY;
                        mxDrawSelection.SelectAtPoint(point, filter);
                        if (mxDrawSelection.Count > 0)
                        {
                            MxDrawEntity entity = mxDrawSelection.Item(0);
                            //MessageBox.Show(entity.Layer);
                            filter = new MxDrawResbuf();
                            mxDrawSelection = new MxDrawSelectionSet();
                            filter.AddStringEx(entity.Layer, 8);//过滤
                            mxDrawSelection.Select(MCAD_McSelect.mcSelectionSetAll, null, null, filter);//获取此图层元素
                            for (int i = 0; i < mxDrawSelection.Count; i++)
                            {
                                //性能有问题
                                //选中元素
                                axMxDrawX1.AddCurrentSelect(mxDrawSelection.Item(i).ObjectID, true, true);
                            }
                        }
                        bar_state.state = false;
                        e.lRet = 1;
                        axMxDrawX1.SendStringToExecute(" ");                        
                    }                    
                    break;
            } 
        }

        private void axMxDrawX1_MxKeyUp(object sender, AxMxDrawXLib._DMxDrawXEvents_MxKeyUpEvent e)
        {
            //ESC取消掉执行此功能
            if (e.lVk == 27) bar_state.state = false;
        }
    }
}
