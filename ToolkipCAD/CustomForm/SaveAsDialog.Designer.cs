namespace ToolkipCAD.CustomForm
{
    partial class SaveAsDialog
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
            this.iscreateProjectmenu = new System.Windows.Forms.CheckBox();
            this.select_menu = new System.Windows.Forms.Button();
            this.select_menu_path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iscreateProjectmenu
            // 
            this.iscreateProjectmenu.AutoSize = true;
            this.iscreateProjectmenu.Location = new System.Drawing.Point(213, 55);
            this.iscreateProjectmenu.Name = "iscreateProjectmenu";
            this.iscreateProjectmenu.Size = new System.Drawing.Size(96, 16);
            this.iscreateProjectmenu.TabIndex = 6;
            this.iscreateProjectmenu.Text = "生成工程目录";
            this.iscreateProjectmenu.UseVisualStyleBackColor = true;
            // 
            // select_menu
            // 
            this.select_menu.Location = new System.Drawing.Point(254, 17);
            this.select_menu.Name = "select_menu";
            this.select_menu.Size = new System.Drawing.Size(55, 22);
            this.select_menu.TabIndex = 7;
            this.select_menu.Text = "浏览";
            this.select_menu.UseVisualStyleBackColor = true;
            this.select_menu.Click += new System.EventHandler(this.select_menu_Click);
            // 
            // select_menu_path
            // 
            this.select_menu_path.Location = new System.Drawing.Point(62, 18);
            this.select_menu_path.Name = "select_menu_path";
            this.select_menu_path.Size = new System.Drawing.Size(186, 21);
            this.select_menu_path.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "位置:";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(243, 97);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(67, 23);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(157, 97);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(67, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // SaveAsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(322, 132);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.iscreateProjectmenu);
            this.Controls.Add(this.select_menu);
            this.Controls.Add(this.select_menu_path);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveAsDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 另存为";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox iscreateProjectmenu;
        private System.Windows.Forms.Button select_menu;
        private System.Windows.Forms.TextBox select_menu_path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}