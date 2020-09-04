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
using ToolkipCAD.fig;
using ToolkipCAD.Models;
using Newtonsoft.Json;

namespace ToolkipCAD.Toolbar
{
    class MyToolBar
    {
        public bool state { get; set; }//按钮状态
        public int id { get; set; }//命令ID
        private Project_Tree _Tree;
        private AxMxDrawX axMxDrawX1;
        private object PublicValue;
        private string BeamType;
        public MyToolBar(ref Project_Tree _Tree, ref AxMxDrawX axMxDrawX)
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
                    break;
                case 1003://打开项目
                    T1003();
                    break;
                case 1004://保存项目
                    T1004();
                    break;
                case 10041://另存为
                    T10041();
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

        private void T10041()
        {
            SaveAsDialog save = new SaveAsDialog();
            save.ShowDialog();
        }
        //选择范围
        private void T1007()
        {
            axMxDrawX1.DynWorldDraw += AxMxDrawX1_DynWorldDraw;//添加动态画框事件
            axMxDrawX1.AddLayer("tkbox");
            MxDrawPoint pt1 = axMxDrawX1.GetPoint(false,0,0,"开始坐标...") as MxDrawPoint;
            if (pt1 == null) return;
            MxDrawUiPrPoint scpt = new MxDrawUiPrPoint();
            scpt.message = "终点坐标...";
            scpt.basePoint = pt1;
            scpt.setUseBasePt(false);
            var spdata = scpt.InitUserDraw("SelectRangeBox");
            spdata.SetPoint("BasePoint",pt1);
            if (scpt.go() != MCAD_McUiPrStatus.mcOk) return;
            spdata.Draw();
            //放大
            axMxDrawX1.ZoomWindow(pt1.x, pt1.y, spdata.DragPoint.x, spdata.DragPoint.y);
            PublicValue = new
            {
                Lx = pt1.x,
                Ly = pt1.y,
                Rx = spdata.DragPoint.x,
                Ry = spdata.DragPoint.y
            };
            //删除选择框
            MxDrawSelectionSet ss = new MxDrawSelectionSet();
            MxDrawResbuf filter = new MxDrawResbuf();
            filter.AddStringEx("tkbox",8);
            ss.Select(MCAD_McSelect.mcSelectionSetAll,null,null,filter);
            for (int i = 0; i < ss.Count; i++)
            {
                axMxDrawX1.Erase(ss.Item(i).ObjectID);
            }
            //删掉画框的图层
            MxDrawDatabase database = axMxDrawX1.GetDatabase() as MxDrawDatabase;
            IMxDrawLayerTableRecord layer = database.GetLayerTable().GetAt("tkbox",false);
            if (layer != null) layer.Erase();
            return;
        }

        private void AxMxDrawX1_DynWorldDraw(object sender, _DMxDrawXEvents_DynWorldDrawEvent e)
        {
            MxDrawCustomEntity pCustomEntity = (MxDrawCustomEntity)e.pData;
            MxDrawWorldDraw pWorldDraw = (MxDrawWorldDraw)e.pWorldDraw;
            string sGuid = pCustomEntity.Guid;
            pWorldDraw.Color = 255;
            pWorldDraw.LineWidth = 1;
            pWorldDraw.Layer = "tkbox";
            MxDrawPoint curPoint = new MxDrawPoint();
            pWorldDraw.SetColorIndex(200);
            curPoint.x = e.dX;
            curPoint.y = e.dY;
            if (sGuid == "SelectRangeBox")
            {
                //与用户交互在图面上提取一个点
                var vBasePt = pCustomEntity.GetPoint("BasePoint");
                //绘制一个直线
                //参数一直线的开始点x坐标，参数二直线的开始点y坐标，参数三直线的结束点x坐标，参数四直线的结束点y坐标
                pWorldDraw.DrawLine(vBasePt.x, vBasePt.y, vBasePt.x, curPoint.y);
                pWorldDraw.DrawLine(vBasePt.x, curPoint.y, curPoint.x, curPoint.y);
                pWorldDraw.DrawLine(curPoint.x, curPoint.y, curPoint.x, vBasePt.y);
                pWorldDraw.DrawLine(curPoint.x, vBasePt.y, vBasePt.x, vBasePt.y);
            }
        }

        private beam_smart beam;
        private void T1006()
        {
            //梁批量识别 
            beam = new beam_smart();
            BeamType = "";
            Project_Manage pro = _Tree.GetSelectProjectTree();
            if (pro.type != Project_type.记录)
            {
                MessageBox.Show("请选择一条记录.");
                return;
            }
            Beam_XRrecord json =_Tree.GetBeamData(pro.xrecord_id) as Beam_XRrecord;
            beam.Tag = new
            {
                list = _Tree._HLT.Drawing_Manage_Tree,
                json = JsonConvert.SerializeObject(json)
            };
            beam.beam.side_lines = new List<string>();
            beam.beam.dim_texts = new List<string>();
            beam.beam.seat_lines = new List<string>();
            beam.transf += (object param) =>
            {
                BeamType = "";
                string kven = param.ToString();
                axMxDrawX1.StopAllTwinkeEnt();
                if (kven == "select_range")//选择范围
                {
                    axMxDrawX1.SendStringToExecute("TK_PLSB_select");
                    return PublicValue;
                }
                if (kven == "change_line")//梁
                {
                    //beam.beam.side_lines = new List<string>();
                    axMxDrawX1.MouseEvent += AxMxDrawX1_MouseEvent;
                    BeamType = "change_line";
                }
                if (kven == "change_dim")//标注
                {
                    //beam.beam.dim_texts = new List<string>();
                    axMxDrawX1.MouseEvent += AxMxDrawX1_MouseEvent;
                    BeamType = "change_dim";
                }
                if (kven == "change_seat")//支座
                {
                    //beam.beam.seat_lines = new List<string>();
                    axMxDrawX1.MouseEvent += AxMxDrawX1_MouseEvent;
                    BeamType = "change_seat";
                }
                if (kven == "Range")//显示范围
                {
                    axMxDrawX1.ZoomWindow(beam.beam.pto[0].X, beam.beam.pto[0].Y,
                        beam.beam.pto[1].X, beam.beam.pto[1].Y);
                }
                if (kven == "SaveData")//保存
                {
                    _Tree.SaveBeamData(pro.id, beam.beam);
                }
                if(kven.Substring(0,4)== "show")
                {
                    axMxDrawX1.MouseEvent -= AxMxDrawX1_MouseEvent;
                    ShowLine(kven.Substring(5,4));
                }
                return null;
            };
            beam.Show();
            beam.FormClosed += Beam_FormClosed;
        }
        //显示选择集
        private void ShowLine(string key)
        {
            MxDrawEntity entity ;
            switch (key)
            {
                case "line":
                    for (int i = 0; i < beam.beam.side_lines.Count; i++)
                    {
                        entity = axMxDrawX1.HandleToObject(beam.beam.side_lines[i]) as MxDrawEntity;
                        axMxDrawX1.TwinkeEnt(entity.ObjectID);
                    }
                    break;
                case "dims":
                    for (int i = 0; i < beam.beam.dim_texts.Count; i++)
                    {
                        entity = axMxDrawX1.HandleToObject(beam.beam.dim_texts[i]) as MxDrawEntity;
                        axMxDrawX1.TwinkeEnt(entity.ObjectID);
                    }
                    break;
                case "seat":
                    for (int i = 0; i < beam.beam.seat_lines.Count; i++)
                    {
                        entity = axMxDrawX1.HandleToObject(beam.beam.seat_lines[i]) as MxDrawEntity;
                        axMxDrawX1.TwinkeEnt(entity.ObjectID);
                    }
                    break;
            }

        }
        private void Beam_FormClosed(object sender, FormClosedEventArgs e)
        {
            axMxDrawX1.MouseEvent -= AxMxDrawX1_MouseEvent;
            axMxDrawX1.StopAllTwinkeEnt();
        }
        //选择集
        private void AxMxDrawX1_MouseEvent(object sender, _DMxDrawXEvents_MouseEventEvent e)
        {
            MxDrawSelectionSet mxDrawSelection;
            MxDrawResbuf filter;
            MxDrawPoint point;
            if (e.lType == 2 && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                mxDrawSelection = new MxDrawSelectionSet();
                filter = new MxDrawResbuf();
                point = new MxDrawPoint();
                point.x = e.dX; point.y = e.dY;
                mxDrawSelection.SelectAtPoint(point, filter);
                //MessageBox.Show(mxDrawSelection.Count.ToString());
                if (mxDrawSelection.Count > 0)
                {                   
                    //MessageBox.Show(mxDrawSelection.Item(0).handle.ToString());
                    axMxDrawX1.TwinkeEnt(mxDrawSelection.Item(0).ObjectID);
                    if (BeamType == "change_line")
                    {
                        if (beam.beam.side_lines.Find(x => x == mxDrawSelection.Item(0).handle) == null)
                            beam.beam.side_lines.Add(mxDrawSelection.Item(0).handle);
                        else
                        {
                            axMxDrawX1.StopTwinkeEnt(mxDrawSelection.Item(0).ObjectID);
                            beam.beam.side_lines.Remove(mxDrawSelection.Item(0).handle);
                        }
                    }
                    if (BeamType == "change_dim")
                    {
                        if (beam.beam.dim_texts.Find(x => x == mxDrawSelection.Item(0).handle) == null)
                            beam.beam.dim_texts.Add(mxDrawSelection.Item(0).handle);
                        else
                        {
                            axMxDrawX1.StopTwinkeEnt(mxDrawSelection.Item(0).ObjectID);
                            beam.beam.dim_texts.Remove(mxDrawSelection.Item(0).handle);
                        }
                    }
                    if (BeamType == "change_seat")
                    {
                        if (beam.beam.seat_lines.Find(x => x == mxDrawSelection.Item(0).handle) == null)
                            beam.beam.seat_lines.Add(mxDrawSelection.Item(0).handle);
                        else
                        {
                            axMxDrawX1.StopTwinkeEnt(mxDrawSelection.Item(0).ObjectID);
                            beam.beam.seat_lines.Remove(mxDrawSelection.Item(0).handle);
                        }
                    }
                }
            }
            else if (e.lType == 2 && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                dynamic pt = PublicValue;
                MxDrawPoint sp = new MxDrawPoint { x = pt.Lx, y = pt.Ly };
                MxDrawPoint ep = new MxDrawPoint { x = pt.Rx, y = pt.Ry };
                mxDrawSelection = new MxDrawSelectionSet();
                filter = new MxDrawResbuf();
                point = new MxDrawPoint();
                point.x = e.dX; point.y = e.dY;
                mxDrawSelection.SelectAtPoint(point, filter);
                if (mxDrawSelection.Count > 0)
                {
                    MxDrawEntity entity = mxDrawSelection.Item(0);
                    //MessageBox.Show(entity.Layer);
                    filter = new MxDrawResbuf();
                    mxDrawSelection = new MxDrawSelectionSet();
                    filter.AddStringEx(entity.Layer, 8);//过滤
                    mxDrawSelection.Select(MCAD_McSelect.mcSelectionSetAll, sp, ep, filter);//获取此图层元素
                    for (int i = 1; i < mxDrawSelection.Count; i++)
                    {
                        //选中元素
                        axMxDrawX1.AddCurrentSelect(mxDrawSelection.Item(i).ObjectID, false, false);
                    }
                }
            }
            //axMxDrawX1.SendStringToExecute("");
        }

        private void T1002()
        {
            //新建项目
            CreateProjectForm createProject = new CreateProjectForm();
            createProject.transf += ((dynamic project) =>
             {
                 Program.MainForm.Text = $"好蓝图平面CAD-[{project.name}.hlt]";
                 Program.MainForm.Tag = new
                 {
                     name = project.name,
                     path = project.path
                 };
                 _Tree.SaveProjectInfo(Program.MainForm.Tag);
             });
            createProject.ShowDialog();
        }
        private void T1003()
        {
            //打开项目
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "hlt文件(*.hlt)|*.hlt";
            fileDialog.InitialDirectory = $@"D:\好蓝图平面CAD钢筋\测试\";
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
            DialogResult dialogResult = MessageBox.Show("确认退出此项目", "退出", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dialogResult)
            {
                T1004();
            }
        }
    }
}
