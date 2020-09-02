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

namespace ToolkipCAD.CustomForm
{
    public partial class AddDrawingDialog : Form
    {
        public delegate void CallBack(Object param);
        public event CallBack transf;
        public AddDrawingDialog()
        {
            InitializeComponent();
        }
        private void btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "dwg文件|*.dwg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                inputdwg_path.Text = fileDialog.FileName;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic pa = Program.MainForm.Tag;
                FileInfo file = new FileInfo(inputdwg_path.Text);
                File.Copy(file.FullName, $@"{pa.path}\src\{file.Name}", true);
                transf(file.Name.Substring(0,file.Name.LastIndexOf('.')));
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
