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
            this.Create_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.project_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iscreateProjectmenu = new System.Windows.Forms.CheckBox();
            this.select_menu_path = new System.Windows.Forms.TextBox();
            this.select_menu = new System.Windows.Forms.Button();
            this.project_cencel = new System.Windows.Forms.Button();
            this.project_activepro = new System.Windows.Forms.Button();
            this.Create_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Create_Panel
            // 
            this.Create_Panel.Controls.Add(this.project_activepro);
            this.Create_Panel.Controls.Add(this.project_cencel);
            this.Create_Panel.Controls.Add(this.select_menu);
            this.Create_Panel.Controls.Add(this.iscreateProjectmenu);
            this.Create_Panel.Controls.Add(this.select_menu_path);
            this.Create_Panel.Controls.Add(this.project_name);
            this.Create_Panel.Controls.Add(this.label3);
            this.Create_Panel.Controls.Add(this.label2);
            this.Create_Panel.Controls.Add(this.label1);
            this.Create_Panel.Location = new System.Drawing.Point(2, 1);
            this.Create_Panel.Name = "Create_Panel";
            this.Create_Panel.Size = new System.Drawing.Size(448, 201);
            this.Create_Panel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(50, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称：";
            // 
            // project_name
            // 
            this.project_name.Location = new System.Drawing.Point(147, 20);
            this.project_name.Name = "project_name";
            this.project_name.Size = new System.Drawing.Size(270, 21);
            this.project_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "生成工程目录：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(88, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "目录：";
            // 
            // iscreateProjectmenu
            // 
            this.iscreateProjectmenu.AutoSize = true;
            this.iscreateProjectmenu.Location = new System.Drawing.Point(147, 69);
            this.iscreateProjectmenu.Name = "iscreateProjectmenu";
            this.iscreateProjectmenu.Size = new System.Drawing.Size(15, 14);
            this.iscreateProjectmenu.TabIndex = 2;
            this.iscreateProjectmenu.UseVisualStyleBackColor = true;
            // 
            // select_menu_path
            // 
            this.select_menu_path.Location = new System.Drawing.Point(144, 106);
            this.select_menu_path.Name = "select_menu_path";
            this.select_menu_path.Size = new System.Drawing.Size(232, 21);
            this.select_menu_path.TabIndex = 1;
            // 
            // select_menu
            // 
            this.select_menu.Location = new System.Drawing.Point(382, 105);
            this.select_menu.Name = "select_menu";
            this.select_menu.Size = new System.Drawing.Size(32, 22);
            this.select_menu.TabIndex = 3;
            this.select_menu.Text = "...";
            this.select_menu.UseVisualStyleBackColor = true;
            this.select_menu.Click += new System.EventHandler(this.select_menu_Click);
            // 
            // project_cencel
            // 
            this.project_cencel.Location = new System.Drawing.Point(125, 158);
            this.project_cencel.Name = "project_cencel";
            this.project_cencel.Size = new System.Drawing.Size(90, 31);
            this.project_cencel.TabIndex = 4;
            this.project_cencel.Text = "取消";
            this.project_cencel.UseVisualStyleBackColor = true;
            this.project_cencel.Click += new System.EventHandler(this.project_cencel_Click);
            // 
            // project_activepro
            // 
            this.project_activepro.Location = new System.Drawing.Point(221, 158);
            this.project_activepro.Name = "project_activepro";
            this.project_activepro.Size = new System.Drawing.Size(90, 31);
            this.project_activepro.TabIndex = 4;
            this.project_activepro.Text = "确定";
            this.project_activepro.UseVisualStyleBackColor = true;
            this.project_activepro.Click += new System.EventHandler(this.project_activepro_Click);
            // 
            // CreateProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 204);
            this.Controls.Add(this.Create_Panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProjectForm";
            this.Text = "新建项目";
            this.Create_Panel.ResumeLayout(false);
            this.Create_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Create_Panel;
        private System.Windows.Forms.Button project_activepro;
        private System.Windows.Forms.Button project_cencel;
        private System.Windows.Forms.Button select_menu;
        private System.Windows.Forms.CheckBox iscreateProjectmenu;
        private System.Windows.Forms.TextBox select_menu_path;
        private System.Windows.Forms.TextBox project_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}