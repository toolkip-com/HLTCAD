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
    public partial class RecodeDialog : Form
    {
        public delegate void TransfDelegate(dynamic value);
        public RecodeDialog()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            //文件选择按钮
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "dwg文件|*.dwg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                inputdwg_path.Text = fileDialog.FileName;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //取消
            this.Close();
        }
        public event TransfDelegate transf;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //确定
            try
            {
                if (input_recode.Text != "")
                {
                    //copy文件
                    if(inputdwg_path.Text!="")
                    {
                        dynamic Propath=Program.MainForm.Tag;
                        //FileInfo file = new FileInfo(inputdwg_path.Text);
                        File.Copy(inputdwg_path.Text,$@"{Propath.path}\src\{input_recode.Text}.dwg",true);
                    }
                    //委托传值
                    transf(new
                    {
                        name = input_recode.Text,
                        combo = comboBox1.SelectedItem,
                        file = inputdwg_path.Text
                    });
                    this.Close();
                }
                else MessageBox.Show("请输入记录名称");
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建失败:" + ex.Message);
            }
        }

        private void RecodeDialog_Load(object sender, EventArgs e)
        {
            //初始化事件
            if (this.Tag != null)
            {
                dynamic edit = (dynamic)this.Tag;
                input_recode.Text = edit.name;
                List<Drawing_Manage> drawing_s = edit.oner;
                foreach (var item in drawing_s)
                {
                    //if(item.type==Drawing_type.文件)
                    comboBox1.Items.Add(item.name);
                }
                if (comboBox1.Items.Count>0)
                comboBox1.SelectedIndex = 0;
            }
        }
    }
}
