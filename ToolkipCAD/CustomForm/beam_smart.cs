using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            if (this.Tag != null)
            {
                combox_peizhi.DataSource = ((List<Drawing_Manage>)this.Tag).Where(x=>x.type==Drawing_type.文件).ToList();
                combox_peizhi.ValueMember = "id";
                combox_peizhi.DisplayMember = "name";
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
            beam.Drawing_Manage_id = combox_peizhi.ValueMember;
            //保存
            StreamWriter sw = new StreamWriter(@"D:\好蓝图平面CAD钢筋\测试\试验图纸\1.txt",false,Encoding.UTF8);
            sw.WriteLine(JsonConvert.SerializeObject(beam));
            sw.Close();
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
                    select_range.Text = "显示";
                    select_range.Tag = Kven;
                    beam.pto = new List<Point3d> { new Point3d { X=Kven.Lx,Y=Kven.Ly}, new Point3d { X = Kven.Rx, Y = Kven.Ry } };
                    return;
                }
            }
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
        }
    }
}
