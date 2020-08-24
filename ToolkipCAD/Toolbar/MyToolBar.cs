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
using System.Threading;

namespace ToolkipCAD.Toolbar
{
    class MyToolBar
    {
        public bool state { get; set; }//按钮状态
        public int id { get; set; }//命令ID
        private Project_Tree _Tree;
        private AxMxDrawX axMxDrawX1;
        private object PublicValue;
        public MyToolBar(ref Project_Tree _Tree,ref AxMxDrawX axMxDrawX)
        {
            this._Tree = _Tree;
            this.axMxDrawX1 = axMxDrawX;
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
                case 1006://梁批量识别
                    T1006();
                    break;
                case 1007:
                    T1007();
                    break;
            }
        }

        private void T1007()
        {
            //获取选区内实体
            MxDrawSelectionSet selectionSet = new MxDrawSelectionSet();
            MxDrawUtility mxUtility = new MxDrawUtility();
            //点取范围左上角位置
            MxDrawPoint point1 = (MxDrawPoint)mxUtility.GetPoint(null, "点取范围左上角位置...");
            if (point1 == null) return;
            //点取范围右下角位置
            MxDrawPoint point2 = (MxDrawPoint)mxUtility.GetPoint(null, "点取范围右下角位置...");
            if (point2 == null) return;
            MxDrawResbuf resbuf = new MxDrawResbuf();
            selectionSet.Select(MCAD_McSelect.mcSelectionSetCrossing,point1,point2,resbuf);
            for (int i = 0; i < selectionSet.Count; i++)
            {
                axMxDrawX1.AddCurrentSelect(selectionSet.Item(i).ObjectID, false, false);
            }
            PublicValue = new
            {
                Lx=point1.x,
                Ly=point1.y,
                Rx=point2.x,
                Ry=point2.y
            };
            return;
        }
        
        private void T1006()
        {
            //梁批量识别 看着容易，做起来难^v^
            beam_smart beam = new beam_smart();
            beam.transf += (object param) => {
                string kven = param.ToString();
                if (kven == "select_range")//选择范围
                {
                    beam.Hide();
                    axMxDrawX1.SendStringToExecute("TK_PLSB_select");
                    beam.Show();
                    return PublicValue;
                }
                if (kven == "change_line")//梁
                {
                    beam.Hide();
                    axMxDrawX1.MxKeyUp += AxMxDrawX1_MxKeyUp;
                    
                }
                return "";
            };
            beam.Show();
        }
        private void AxMxDrawX1_MxKeyUp(object sender, _DMxDrawXEvents_MxKeyUpEvent e)
        {
            //按下回车
            if (e.lVk == (int)Keys.Enter)
            {
                axMxDrawX1.MxKeyUp -= AxMxDrawX1_MxKeyUp;
                MxDrawSelectionSet selectionSet = new MxDrawSelectionSet();
                MxDrawResbuf filter = new MxDrawResbuf();
                selectionSet.Select2(MCAD_McSelect.mcSelectionImpliedSelectSelect, null, null, filter);
                //MessageBox.Show(selectionSet.Count.ToString());
                List<long> list = new List<long>();
                for (int i = 0; i < selectionSet.Count; i++)
                {
                    list.Add(selectionSet.Item(i).ObjectID);
                }
                PublicValue = list;
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
