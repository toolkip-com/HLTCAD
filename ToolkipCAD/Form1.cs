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
using ToolkipCAD.CustomForm;
using ToolkipCAD.fig;
using ToolkipCAD.Toolbar;

namespace ToolkipCAD
{
    public partial class Form1 : Form
    {
        private static MyToolBar bar_state;
        private Project_Tree _TestData;
        private delegate void ActiveProject(String pro);//当前项目
        public Form1()
        {
            InitializeComponent();
        }
        /*修改按钮的功能可以通过改写命令,重新注册此命令
         */

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //大小自适应
            //asc.controlAutoSize(this);
            axMxDrawX1.Size = new Size(Form1.ActiveForm.Width - 22-238, Form1.ActiveForm.Height - 40);
            PR_Panel.Size = new Size(238,Form1.ActiveForm.Height);
            PR_Panel.Location = new Point(axMxDrawX1.Size.Width, 0);
            tab_Proandresource.Height = PR_Panel.Height - 22;
            tree_project.Height = tab_Proandresource.Height-75;
            tree_drawing.Height = tab_Proandresource.Height - 75;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载自定义的菜单栏
            axMxDrawX1.Iniset = "./mxmenu.mnu";
            axMxDrawX1.Call("Mx_ReLoadMenu", $@"{Directory.GetCurrentDirectory()}\mxmenu.mnu");
            //axMxDrawX1.LoadToolBar("Toolkip_toolbar.mxt",true);
            axMxDrawX1.OpenDwgFile(@"D:\好蓝图平面CAD钢筋\测试\试验图纸\S-2#-08屋面层梁平法施工图.dwg");
            //TreeView测试
            //tree_project.Nodes.Add("测试项目");//根节点
            _TestData = new Project_Tree(ref tree_project,ref tree_drawing);
            bar_state = new MyToolBar(ref _TestData,ref axMxDrawX1);
            //_TestData.StructTree();            
        }

        private void axMxDrawX1_ImplementCommandEvent(object sender, AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEvent e)
        {
            bar_state.state = !bar_state.state;
            bar_state.id = e.iCommandId;

            bar_state.CommandRun( e.iCommandId);
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
                            for (int i = 1; i < mxDrawSelection.Count; i++)
                            {
                                //性能有问题
                                //选中元素
                                axMxDrawX1.AddCurrentSelect(mxDrawSelection.Item(i).ObjectID, false, false);
                            }                      
                            //axMxDrawX1.PutEntityInView(entity.ObjectID, 100);
                        }
                        bar_state.state = false;
                        e.lRet = 1;
                        axMxDrawX1.SendStringToExecute(" ");                        
                    }                    
                    break;
            } 
        }
        private static int objID=0;
        private void axMxDrawX1_MxKeyUp(object sender, AxMxDrawXLib._DMxDrawXEvents_MxKeyUpEvent e)
        {
            //ESC取消掉执行此功能
            if (e.lVk == 27) bar_state.state = false;
            //shift切换选择
            if (e.lVk == 16)
            {
                if (bar_state.id == 1001)
                {
                    MxDrawSelectionSet mxDrawSelection = new MxDrawSelectionSet();
                    MxDrawResbuf filter = new MxDrawResbuf();
                    mxDrawSelection.CurrentSelect(filter);
                    if (mxDrawSelection.Count > 0)
                    {                       
                        axMxDrawX1.AddCurrentSelect(mxDrawSelection.Item(objID).ObjectID, true,true);
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void axMxDrawX1_MxKeyUp_1(object sender, AxMxDrawXLib._DMxDrawXEvents_MxKeyUpEvent e)
        {
            if ((Control.ModifierKeys & Keys.Control) != 0 && e.lVk == (int)Keys.N) new CreateProjectForm().ShowDialog();
        }

        private void tree_project_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //树的点击事件
        private void tree_project_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree_project.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                //Tree的右键               
                ContextMenuStrip contextMenuStrip_project = _TestData.CreateItemMenu(e.Node);
                contextMenuStrip_project.Show(tree_project, e.X, e.Y);
                return;
            }
            //点击记录显示图纸
            string src=_TestData.RecodeClick();
            if(src!="") axMxDrawX1.OpenDwgFile(src);
        }

        private void tree_drawing_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show(tree_drawing.Nodes[0].FirstNode.Text);
            tree_drawing.SelectedNode = e.Node;
            //if (e.Node.Level != 2) return;
            if (e.Button == MouseButtons.Right)
            {                      
                ContextMenuStrip contextMenuStrip_drawing = _TestData.CreateDrawMenu();
                contextMenuStrip_drawing.Show(tree_drawing,e.X,e.Y);
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Tag != null)
            {
                DialogResult result = MessageBox.Show("确认退出程序","提示",MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) e.Cancel=false;
                else e.Cancel=true;
            }
        }
    }
}
