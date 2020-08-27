﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ToolkipCAD.Models;

namespace ToolkipCAD
{
    public partial class GouzaoRecord : Form
    {
        private List<GouZaoParam> _tab1List;//钢筋数组
        private List<Waist> _waistList;//腰筋数组
        private int StartIndex = 0;
        public GouzaoRecord()
        {
            InitializeComponent();
            this.Grid_Gj.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(DgvGradeInfoRowPostPaint);
            this.dataGrid_Side.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(SideInfoRowPostPaint);
            this.Combo_hnt.SelectedIndexChanged += Combo_hnt_SelectedIndexChanged;
            this.combo_gj.SelectedIndexChanged += Combo_hnt_SelectedIndexChanged;
            this.Grid_Gj.TopLeftHeaderCell.Value = @"mm\lv";
            this.dataGrid_Side.TopLeftHeaderCell.Value = @"b\hw";
            this.dataGrid_Side.AutoGenerateColumns = true;
            this.dataGrid_Side.ColumnAdded += DataGrid_Side_ColumnAdded;
        }

        private void DataGrid_Side_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //int index = e.Column.Index*50+200;
            //e.Column.HeaderText = index.ToString();
            //e.Column.Name = index.ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //确认按钮
            GRecord record = new GRecord();
            record.name = box_Name.Text;
            //JsonParam JPram = new JsonParam();
            T4Values t4 = new T4Values();
            T2Values t2 = new T2Values();
            T1Values t1 = new T1Values();
            T3Values t3 = new T3Values();
            //保存表格信息
            Gouzao gouzao = new Gouzao();
            dynamic tag = Program.MainForm.Tag;
            gouzao.TName = ((dynamic)this.Tag).id;
            List<T2Value> t2Values= new List<T2Value>
            {
                new T2Value{Value1=double.Parse(t1_t1.Text),Value2=double.Parse(t1_c2.Text),Value3=double.Parse(t1_t3.Text),Type="HPB300"},
                new T2Value{Value1=double.Parse(t2_t1.Text),Value2=double.Parse(t2_c2.Text),Value3=double.Parse(t2_t3.Text),Type="HRB335,HRBF335"},
                new T2Value{Value1=double.Parse(t3_t1.Text),Value2=double.Parse(t3_c2.Text),Value3=double.Parse(t3_t3.Text),Type="HRB400,HRBF400,RRB400"},
                new T2Value{Value1=double.Parse(t4_t1.Text),Value2=double.Parse(t4_c2.Text),Value3=double.Parse(t4_t3.Text),Type="HRB500,HRBF500"},
            };
            t1.Concrete = Combo_hnt.Text;
            t1.Rebars = combo_gj.Text;
            t1.Ratio = double.Parse(box_ratio.Text);
            t1.about = double.Parse(box_about.Text);
            t1.T1Value = _tab1List;
            if (t5_tt2.Text != "" && t5_cc1.Checked)
                t2.MM = double.Parse(t5_tt2.Text);
            t2.Values = t2Values;
            t3.StartB = int.Parse(b_start.Text);
            t3.EndB = int.Parse(b_end.Text);
            t3.StartHW = int.Parse(hw_start.Text);
            t3.EndHW = int.Parse(hw_end.Text);
            t3.waists = _waistList;
            t4.Angle = combo_ran.Text;
            t4.Num = int.Parse(box_linenum.Text);
            t4.Type = comboBox8.Text;
            t4.Diam = comboBox9.Text;
            gouzao.T2Values = t2;
            gouzao.T4Values = t4;
            gouzao.T3Values = t3;
            gouzao.T1Values = t1;
            XmlSerializer xs = new XmlSerializer(gouzao.GetType());
            TextWriter tw = new StreamWriter($@"{tag.path}\project\{gouzao.TName}.tf");
            xs.Serialize(tw, gouzao);
            tw.Close();
            this.Close();
            //catch { MessageBox.Show("保存失败!"); }
        }

        private void GouzaoRecord_Load(object sender, EventArgs e)
        {
            Grid_Gj.Rows.Add(15);
            dynamic tag = this.Tag;
            if (tag.type == "Edit")
            {
                string path=((dynamic)Program.MainForm.Tag).path;
                Gouzao gouzao = new Gouzao();
                XmlSerializer xs = new XmlSerializer(gouzao.GetType());
                TextReader tw = new StreamReader($@"{path}\{tag.id}.tf");
                gouzao = (Gouzao)xs.Deserialize(tw);
                tw.Close();
                _tab1List = gouzao.T1Values.T1Value;
                _waistList = gouzao.T3Values.waists;                
            }
            GetTabOneData();
        }
        private void DgvGradeInfoRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int index = 0;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               this.Grid_Gj.RowHeadersWidth - 4,
               e.RowBounds.Height);
            index = ((e.RowIndex * 2) + 6);
            if (index == 24) index = 25;
            if (index == 32) index = 40;
            if (index == 28) index = 32;
            if (index == 26) index = 28;
            if (index == 30) index = 36;
            if (index == 34) index = 50;
            TextRenderer.DrawText(e.Graphics, index.ToString(),
                this.Grid_Gj.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.Grid_Gj.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        private void SideInfoRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int index = StartIndex;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               this.dataGrid_Side.RowHeadersWidth - 4,
               e.RowBounds.Height);
            index = ((e.RowIndex * 50) + index);
            TextRenderer.DrawText(e.Graphics, index.ToString(),
                this.dataGrid_Side.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.dataGrid_Side.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        private void Grid_Gj_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Combo_hnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tab1 下拉框选择事件
            GetTabOneData();
        }
        private void PushGrid1()
        {
            //填充tab1表格数据
            string cols = ""; int rows = 0;
            for (int i = 0; i < _tab1List.Count; i++)
            {
                for (int k = 0; k < Grid_Gj.Rows.Count; k++)
                {
                    for (int f = 0; f < Grid_Gj.Columns.Count; f++)
                    {
                        cols = Grid_Gj.Columns[f].Name;
                        rows = ((Grid_Gj.Rows[k].Index * 2) + 6);
                        if (_tab1List[i].Level == (Levels)Enum.Parse(typeof(Levels), cols) && rows == _tab1List[i].MM)
                        {
                            Grid_Gj.Rows[k].Cells[f].Value = _tab1List[i].Value;
                        }
                    }
                }
            }
        }
        private void GetTabOneData()
        {
            _tab1List = new List<GouZaoParam>();
            string hnt = Combo_hnt.Text;//混凝土下拉框值
            string gj = combo_gj.Text;//钢筋下拉框值
            //计算








            //添加到List---测试数据
            _tab1List.Add(new GouZaoParam
            {
                Level = Levels.level4,
                MM = 6,
                Concrete = "C30",
                Rebars = "HRB400",
                Value = 123333333
            });
            _tab1List.Add(new GouZaoParam
            {
                Level = Levels.level3,
                MM = 10,
                Concrete = "C30",
                Rebars = "HRB400",
                Value = 1255
            });
            PushGrid1();//显示
        }
        private void L_search_Click(object sender, EventArgs e)
        {
            //梁腰筋查询
            int startb = int.Parse(b_start.Text);
            int endb = int.Parse(b_end.Text);
            if (endb < startb) return;
            int starthw = int.Parse(hw_start.Text);
            int endhw = int.Parse(hw_end.Text);
            if (endhw < starthw) return;
            StartIndex = startb;
            dataGrid_Side.Columns.Clear();
            dataGrid_Side.Rows.Clear();
            for (int i = starthw; i <= endhw; i += 50)
            {
                dataGrid_Side.Columns.Add(i.ToString(), i.ToString());
            }
            for (int k = startb; k <= endb; k += 50)
            {
                dataGrid_Side.Rows.Add();
            }
            GetWaist_Bar();
        }
        private void PushWaist()
        {
            //填充tab1表格数据
            int cols = 0, rows = 0;
            for (int i = 0; i < _waistList.Count; i++)
            {
                for (int k = 0; k < dataGrid_Side.Rows.Count; k++)
                {
                    for (int f = 0; f < dataGrid_Side.Columns.Count; f++)
                    {
                        cols = int.Parse(dataGrid_Side.Columns[f].Name);
                        rows = dataGrid_Side.Rows[k].Index * 50 + StartIndex;
                        if (_waistList[i].Hw == cols && rows == _waistList[i].B)
                        {
                            dataGrid_Side.Rows[k].Cells[f].Value = _waistList[i].Value;
                        }
                    }
                }
            }
        }
        private void GetWaist_Bar()
        {
            _waistList = new List<Waist>();
            _waistList.Add(new Waist
            {
                Hw = 200,
                B = 450,
                Value = "4φ10"
            });
            PushWaist();
        }

        private void Grid_Gj_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //修改单元格的值 tab1
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int mm = ((e.RowIndex * 2) + 6);
            string ColName = Grid_Gj.Columns[e.ColumnIndex].Name;
            Levels lv = (Levels)Enum.Parse(typeof(Levels), ColName);
            GouZaoParam param = _tab1List.Find(x => x.Level == lv && x.MM == mm);
            param.Value = (double)Grid_Gj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void dataGrid_Side_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //修改单元格的值 tab3
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int b = ((e.RowIndex * 2) + 6);
            int hw = int.Parse(dataGrid_Side.Columns[e.ColumnIndex].Name);
            Waist param = _waistList.Find(x => x.Hw == hw && x.B == b);
            if(param!=null)
            param.Value = dataGrid_Side.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                double ratio = double.Parse(box_ratio.Text);//系数
                double about = double.Parse(box_about.Text);//约入
                _tab1List = _tab1List.Select(x => { x.Value *= ratio; return x; }).ToList();
                PushGrid1();
            }
            catch { }
        }
    }
}
