using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxDrawXLib;
using AxMxDrawXLib;
using System.Windows.Forms;
using ToolkipCAD.CustomForm;
using System.Xml.Serialization;
using System.IO;

namespace ToolkipCAD.Toolbar
{
    class MyToolBar
    {
        public bool state { get; set; }//按钮状态
        public int id { get; set; }//命令ID
        private Project_Tree _Tree;
        public MyToolBar(ref Project_Tree _Tree)
        {
            this._Tree = _Tree;
        }
        public void CommandRun(short Cid)
        {
            switch (Cid)
            {
                case 1001://选择图层
                    //axMxDrawX.DrawLine(1621508, -117657, 1637920, -118670);
                    break;
                case 1002://新建项目
                    T1002();
                    _Tree.SaveProjectInfo(Program.MainForm.Tag);
                    break;
                case 1003://打开项目
                    T1003();
                    break;
                case 1004://保存项目
                    T1004();
                    break;
                case 1005://退出项目
                    T1005();
                    break;
            }
        }


        private void T1002()
        {
            //新建项目
            CreateProjectForm createProject = new CreateProjectForm();
            createProject.transf +=((dynamic project) =>
            {
                Program.MainForm.Text = $"好蓝图平面CAD-[{project.name}.hlt]";
                Program.MainForm.Tag = new
                {
                    name = project.name,
                    path = project.path
                };
            });
            createProject.ShowDialog();
        }
        private void CreateProS(dynamic project)
        {
            Program.MainForm.Text = $"好蓝图平面CAD-[{project.name}.hlt]";
            Program.MainForm.Tag = new
            {
                name = project.name,
                path = project.path
            };
            _Tree.SaveProjectInfo(project);
        }
        private void T1003()
        {
            //打开项目
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "hlt文件(*.hlt)|*.hlt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _Tree.LoadHLTTree(fileDialog.FileName);                
            }
        }
        public void T1004()
        {
            //保存项目 XML
            try
            {
                if (Program.MainForm.Tag == null) return;
                dynamic ProInfo = Program.MainForm.Tag;
                string HltPath = $@"{ProInfo.path}\{ProInfo.name}.hlt";
                XmlSerializer xs = new XmlSerializer(_Tree._HLT.GetType());
                TextWriter tw = new StreamWriter(HltPath);
                xs.Serialize(tw, _Tree._HLT);
                tw.Close();
                MessageBox.Show("保存成功");                
            }
            catch (Exception ex)
            {
                MessageBox.Show("项目保存出错:" + ex.Message);
            }
        }
        public void T1005()
        {
            //退出项目
            DialogResult dialogResult= MessageBox.Show("确认退出此项目", "退出", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dialogResult)
            {
                T1004();
            }
        }
    }
}
