using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MxDrawXLib;
using AxMxDrawXLib;
using System.Text.RegularExpressions;

namespace ToolkipCAD.CustomForm
{
    public partial class OnePeaceEditDialog : Form
    {
        ImageList imageList1;//弯钩图片集合
        public string LineID;//获取线的ID
        public Beam_XRrecord Mybeam = null;
        public delegate void Transf(String key);
        public event Transf transf;
        private Thread th;//用于响应的线程
        private AxMxDrawX axMxDrawX = Program.MainForm.axMxDrawX1;
        public OnePeaceEditDialog()
        {
            InitializeComponent();
            imageList1 = new ImageList();
            for (int i = 1; i < 11; i++)
            {
                Image image = Image.FromFile($"./Resources/gou{i}.png");
                imageList1.Images.Add(image);
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Rows.Add(6);
            //注册图片下拉框事件
            DrawRegister(Hook1);
            DrawRegister(Hook2);
            DrawRegister(Hook3);
            DrawRegister(Hook4);
            DrawRegister(Hook5);
            DrawRegister(Hook6);
        }
        private void DrawRegister(ComboBox box)
        {
            box.DrawMode = DrawMode.OwnerDrawFixed;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.ItemHeight = 25;
            for (int i = 1; i < 11; i++)
            {
                box.Items.Add(i);
            }
            box.DrawItem += comboBox1_DrawItem;
        }
        private void OnePeaceEditDialog_Load(object sender, EventArgs e)
        {
            Mybeam = JsonConvert.DeserializeObject<Beam_XRrecord>(this.Tag.ToString());
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            Size imageSize = imageList1.Images[0].Size;

            if (e.Index >= 0)
            {
                Font fn = new Font("Tahoma", 10, FontStyle.Bold);
                string s = (string)Concrete_type.Items[e.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    //画条目背景
                    e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Transparent), r);
                    //绘制图像
                    e.Graphics.DrawImage(imageList1.Images[e.Index], new Rectangle(0, e.Bounds.Y + 3, 70, 25));
                    //imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    //显示字符串
                    //e.Graphics.DrawString(s, fn, new SolidBrush(System.Drawing.Color.Black), r.Left + imageSize.Width, r.Top);
                    //显示取得焦点时的虚线框
                    e.DrawFocusRectangle();
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Transparent), r);
                    e.Graphics.DrawImage(imageList1.Images[e.Index], new Rectangle(0, e.Bounds.Y + 3, 70, 25));
                    //imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    //e.Graphics.DrawString(s, fn, new SolidBrush(System.Drawing.Color.Black), r.Left + imageSize.Width, r.Top);
                    e.DrawFocusRectangle();
                }
            }
        }
        private void btn_remove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_select_Click(object sender, EventArgs e)
        {
            //拾取中心线
            LineID = "";
            transf("CKLine");
            //线程监听值变化,填充界面数据 
            th = new Thread(() =>
            {
                int count = 0;
                if (Mybeam != null)
                    while (count < Mybeam.beams.Count)
                    {
                        if (LineID != "")
                        {
                            //break;
                            count++;
                            //填充数据
                            Beam beam = Mybeam.beams.Find(x => x.PM_Line.Find(c => c == LineID) != null);
                            if (beam == null) break;
                            if (beam.Concrete_type == null) Concrete_type.Text = Mybeam.Concrete_type;
                            else Concrete_type.Text = beam.Concrete_type;
                            if (beam.Rebar_type == null) Rebar_type.Text = Mybeam.Rebar_type;
                            else Rebar_type.Text = beam.Rebar_type;
                            if (beam.Stirrup_type == null) Stirrup_type.Text = Mybeam.Strup_type;
                            else Stirrup_type.Text = beam.Stirrup_type;
                            if (beam.earth_type == null) earth_type.Text = Mybeam.earth_type;
                            else earth_type.Text = beam.earth_type;
                            combo_linetype.Text = beam.type;
                            GUID_Box.Text = beam.id;
                            if (beam.overmm != null && beam.Rebar_overmm != null)
                            {
                                check_gj.Checked = true;
                                over_box.Text = beam.overmm;
                                Stirrup_type2.Text = beam.Rebar_overmm;
                            }
                            else if (Mybeam.overmm != null && Mybeam.Rebar_overmm != null)
                            {
                                check_gj.Checked = true;
                                over_box.Text = Mybeam.overmm;
                                Stirrup_type2.Text = Mybeam.Rebar_overmm;
                            }
                            if (beam.Sections != null && beam.Sections.Count > 0)
                            {
                                sectionsb.Text = beam.Sections[0].b.ToString();
                                sectionsh.Text = beam.Sections[0].h.ToString();
                            }
                            if (beam.Waist_Bar!=null&&beam.Waist_Bar.Count > 0)//G
                            {
                                waist.Text = $"G{beam.Waist_Bar[0].n}Φ{beam.Waist_Bar[0].D}";
                            }
                            if (beam.Twist_Bar!=null&&beam.Twist_Bar.Count > 0)//N
                            {
                                Twist.Text = $"N{beam.Twist_Bar[0].n}Φ{beam.Twist_Bar[0].D}";
                            }
                            publicbar.Text = Rebar2String(beam.Public_Bar);
                            if (beam.Public_Bar_Hooks_Left != null)
                            {
                                checkBox1.Checked = true;
                                Hook1.SelectedIndex = beam.Public_Bar_Hooks_Left.type;
                                Hook1_Text.Text = beam.Public_Bar_Hooks_Left.Length.ToString();
                            }
                            if (beam.Public_Bar_Hooks_Right != null)
                            {
                                checkBox2.Checked = true;
                                Hook2.SelectedIndex = beam.Public_Bar_Hooks_Right.type;
                                Hook2_Text.Text = beam.Public_Bar_Hooks_Right.Length.ToString();
                            }



                            if (beam.Left_Seat_Rebars!=null&&beam.Left_Seat_Rebars.Count > 0)
                                LeftSeatRebars.Text = Rebar2String(beam.Left_Seat_Rebars[0]);
                            LeftSeatLen.Text = beam.LeftSeatLen.ToString();
                            if (beam.Left_Seat_Rebars_Hooks_Left != null)
                            {
                                checkBox3.Checked = true;
                                Hook5.SelectedIndex = beam.Left_Seat_Rebars_Hooks_Left.type;
                                Hook5_Text.Text = beam.Left_Seat_Rebars_Hooks_Left.Length.ToString();
                            }
                            if (beam.Right_Seat_Rebars!=null&&beam.Right_Seat_Rebars.Count > 0)
                                RightSeatRebars.Text = Rebar2String(beam.Right_Seat_Rebars[0]);
                            RightSeatLen.Text = beam.RightSeatLen.ToString();
                            if (beam.Right_Seat_Rebars_Hooks_Right != null)
                            {
                                checkBox4.Checked = true;
                                Hook6.SelectedIndex = beam.Right_Seat_Rebars_Hooks_Right.type;
                                Hook6_Text.Text = beam.Right_Seat_Rebars_Hooks_Right.Length.ToString();
                            }



                            if (beam.Mid_Beam_Rebars!=null&&beam.Mid_Beam_Rebars.Count > 0)
                                MidBeamRebars.Text = Rebar2String(beam.Mid_Beam_Rebars[0]);
                            if (beam.Mid_Beam_Rebars_Hooks_Left != null)
                            {
                                checkBox5.Checked = true;
                                Hook3.SelectedIndex = beam.Mid_Beam_Rebars_Hooks_Left.type;
                                Hook3_Text.Text = beam.Mid_Beam_Rebars_Hooks_Left.Length.ToString();
                            }
                            if (beam.Mid_Beam_Rebars_Hooks_Right != null)
                            {
                                checkBox6.Checked = true;
                                Hook4.SelectedIndex = beam.Mid_Beam_Rebars_Hooks_Right.type;
                                Hook4_Text.Text = beam.Mid_Beam_Rebars_Hooks_Right.Length.ToString();
                            }
                            if (beam.Stirrup_info!=null&&beam.Stirrup_info.Count > 0)
                            {
                                for (int i = 0; i < beam.Stirrup_info.Count; i++)
                                {
                                    dataGridView1.Rows[i].Cells[0].Value = beam.Stirrup_info[i].D;//直径
                                    dataGridView1.Rows[i].Cells[1].Value = beam.Stirrup_info[i].Sa;//间距
                                    dataGridView1.Rows[i].Cells[2].Value = beam.Stirrup_info[i].n;//肢数
                                    dataGridView1.Rows[i].Cells[3].Value = beam.Stirrup_info[i].Se;//距离
                                }
                            }

                            break;
                        }
                    }
            });
            th.Start();
        }
        private string Rebar2String(List<Rebar_Dim> rebars)
        {
            string val = "";
            if (rebars.Count > 0)
            {
                if (rebars.Count > 1)
                {
                    int c = 0;
                    rebars.ForEach((item) =>
                    {
                        if (c != 0)
                            val += "/";
                        c += item.n;
                        val += $"{item.n}";
                    });
                    val = $"{c}Φ{rebars[0].D} " + val;
                }
                else
                    val = $"{rebars[0].n}Φ{rebars[0].D}";
            }
            return val;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            {
                Beam beam = Mybeam.beams.Find(x => x.PM_Line.Find(c => c == LineID) != null);
                if (beam != null)
                {
                    Mybeam.Concrete_type = Concrete_type.Text;
                    Mybeam.Rebar_type = Rebar_type.Text;
                    Mybeam.Strup_type = Stirrup_type.Text;
                    Mybeam.earth_type = earth_type.Text;
                    beam.type = combo_linetype.Text;
                    beam.id = GUID_Box.Text;
                    if (check_gj.Checked)
                    {
                        beam.overmm = over_box.Text;
                        beam.Rebar_overmm = Stirrup_type2.Text;
                    }
                    {
                        beam.Sections[0].b = Convert.ToDouble(sectionsb.Text);
                        beam.Sections[0].h = Convert.ToDouble(sectionsh.Text);
                    }
                    if (waist.Text != "" && waist.Text[0] == 'G')//G
                    {
                        //waist.Text = $"G{beam.Waist_Bar[0].n}Φ{beam.Waist_Bar[0].D}";
                        beam.Waist_Bar = new List<Rebar_Dim>();
                        Rebar_DimChange(waist.Text, ref beam);
                    }
                    if (Twist.Text != "" && Twist.Text[0] == 'N')//N
                    {
                        //Twist.Text = $"N{beam.Twist_Bar[0].n}Φ{beam.Twist_Bar[0].D}";
                        beam.Twist_Bar = new List<Rebar_Dim>();
                        Rebar_DimChange(Twist.Text, ref beam);
                    }
                    beam.Public_Bar = new List<Rebar_Dim>();
                    Rebar_DimChange(publicbar.Text, ref beam);
                    //publicbar.Text = Rebar2String(beam.Public_Bar);
                    if (checkBox1.Checked)
                    {
                        beam.Public_Bar_Hooks_Left = new Hooks();
                        beam.Public_Bar_Hooks_Left.type = Hook1.SelectedIndex;
                        beam.Public_Bar_Hooks_Left.Length = Convert.ToDouble(Hook1_Text.Text);
                    }
                    else beam.Public_Bar_Hooks_Left = null;

                    if (checkBox2.Checked)
                    {
                        beam.Public_Bar_Hooks_Right = new Hooks();
                        beam.Public_Bar_Hooks_Right.type = Hook2.SelectedIndex;
                        beam.Public_Bar_Hooks_Right.Length = Convert.ToDouble(Hook2_Text.Text);
                    }
                    else beam.Public_Bar_Hooks_Right = null;

                    beam.Left_Seat_Rebars = new List<List<Rebar_Dim>>();
                    beam.Left_Seat_Rebars.Add(SeatRebarChange(LeftSeatRebars.Text));
                    //Rebar_DimChange(LeftSeatRebars.Text,ref beam);
                    beam.LeftSeatLen = Convert.ToDouble(LeftSeatLen.Text);
                    if (checkBox3.Checked)
                    {
                        beam.Left_Seat_Rebars_Hooks_Left = new Hooks();
                        beam.Left_Seat_Rebars_Hooks_Left.type = Hook5.SelectedIndex;
                        beam.Left_Seat_Rebars_Hooks_Left.Length = Convert.ToDouble(Hook5_Text.Text);
                    }
                    else beam.Left_Seat_Rebars_Hooks_Left = null;
                    beam.Right_Seat_Rebars = new List<List<Rebar_Dim>>();
                    beam.Right_Seat_Rebars.Add(SeatRebarChange(RightSeatRebars.Text));
                    //Rebar_DimChange(RightSeatRebars.Text,ref beam);
                    beam.RightSeatLen = Convert.ToDouble(RightSeatLen.Text);
                    if (checkBox4.Checked)
                    {
                        beam.Right_Seat_Rebars_Hooks_Right = new Hooks();
                        beam.Right_Seat_Rebars_Hooks_Right.type = Hook6.SelectedIndex;
                        beam.Right_Seat_Rebars_Hooks_Right.Length = Convert.ToDouble(Hook6_Text.Text);
                    }
                    else beam.Right_Seat_Rebars_Hooks_Right = null;

                    beam.Mid_Beam_Rebars = new List<List<Rebar_Dim>>();
                    Rebar_DimChange(MidBeamRebars.Text, ref beam);
                    if (checkBox5.Checked)
                    {
                        beam.Mid_Beam_Rebars_Hooks_Left = new Hooks();
                        beam.Mid_Beam_Rebars_Hooks_Left.type = Hook3.SelectedIndex;
                        beam.Mid_Beam_Rebars_Hooks_Left.Length = Convert.ToDouble(Hook3_Text.Text);
                    }
                    else beam.Mid_Beam_Rebars_Hooks_Left = null;
                    if (checkBox6.Checked)
                    {
                        beam.Mid_Beam_Rebars_Hooks_Right = new Hooks();
                        beam.Mid_Beam_Rebars_Hooks_Right.type = Hook4.SelectedIndex;
                        beam.Mid_Beam_Rebars_Hooks_Right.Length = Convert.ToDouble(Hook4_Text.Text);
                    }
                    else beam.Mid_Beam_Rebars_Hooks_Right = null;


                    beam.Stirrup_info = new List<Stirrup_Dim>();
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            try
                            {
                                beam.Stirrup_info.Add(new Stirrup_Dim
                                {
                                    D = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value),//直径
                                    Sa = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),//间距
                                    n = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value),//肢数
                                    Se = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)//距离
                                });
                            }
                            catch { }
                        }
                    }
                }
                transf("Save");
                this.Close();
            }
        }
        private void Rebar_DimChange(string text, ref Beam beam1)
        {
            //梁截面
            string kval = Regex.Match(text, @"(\d{2,4}~)?(\d{2,4})(x|X)(\d{2,4})(~\d{2,4})?").Value;
            string[] vals = kval.Split(new char[] { '~', 'x', 'X' });
            if (kval != "")
            {
                if (kval.IndexOf('~') == -1)
                {
                    beam1.Sections.Add(new Beam_Section
                    {
                        a = 1,
                        b = Convert.ToDouble(vals[0]),
                        h = Convert.ToDouble(vals[1])
                    });
                }
                else
                {
                    if (kval.IndexOf("x", StringComparison.OrdinalIgnoreCase) > kval.IndexOf('~'))
                    {
                        //变截面宽  350~450x700
                        beam1.Sections.Add(new Beam_Section
                        {
                            a = 1,
                            b = Convert.ToDouble(vals[0]),
                            h = Convert.ToDouble(vals[2]),
                        });
                        beam1.Sections.Add(new Beam_Section
                        {
                            a = 1,
                            b = Convert.ToDouble(vals[1]),
                            h = Convert.ToDouble(vals[2]),
                        });
                    }
                    else
                    {
                        //变截面高   350x650~800
                        beam1.Sections.Add(new Beam_Section
                        {
                            a = 1,
                            b = Convert.ToDouble(vals[0]),
                            h = Convert.ToDouble(vals[1]),
                        });
                        beam1.Sections.Add(new Beam_Section
                        {
                            a = 1,
                            b = Convert.ToDouble(vals[0]),
                            h = Convert.ToDouble(vals[2]),
                        });
                    }
                }
                return;
            }
            //箍筋   Φ12@100/200(4)                           
            kval = Regex.Match(text, @"((%%130)|(%%131)|(%%132))(\d{1,3})@(\d{2,3})(/\d{2,3})?\(\d{1,2}\)").Value;
            if (kval != "")
            {
                beam1.Stirrup_info.Add(new Stirrup_Dim
                {
                    D = Convert.ToDouble(kval.Substring(5, kval.IndexOf('@') - 5)),
                    Se = Convert.ToDouble(SplitStr(kval, kval.IndexOf('@'), "/(")),
                    Sa = Convert.ToDouble(SplitStr(kval, kval.IndexOf('/'), "((")),
                    n = Convert.ToInt32(SplitStr(kval, kval.IndexOf('('), "))"))
                });
                return;
            }
            //通长钢筋   4Φ20;7Φ20 3/4
            kval = Regex.Match(text, @"^[A-Z]{0}(\(?\d{1,3}%%132\d{1,3}\)?)(\+\(?\d{1,3}%%132\d{1,3}\))?;?(\(?\d{1,3}%%132\d{1,3}\)?)?\s?(/?(\d{1,3})?)*").Value;
            if (kval != "")
            {
                string[] sp1 = kval.Split(';');
                for (int v = 0; v < sp1.Count(); v++)
                {
                    string[] sp2 = sp1[v].Split('+');
                    for (int f = 0; f < sp2.Count(); f++)
                    {
                        sp2[f] = sp2[f].Replace("(", "");
                        sp2[f] = sp2[f].Replace(")", "");
                        sp2[f] = sp2[f].Replace("%%132", "|");
                        string[] sp3 = sp2[f].Split('|');
                        List<Rebar_Dim> Bdim = new List<Rebar_Dim>();
                        if (sp2[f].IndexOf('/') == -1)
                        {
                            int c = 0;
                            if (sp2.Count() > 1) c = f + 1;
                            if (v == 1)
                                Bdim.Add(new Rebar_Dim
                                {
                                    C = c,
                                    n = Convert.ToInt32(sp3[0]),
                                    D = Convert.ToInt32(sp3[1])
                                });
                            else
                                beam1.Public_Bar.Add(new Rebar_Dim
                                {
                                    C = c,
                                    n = Convert.ToInt32(sp3[0]),
                                    D = Convert.ToInt32(sp3[1])
                                });
                        }
                        else
                        {
                            sp3[1] = sp3[1].Split(' ')[0];
                            string xi = sp2[f].Substring(sp2[f].IndexOf(' '));
                            string[] sp4 = xi.Trim().Split('/');
                            for (int s = 0; s < sp4.Count(); s++)
                            {
                                if (v == 1)
                                    Bdim.Add(new Rebar_Dim
                                    {
                                        n = Convert.ToInt32(sp4[s]),
                                        D = Convert.ToInt32(sp3[1])
                                    });
                                else
                                    beam1.Public_Bar.Add(new Rebar_Dim
                                    {
                                        n = Convert.ToInt32(sp4[s]),
                                        D = Convert.ToInt32(sp3[1])
                                    });
                            }
                        }
                        beam1.Mid_Beam_Rebars.Add(Bdim);
                    }
                }
                return;
            }
            //腰筋   G4Φ12+N4Φ12
            kval = Regex.Match(text, @"(\+?(G|N)\d{1,3}%%132\d{1,3})*").Value;
            if (kval != null)
            {
                string[] sp1 = kval.Split('+');
                for (int c = 0; c < sp1.Length; c++)
                {
                    sp1[c] = sp1[c].Replace("%%132", "|");
                    string[] sp2 = sp1[c].Split('|');
                    if (sp2.Length == 2)
                    {
                        char G = sp2[0][0];
                        int N = Convert.ToInt32(sp2[0].Substring(1));
                        int C = 0; if (sp1.Length == 2) C = c + 1;
                        if (G == 'G')
                            beam1.Waist_Bar.Add(new Rebar_Dim
                            {
                                n = N,
                                C = C,
                                D = Convert.ToDouble(sp2[1])
                            });
                        if (G == 'N')
                            beam1.Twist_Bar.Add(new Rebar_Dim
                            {
                                n = N,
                                C = C,
                                D = Convert.ToDouble(sp2[1])
                            });
                    }
                }
                return;
            }
            //标高  (-0.150)
            kval = Regex.Match(text, @"(\(?-?\d{1,3}.\d{3}\)?)").Value;
            if (kval != null)
            {
                kval = kval.Replace("(", "");
                kval = kval.Replace(")", "");
                beam1.Sections = beam1.Sections.Select(x => { x.H = Convert.ToDouble(kval); return x; }).ToList();
            }
        }
        public string SplitStr(string str, int start, string regex)
        {
            string temp = "0";
            if (start == -1) return temp;
            start += 1;
            if (str.IndexOf(regex[0]) != -1)
                temp = str.Substring(start, str.IndexOf(regex[0]) - start);
            else if (str.IndexOf(regex[1]) != -1)
                temp = str.Substring(start, str.IndexOf(regex[1]) - start);
            return temp;

        }
        private List<Rebar_Dim> SeatRebarChange(string text)
        {
            string kval = Regex.Match(text, @"^[A-Z]{0}(\(?\d{1,3}%%132\d{1,3}\)?)(\+\(?\d{1,3}%%132\d{1,3}\))?;?(\(?\d{1,3}%%132\d{1,3}\)?)?\s?(/?(\d{1,3})?)*").Value;
            if (kval != "")
            {
                string[] sp1 = kval.Split(';');
                for (int v = 0; v < sp1.Count(); v++)
                {
                    string[] sp2 = sp1[v].Split('+');
                    for (int f = 0; f < sp2.Count(); f++)
                    {
                        sp2[f] = sp2[f].Replace("(", "");
                        sp2[f] = sp2[f].Replace(")", "");
                        sp2[f] = sp2[f].Replace("%%132", "|");
                        string[] sp3 = sp2[f].Split('|');
                        List<Rebar_Dim> Bdim = new List<Rebar_Dim>();
                        if (sp2[f].IndexOf('/') == -1)
                        {
                            int c = 0;
                            if (sp2.Count() > 1) c = f + 1;
                            if (v == 1)
                                Bdim.Add(new Rebar_Dim
                                {
                                    C = c,
                                    n = Convert.ToInt32(sp3[0]),
                                    D = Convert.ToInt32(sp3[1])
                                });
                        }
                        else
                        {
                            sp3[1] = sp3[1].Split(' ')[0];
                            string xi = sp2[f].Substring(sp2[f].IndexOf(' '));
                            string[] sp4 = xi.Trim().Split('/');
                            for (int s = 0; s < sp4.Count(); s++)
                            {
                                Bdim.Add(new Rebar_Dim
                                {
                                    n = Convert.ToInt32(sp4[s]),
                                    D = Convert.ToInt32(sp3[1])
                                });
                            }
                        }
                        return Bdim;
                    }
                }
            }
            return new List<Rebar_Dim>();
        }
    }
}
