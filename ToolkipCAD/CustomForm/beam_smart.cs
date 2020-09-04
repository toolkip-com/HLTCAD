using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ToolkipCAD
{
    public partial class beam_smart : Form
    {
        //与主窗体交互的委托
        public delegate object TransForm(Object param);
        public event TransForm transf;
        public Beam_XRrecord beam=new Beam_XRrecord();
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
                List<Drawing_Manage> ComboSource=((List<Drawing_Manage>)tag.list).Where(x => x.type == Drawing_type.配置).ToList();
                combox_peizhi.DataSource = ComboSource;
                combox_peizhi.ValueMember = "id";
                combox_peizhi.DisplayMember = "name";
                if (tag.json != null)
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
                    combox_peizhi.Text =Dlist==null?"":Dlist.name;
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
            beam.Drawing_Manage_id = combox_peizhi.SelectedValue!=null? combox_peizhi.SelectedValue.ToString():"";
            transf("SaveData");
            
            this.Close(); 
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
                    beam.pto = new List<Point3d> { new Point3d { X=Kven.Lx,Y=Kven.Ly}, new Point3d { X = Kven.Rx, Y = Kven.Ry } };
                    return;
                }
            }
            if(select_range.Text=="显示") transf("Range");
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
    }
}
