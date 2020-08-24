using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolkipCAD
{
    public partial class beam_smart : Form
    {
        //与主窗体交互的委托
        public delegate object TransForm(Object param);
        public event TransForm transf;
        private Beam_XRrecord beam;
        public beam_smart()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void beam_smart_Load(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

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
                    
                }
            }
        }
    }
}
