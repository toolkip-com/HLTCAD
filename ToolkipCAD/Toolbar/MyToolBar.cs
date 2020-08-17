using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxDrawXLib;
using AxMxDrawXLib;
using System.Windows.Forms;
using ToolkipCAD.CustomForm;

namespace ToolkipCAD.Toolbar
{
    class MyToolBar
    {
        public bool state { get; set; }//按钮状态
        public int id { get; set; }//命令ID
        /// <summary>
        /// 工具栏功能实现
        /// </summary>
        /// <param name="axMxDrawX">控件</param>
        /// <param name="Cid">命令ID</param>

        public static void CommandRun(ref AxMxDrawX axMxDrawX,short Cid)
        {
            switch (Cid)
            {
                case 1001://选择图层
                    //axMxDrawX.DrawLine(1621508, -117657, 1637920, -118670);
                    break;
                case 1002://新建项目
                    CreateProjectForm createProject = new CreateProjectForm();
                    createProject.ShowDialog();
                    break;
                case 1003://打开项目
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Filter = "hlt文件(*.hlt)|*.hlt";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("打开项目");
                    }
                    break;
            }
        }
    }
}
