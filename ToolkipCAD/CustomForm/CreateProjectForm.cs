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

namespace ToolkipCAD.CustomForm
{
    public partial class CreateProjectForm : Form
    {
        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void select_menu_Click(object sender, EventArgs e)
        {
            //选择目录按钮
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog()==DialogResult.OK)
            {
                select_menu_path.Text = folderBrowser.SelectedPath;
            }            
        }
        private void project_cencel_Click(object sender, EventArgs e)
        {
            //取消创建项目
            this.Close();
        }

        private void project_activepro_Click(object sender, EventArgs e)
        {
            try
            {
                //验证目录
                if (project_name.Text == "" || select_menu_path.Text == "")
                {
                    MessageBox.Show("请填写项目信息");
                    return;
                }
                Regex pathex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
                Match presult = pathex.Match(select_menu_path.Text);
                if (!presult.Success)
                {
                    MessageBox.Show("所选目录不合法!");
                    return;
                }
                //验证成功
                string relayPath = select_menu_path.Text;
                if (iscreateProjectmenu.Checked)//勾选
                {
                    relayPath += $"\\{project_name.Text}";
                }
                    //创建目录
                    if (!Directory.Exists(relayPath)) Directory.CreateDirectory(relayPath);
                    if (!Directory.Exists(relayPath + "\\src")) Directory.CreateDirectory(relayPath + "\\src");
                    if (!Directory.Exists(relayPath + "\\project")) Directory.CreateDirectory(relayPath + "\\project");
                    if (!File.Exists(relayPath + $"\\{project_name}.hlt"))
                    {
                        StreamWriter sw = File.CreateText(relayPath + $"\\{project_name.Text}.hlt");
                        sw.WriteLine(project_name.Text);
                        sw.Close();
                    }
                MessageBox.Show("项目创建成功");
                this.Close();
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("项目创建失败:"+ex.Message);
            }
        }
        private bool CheckFileName(string name)
        {
            //验证文件名
            if (name == "") return false;
            string rule = "\\/:*?\"<>|";
            foreach (var item in rule)
            {
                if (name.Contains(item)) return false;
            }
            return true;
        }
    }
}
