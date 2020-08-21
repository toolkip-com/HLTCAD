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
                    if (inputdwg_path.Text == "" && comboBox1.Text == "") return;
                    //copy文件
                    if(inputdwg_path.Text!="")
                    {
                        dynamic Propath=Program.MainForm.Tag;
                        FileInfo file = new FileInfo(inputdwg_path.Text);
                        File.Copy(inputdwg_path.Text,$@"{Propath.path}\src\{file.Name}",true);
                    }
                    //委托传值
                    transf(new
                    {
                        name = input_recode.Text,
                        combo = comboBox1.SelectedValue,
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
                drawing_s.Insert(0,new Drawing_Manage
                {
                    id="",
                    pid="",
                    name="导入",
                    type=Drawing_type.文件
                });
                comboBox1.DataSource = drawing_s.Where(x => x.type == Drawing_type.文件).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                    
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //导入还是基于图纸
            if (comboBox1.Text == "导入")
                import_panel.Visible = true;
            else
            {
                inputdwg_path.Text = "";
                import_panel.Visible = false;
            }
        }
    }
}
