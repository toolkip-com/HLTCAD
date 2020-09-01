using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolkipCAD.CustomForm
{
    public partial class ReNameDialog : Form
    {
        //用于传值的委托
        public delegate void TransfDelegate(String value);
        public ReNameDialog()
        {
            InitializeComponent();
        }
        public event TransfDelegate transf;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //确定事件
            if (input_value.Text != "")
            {
                transf(input_value.Text);
            }
            this.Close();
        }

        private void btn_cencel_Click(object sender, EventArgs e)
        {
            //取消事件
            this.Close();
        }

        private void ReNameDialog_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                input_value.Text = this.Tag.ToString();
            }
        }
    }
}
