namespace ToolkipCAD.CustomForm
{
    partial class CreateProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.select_menu = new System.Windows.Forms.Button();
            this.iscreateProjectmenu = new System.Windows.Forms.CheckBox();
            this.select_menu_path = new System.Windows.Forms.TextBox();
            this.project_name = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select_menu
            // 
            this.select_menu.Location = new System.Drawing.Point(298, 82);
            this.select_menu.Name = "select_menu";
            this.select_menu.Size = new System.Drawing.Size(32, 22);
            this.select_menu.TabIndex = 3;
            this.select_menu.Text = "...";
            this.select_menu.UseVisualStyleBackColor = true;
            this.select_menu.Click += new System.EventHandler(this.select_menu_Click);
            // 
            // iscreateProjectmenu
            // 
            this.iscreateProjectmenu.AutoSize = true;
            this.iscreateProjectmenu.Location = new System.Drawing.Point(107, 54);
            this.iscreateProjectmenu.Name = "iscreateProjectmenu";
            this.iscreateProjectmenu.Size = new System.Drawing.Size(15, 14);
            this.iscreateProjectmenu.TabIndex = 2;
            this.iscreateProjectmenu.UseVisualStyleBackColor = true;
            // 
            // select_menu_path
            // 
            this.select_menu_path.Location = new System.Drawing.Point(107, 83);
            this.select_menu_path.Name = "select_menu_path";
            this.select_menu_path.Size = new System.Drawing.Size(185, 21);
            this.select_menu_path.TabIndex = 1;
            // 
            // project_name
            // 
            this.project_name.Location = new System.Drawing.Point(107, 21);
            this.project_name.Name = "project_name";
            this.project_name.Size = new System.Drawing.Size(223, 21);
            this.project_name.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(263, 126);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(67, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.project_cencel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(177, 126);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(67, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.project_activepro_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "保存目录:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "项目名称:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "生成工程目录:";
            // 
            // CreateProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.iscreateProjectmenu);
            this.Controls.Add(this.select_menu);
            this.Controls.Add(this.project_name);
            this.Controls.Add(this.select_menu_path);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProjectForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button select_menu;
        private System.Windows.Forms.CheckBox iscreateProjectmenu;
        private System.Windows.Forms.TextBox select_menu_path;
        private System.Windows.Forms.TextBox project_name;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}