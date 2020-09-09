using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MxDrawXLib;
using Newtonsoft.Json;
using ToolkipCAD.Models;

namespace ToolkipCAD
{
    public partial class beam_smart : Form
    {
        //与主窗体交互的委托
        public delegate object TransForm(Object param);
        public event TransForm transf;
        public Beam_XRrecord beam = new Beam_XRrecord();
        public beam_smart()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void beam_smart_Load(object sender, EventArgs e)
        {
            select_range.SelectedIndex = 0;
            Line_Get.SelectedIndex = 0;
            wiff_Get.SelectedIndex = 0;
            Msg_Get.SelectedIndex = 0;
            if (this.Tag != null)
            {
                dynamic tag = this.Tag;
                List<Drawing_Manage> ComboSource = ((List<Drawing_Manage>)tag.list).Where(x => x.type == Drawing_type.配置).ToList();
                combox_peizhi.DataSource = ComboSource;
                combox_peizhi.ValueMember = "id";
                combox_peizhi.DisplayMember = "name";
                if (tag.json != "null")
                {
                    beam = JsonConvert.DeserializeObject<Beam_XRrecord>(tag.json); //tag.json as Beam_XRrecord;
                    if (beam.pto != null) { select_range.Text = "显示"; transf("Range"); }
                    //if (beam.side_lines != null) Line_Get.Text = "显示";
                    //if (beam.dim_texts != null) wiff_Get.Text = "显示";
                    //if (beam.seat_lines != null) Msg_Get.Text = "显示";
                    combox_Hnt.Text = beam.Concrete_type;
                    combox_Lzj.Text = beam.Rebar_type;
                    combox_Lgj.Text = beam.Strup_type;
                    combox_kzdj.Text = beam.earth_type;
                    Drawing_Manage Dlist = ComboSource.Find(x => x.id == beam.Drawing_Manage_id);
                    combox_peizhi.Text = Dlist == null ? "" : Dlist.name;
                    if (beam.overmm != null)
                    {
                        check_gj.Checked = true;
                        over_box.Text = beam.overmm;
                    }
                    if (beam.Rebar_overmm != null) combox_Gjcy.Text = beam.Rebar_overmm;
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (check_hebin.Checked)
            {

            }
            if (check_gj.Checked)//超过N mm
            {
                beam.overmm = over_box.Text;
                beam.Rebar_overmm = combox_Gjcy.Text;
            }
            beam.Concrete_type = combox_Hnt.Text;
            beam.Rebar_type = combox_Lzj.Text;
            beam.Strup_type = combox_Lgj.Text;
            beam.earth_type = combox_kzdj.Text;
            beam.Drawing_Manage_id = combox_peizhi.SelectedValue != null ? combox_peizhi.SelectedValue.ToString() : "";
            FillBeamStruct();
            //transf("SaveData");            
            //this.Close(); 
        }

        private void select_range_SelectedIndexChanged(object sender, EventArgs e)
        {
            //识别范围
            dynamic Kven;
            if (select_range.Text == "窗口")
            {
                Kven = transf("select_range");
                if (Kven != null)
                {
                    //select_range.Text = "显示";
                    //select_range.Tag = Kven;
                    beam.pto = new List<Point3d> { new Point3d { X = Kven.Lx, Y = Kven.Ly }, new Point3d { X = Kven.Rx, Y = Kven.Ry } };
                    return;
                }
            }
            if (select_range.Text == "显示") transf("Range");
        }

        private void Line_Get_SelectedIndexChanged(object sender, EventArgs e)
        {
            //梁拾取
            if (Line_Get.Text == "拾取")
            {
                object Kven = transf("change_line");
                if (Kven != null)
                {
                    Line_Get.Text = "显示";
                }
            }
            if (Line_Get.Text == "显示")
            {
                wiff_Get.Text = "请选择";
                Msg_Get.Text = "请选择";
                transf("show_line");
            }
        }

        private void wiff_Get_SelectedIndexChanged(object sender, EventArgs e)
        {
            //标注拾取
            if (wiff_Get.Text == "拾取")
            {
                object Kven = transf("change_dim");
                if (Kven != null)
                {
                    wiff_Get.Text = "显示";
                }
            }
            if (wiff_Get.Text == "显示")
            {
                Line_Get.Text = "请选择";
                Msg_Get.Text = "请选择";
                transf("show_dims");
            }
        }

        private void Msg_Get_SelectedIndexChanged(object sender, EventArgs e)
        {
            //支座信息
            if (Msg_Get.Text == "拾取")
            {
                object Kven = transf("change_seat");
                if (Kven != null)
                {
                    Msg_Get.Text = "显示";
                }
            }
            if (Msg_Get.Text == "显示")
            {
                Line_Get.Text = "请选择";
                wiff_Get.Text = "请选择";
                transf("show_seat");
            }
        }
        private void FillBeamStruct()
        {
            #region beam
            HLTSmart smart = new HLTSmart();
            //第一步：遍历所有文字，找出满足如下正则表达式的文字，即为集中标注第一行
            List<Regex> regex1 = new List<Regex> {
                //new Regex(@"(KL|L|WKL|WL|KZL|LL|JL|DL)[-]?\d{1,4}")
                new Regex(@"((KL|L|WKL|WL|KZL|LL|JL|DL)(\d{1,4})\([A-Z0-9]{1,4}\)\s)?(\d{1,4})X(\d{1,4})")
                };
            List<Text> texts = new List<Text>();
            //获取dim_text值
            MxDrawText entity;
            foreach (var item in beam.dim_texts)
            {
                entity = Program.MainForm.axMxDrawX1.HandleToObject(item) as MxDrawText;
                if (entity != null)
                    texts.Add(new Text
                    {
                        Position = new Point3d { X = entity.Position.x, Y = entity.Position.y, Z = entity.Position.z },
                        Layer = entity.Layer,
                        TextString = entity.TextString,
                        Height = entity.Height,
                        Rotation = entity.Rotation
                    });
            }
            List<Text> Restexts = smart.GetWord(texts, regex1);
            //第二步：找到后还需验证这个字的左侧定位点 字体高度2倍范围内有无直线（即指示线）
            Point3d pt = new Point3d();
            MxDrawSelectionSet select = new MxDrawSelectionSet();
            foreach (var item in Restexts)
            {
                pt = item.Position;
                MxDrawPoint pt1 = new MxDrawPoint
                {
                    x = pt.X - 2 * item.Height,
                    y = pt.Y - 2 * item.Height,
                    z = pt.Z
                };
                MxDrawPoint pt2 = new MxDrawPoint
                {
                    x = pt.X + 2 * item.Height,
                    y = pt.Y + 2 * item.Height,
                    z = pt.Z
                };
                //Program.MainForm.axMxDrawX1.DrawLine(pt.X, pt.Y, pt.X+1, pt.Y+1);
                //Program.MainForm.axMxDrawX1.DrawLine(pt1.x, pt1.y, pt1.x, pt2.y);
                //Program.MainForm.axMxDrawX1.DrawLine(pt1.x, pt2.y, pt2.x, pt2.y);
                //Program.MainForm.axMxDrawX1.DrawLine(pt2.x, pt2.y, pt2.x, pt1.y);
                //Program.MainForm.axMxDrawX1.DrawLine(pt2.x, pt1.y, pt1.x, pt1.y);
                select.Select(MCAD_McSelect.mcSelectionSetCrossing, pt1, pt2, new MxDrawResbuf());
                MxDrawLine drawEntity; MxDrawPoint pst, ped;
                List<Text> text3 = new List<Text>();
                for (int i = 0; i < select.Count; i++)
                {
                    drawEntity = select.Item(i) as MxDrawLine;
                    //第三步：遍历第二步的结果，逐一按下面计算，例如第n个结果
                    if (drawEntity != null && drawEntity.ObjectName == "McDbLine")
                    {
                        pst = drawEntity.GetStartPoint();
                        //ped =drawEntity.GetEndPoint();
                        text3 = smart.SelectTextByBox(texts, new Point3d
                        {
                            X = pst.x,
                            Y = pst.y,
                            Z = pst.z
                        }, item.Position);
                        //第四步：从第三步结果中逐行用关键字匹配出参数信息
                        Beam beams = new Beam();
                        beams.Sections = new List<Beam_Section>();
                        beams.Stirrup_info = new List<Stirrup_Dim>();
                        beams.Public_Bar = new List<Rebar_Dim>();
                        beams.Mid_Beam_Rebars = new List<List<Rebar_Dim>>();
                        beams.Waist_Bar = new List<Rebar_Dim>();
                        beams.Twist_Bar = new List<Rebar_Dim>();
                        string kval = "";
                        for (int k = 0; k < text3.Count; k++)
                        {
                            //KL14(1A) 300X400
                            kval = Regex.Match(text3[k].TextString, @"(KL|L|WKL|WL|KZL|LL|JL|DL)").Value;
                            if (kval != "")
                            {
                                beams.type = kval;//(Side_type)Enum.Parse(typeof(Side_type),kval);
                            }
                            //梁截面
                            kval = Regex.Match(text3[k].TextString, @"(\d{2,4}~)?(\d{2,4})(x|X)(\d{2,4})(~\d{2,4})?").Value;
                            string[] vals = kval.Split(new char[] { '~', 'x', 'X' });
                            if (kval != "")
                            {
                                if (kval.IndexOf('~') == -1)
                                {
                                    beams.Sections.Add(new Beam_Section
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
                                        beams.Sections.Add(new Beam_Section
                                        {
                                            a = 1,
                                            b = Convert.ToDouble(vals[0]),
                                            h = Convert.ToDouble(vals[2]),
                                        });
                                        beams.Sections.Add(new Beam_Section
                                        {
                                            a = 1,
                                            b = Convert.ToDouble(vals[1]),
                                            h = Convert.ToDouble(vals[2]),
                                        });
                                    }
                                    else
                                    {
                                        //变截面高   350x650~800
                                        beams.Sections.Add(new Beam_Section
                                        {
                                            a = 1,
                                            b = Convert.ToDouble(vals[0]),
                                            h = Convert.ToDouble(vals[1]),
                                        });
                                        beams.Sections.Add(new Beam_Section
                                        {
                                            a = 1,
                                            b = Convert.ToDouble(vals[0]),
                                            h = Convert.ToDouble(vals[2]),
                                        });
                                    }
                                }
                                continue;
                            }
                            //箍筋   Φ12@100/200(4)                           
                            kval = Regex.Match(text3[k].TextString, @"((%%130)|(%%131)|(%%132))(\d{1,3})@(\d{2,3})(/\d{2,3})?\(\d{1,2}\)").Value;
                            if (kval != "")
                            {
                                beams.Stirrup_info.Add(new Stirrup_Dim
                                {
                                    D = Convert.ToDouble(kval.Substring(5, kval.IndexOf('@') - 5)),
                                    Se = Convert.ToDouble(SplitStr(kval, kval.IndexOf('@'), "/(")),
                                    Sa = Convert.ToDouble(SplitStr(kval, kval.IndexOf('/'), "((")),
                                    n = Convert.ToInt32(SplitStr(kval, kval.IndexOf('('), "))"))
                                });
                                continue;
                            }
                            //通长钢筋   4Φ20;7Φ20 3/4
                            kval = Regex.Match(text3[k].TextString, @"^[A-Z]{0}(\(?\d{1,3}%%132\d{1,3}\)?)(\+\(?\d{1,3}%%132\d{1,3}\))?;?(\(?\d{1,3}%%132\d{1,3}\)?)?\s?(/?(\d{1,3})?)*").Value;
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
                                            if (v==1)
                                                Bdim.Add(new Rebar_Dim
                                                {
                                                    C = c,
                                                    n = Convert.ToInt32(sp3[0]),
                                                    D = Convert.ToInt32(sp3[1])
                                                });
                                            else
                                            beams.Public_Bar.Add(new Rebar_Dim
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
                                                    beams.Public_Bar.Add(new Rebar_Dim
                                                    {
                                                        n = Convert.ToInt32(sp4[s]),
                                                        D = Convert.ToInt32(sp3[1])
                                                    });
                                            }
                                        }
                                        beams.Mid_Beam_Rebars.Add(Bdim);
                                    }
                                }
                                continue;
                            }
                            //腰筋   G4Φ12+N4Φ12
                            kval = Regex.Match(text3[k].TextString, @"(\+?(G|N)\d{1,3}%%132\d{1,3})*").Value;
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
                                            beams.Waist_Bar.Add(new Rebar_Dim
                                            {
                                                n = N,
                                                C = C,
                                                D = Convert.ToDouble(sp2[1])
                                            });
                                        if (G == 'N')
                                            beams.Twist_Bar.Add(new Rebar_Dim
                                            {
                                                n = N,
                                                C = C,
                                                D = Convert.ToDouble(sp2[1])
                                            });
                                    }
                                }
                                continue;
                            }
                            //标高  (-0.150)
                            kval = Regex.Match(text3[k].TextString, @"(\(?-?\d{1,3}.\d{3}\)?)").Value;
                            if (kval != null)
                            {
                                kval = kval.Replace("(", "");
                                kval = kval.Replace(")", "");
                                beams.Sections = beams.Sections.Select(x => { x.H = Convert.ToDouble(kval); return x; }).ToList();
                            }

                        }
                        beam.beams.Add(beams);
                    }
                }
            }
            #endregion
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
    }
}
