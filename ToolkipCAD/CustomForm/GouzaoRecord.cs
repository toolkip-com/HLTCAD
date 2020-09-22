using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<T2Values2> _Bims;
        private int StartIndex = 0;
        public delegate void Transf(dynamic param);
        public event Transf transf;
        public GouzaoRecord()
        {
            InitializeComponent();
            //表格的事件/属性
            //this.Grid_Gj.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(DgvGradeInfoRowPostPaint);
            this.dataGrid_Side.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(SideInfoRowPostPaint);
            //this.Grid_Gj.TopLeftHeaderCell.Value = @"钢筋种类";
            this.dataGrid_Side.TopLeftHeaderCell.Value = @"b\hw";
            this.dataGrid_Side.AutoGenerateColumns = true;
            this.dataGrid_Side.ColumnAdded += DataGrid_Side_ColumnAdded;
            this.rowMergaView1.ColumnAdded += RowMergaView1_ColumnAdded;//tab1列事件
            this.rowMergaView1.CellValueChanged += RowMergaView1_CellValueChanged;//单元格编辑事件1
            this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            StructGridView();//构建rowMergaView1
            _Bims = new List<T2Values2>();
            structDataGrid2();//第二个表格
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            Regex regex = new Regex("^[0-9]{1,4}(.[0-9]{1,3})?d?$");
            string value = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (regex.IsMatch(value))
            {
                value = value.Replace("d", "");
                double c = Convert.ToDouble(value);
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = $"{value}d";
                var temp = _Bims.Find(x=>x.X == e.ColumnIndex && x.Y == e.RowIndex);
                if (temp == null)
                {
                    _Bims.Add(new T2Values2
                    {
                        CValue=this.dataGridView1.Columns[e.ColumnIndex].Name,
                        RValue=Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()),
                        Value=c,
                        X=e.ColumnIndex,
                        Y=e.RowIndex
                    });
                }
                else
                {
                    _Bims = _Bims.Select(x=>
                    {
                        if (x.X == e.ColumnIndex && x.Y == e.RowIndex)
                        {
                            x.Value = c;
                        }
                        return x;
                    }).ToList();
                }
                return;
            }
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0d";
        }
        private void structDataGrid2()
        {
            this.dataGridView1.Rows.Add(17);
            double[] RowHeader = {4,6,6.5,8,10,12,14,16,18,20,22,25,28,32,36,40,50 };
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = RowHeader[i];
            }
            this.dataGridView1.Columns[0].ReadOnly = true;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //this.dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.DisableResizing);
            this.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void RowMergaView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{1,4}d?$");
            string value = this.rowMergaView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (value.Trim() != "")
            {
                if (regex.IsMatch(value))
                {
                    //if (value.IndexOf('d') == -1)
                    {
                        value = value.Replace("d", "");
                        double c = Convert.ToDouble(value);
                        this.rowMergaView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = $"{value}d";
                        _tab1List = _tab1List.Select(x =>
                        {
                            if (x.x == e.ColumnIndex && x.y == e.RowIndex)
                            {
                                x.Value = c;
                            }
                            return x;
                        }).ToList();
                    }
                    return;
                }
            }
            this.rowMergaView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0d";
        }
        private void RowMergaView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index < 2)
                e.Column.Width = 60;
            else e.Column.Width = 50;
        }
        private void StructGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("钢筋种类");
            dt.Columns.Add("抗震等级");
            for (int i = 20; i < 65; i += 5)
            {
                if (i == 60)
                {
                    dt.Columns.Add($">={i}");
                    break;
                }
                dt.Columns.Add($"C{i}");
            }
            dt.Rows.Add("HPB300", "一级");
            dt.Rows.Add("HPB300", "二级");
            dt.Rows.Add("HPB300", "三级");
            dt.Rows.Add("HPB300", "四级");
            dt.Rows.Add("HRB335\nHRBF335", "一级");
            dt.Rows.Add("HRB335\nHRBF335", "二级");
            dt.Rows.Add("HRB335\nHRBF335", "三级");
            dt.Rows.Add("HRB335\nHRBF335", "四级");
            dt.Rows.Add("HRB400\nHRBF400\nRRB400", "一级");
            dt.Rows.Add("HRB400\nHRBF400\nRRB400", "二级");
            dt.Rows.Add("HRB400\nHRBF400\nRRB400", "三级");
            dt.Rows.Add("HRB400\nHRBF400\nRRB400", "四级");
            dt.Rows.Add("HRB500\nHRBF500", "一级");
            dt.Rows.Add("HRB500\nHRBF500", "二级");
            dt.Rows.Add("HRB500\nHRBF500", "三级");
            dt.Rows.Add("HRB500\nHRBF500", "四级");

            this.rowMergaView1.DataSource = dt;
            this.rowMergaView1.ColumnHeadersHeight = 40;
            this.rowMergaView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.rowMergaView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.rowMergaView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.rowMergaView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rowMergaView1.MergeColumnNames.Add("钢筋种类");
            this.rowMergaView1.Columns[0].ReadOnly = true;
            this.rowMergaView1.Columns[1].ReadOnly = true;
            this.rowMergaView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.rowMergaView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.rowMergaView1.RowTemplate.Height=25;
            for (int i = 0; i < this.rowMergaView1.Columns.Count; i++)
            {
                this.rowMergaView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.rowMergaView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void DataGrid_Side_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //int index = e.Column.Index*50+200;
            //e.Column.HeaderText = index.ToString();
            //e.Column.Name = index.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //确认按钮
            //GRecord record = new GRecord();
            //record.name = box_Name.Text;
            //JsonParam JPram = new JsonParam();
            T4Values t4 = new T4Values();
            T3Values t3 = new T3Values();
            //保存表格信息
            Gouzao gouzao = new Gouzao();
            dynamic tag = Program.MainForm.Tag;
            dynamic edit = this.Tag;
            if (edit.type != "Edit") gouzao.TName = Guid.NewGuid().ToString();
            else gouzao.TName = edit.id;
            gouzao.T1Value = _tab1List;
            gouzao.T2Value = _Bims;
            if (b_start.Text != "")
                t3.StartB = int.Parse(b_start.Text);
            if (b_end.Text != "")
                t3.EndB = int.Parse(b_end.Text);
            if (hw_start.Text != "")
                t3.StartHW = int.Parse(hw_start.Text);
            if (hw_end.Text != "")
                t3.EndHW = int.Parse(hw_end.Text);
            t3.waists = _waistList;
            t4.Angle = combo_ran.Text;
            t4.Num = int.Parse(box_linenum.Text);
            t4.Type = comboBox8.Text;
            t4.Diam = comboBox9.Text;
            gouzao.T4Values = t4;
            gouzao.T3Values = t3;
            XmlSerializer xs = new XmlSerializer(gouzao.GetType());
            TextWriter tw = new StreamWriter($@"{tag.path}\project\{gouzao.TName}.tf");
            xs.Serialize(tw, gouzao);
            tw.Close();
            transf(new
            {
                id = gouzao.TName,
                name = box_Name.Text
            });
            this.Close();
            //catch { MessageBox.Show("保存失败!"); }
        }
        private void GouzaoRecord_Load(object sender, EventArgs e)
        {        
            dynamic tag = this.Tag;
            if (tag.type == "Edit")
            {
                string path = ((dynamic)Program.MainForm.Tag).path;
                Gouzao gouzao = new Gouzao();
                XmlSerializer xs = new XmlSerializer(gouzao.GetType());
                TextReader tw = new StreamReader($@"{path}\project\{tag.id}.tf");
                gouzao = (Gouzao)xs.Deserialize(tw);
                tw.Close();
                //1
                _tab1List = gouzao.T1Value;
                _waistList = gouzao.T3Values.waists;
                _Bims = gouzao.T2Value;                
                //3
                b_start.Text = gouzao.T3Values.StartB.ToString();
                b_end.Text = gouzao.T3Values.EndB.ToString();
                hw_start.Text = gouzao.T3Values.StartHW.ToString();
                hw_end.Text = gouzao.T3Values.EndHW.ToString();

                //4
                combo_ran.Text = gouzao.T4Values.Angle;
                box_linenum.Text = gouzao.T4Values.Num.ToString();
                comboBox8.Text = gouzao.T4Values.Type;
                comboBox9.Text = gouzao.T4Values.Diam;
                LoadTab1View();
                LoadTab2View();
                PushEditWaist();
                return;
            }
            CreateTab1View();
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void L_search_Click(object sender, EventArgs e)
        {
            try
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
            catch { }
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
        private void PushEditWaist()
        {
            //填充tab1表格数据
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
        private void dataGrid_Side_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //修改单元格的值 tab3
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int b = ((e.RowIndex * 50) + StartIndex);
            int hw = int.Parse(dataGrid_Side.Columns[e.ColumnIndex].Name);
            Waist param = _waistList.Find(x => x.Hw == hw && x.B == b);
            if (param != null)
                param.Value = dataGrid_Side.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void GetWaist_Bar()
        {
            _waistList = new List<Waist>();
            ComputeClass compute = new ComputeClass();
            int n = 0; double d = 0d;
            int b = 0, h = 0;
            for (int i = 0; i < dataGrid_Side.Columns.Count; i++)
            {
                for (int k = 0; k < dataGrid_Side.Rows.Count; k++)
                {
                    h = int.Parse(dataGrid_Side.Columns[i].Name);
                    b = ((dataGrid_Side.Rows[k].Index * 50) + StartIndex);
                    compute.waist(b, h, ref n, ref d);
                    _waistList.Add(new Waist
                    {
                        Hw = h,
                        B = b,
                        Value = $"{n}φ{d}"
                    });
                }
            }
            PushWaist();
        }
        //生成tab1_View
        private void CreateTab1View()
        {           
            if (_tab1List == null) _tab1List = new List<GouZaoParam>();
            ComputeClass compute = new ComputeClass();
            for (int i = 0; i < this.rowMergaView1.Rows.Count; i++)
            {
                for (int k = 2; k < this.rowMergaView1.Columns.Count; k++)
                {
                    string ctype = this.rowMergaView1.Columns[k].Name;
                    if (ctype == ">=60") ctype = "C60";
                    string gtype = this.rowMergaView1.Rows[i].Cells[0].Value.ToString();
                    string level = this.rowMergaView1.Rows[i].Cells[1].Value.ToString();
                    if (gtype.IndexOf("\n") != -1) gtype = gtype.Replace("\n", ",");
                    double vals = compute.anchoragelength(ctype, gtype);
                    this.rowMergaView1.Rows[i].Cells[k].Value = $"{vals}d";
                    _tab1List.Add(new GouZaoParam
                    {
                        Concrete = ctype,
                        Rebars = gtype,
                        Value = vals,
                        Level = (Levels)Enum.Parse(typeof(Levels), level),
                        x = k,
                        y = i
                    }); ;
                }
            }
        }
        //加载tab1_View
        private void LoadTab1View()
        {
            if (_tab1List == null) _tab1List = new List<GouZaoParam>();
            ComputeClass compute = new ComputeClass();
            for (int i = 0; i < this.rowMergaView1.Rows.Count; i++)
            {
                for (int k = 2; k < this.rowMergaView1.Columns.Count; k++)
                {
                    string ctype = this.rowMergaView1.Columns[k].Name;
                    if (ctype == ">=60") ctype = "C60";
                    string gtype = this.rowMergaView1.Rows[i].Cells[0].Value.ToString();
                    string level = this.rowMergaView1.Rows[i].Cells[1].Value.ToString();
                    if (gtype.IndexOf("\n") != -1) gtype = gtype.Replace("\n", ",");
                    double vals = compute.anchoragelength(ctype, gtype);
                    this.rowMergaView1.Rows[i].Cells[k].Value = _tab1List.Find(x=>x.x==k&&x.y==i).Value;                    
                }
            }
        }
        //加载tab2_View
        private void LoadTab2View()
        {
            _Bims.ForEach(x=>
            {
                this.dataGridView1.Rows[x.Y].Cells[x.X].Value = x.Value;
            });              
        }
    }
}