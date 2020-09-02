namespace ToolkipCAD.CustomForm
{
    partial class AddDrawingDialog
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
            this.import_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.inputdwg_path = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.import_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // import_panel
            // 
            this.import_panel.Controls.Add(this.inputdwg_path);
            this.import_panel.Controls.Add(this.label2);
            this.import_panel.Controls.Add(this.btn_select);
            this.import_panel.Location = new System.Drawing.Point(12, 12);
            this.import_panel.Name = "import_panel";
            this.import_panel.Size = new System.Drawing.Size(246, 32);
            this.import_panel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "导入:";
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(205, 7);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(34, 23);
            this.btn_select.TabIndex = 2;
            this.btn_select.Text = "...";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // inputdwg_path
            // 
            this.inputdwg_path.Location = new System.Drawing.Point(55, 8);
            this.inputdwg_path.Name = "inputdwg_path";
            this.inputdwg_path.ReadOnly = true;
            this.inputdwg_path.Size = new System.Drawing.Size(144, 21);
            this.inputdwg_path.TabIndex = 3;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(185, 72);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(67, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(99, 72);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(67, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // AddDrawingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(270, 107);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.import_panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDrawingDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入图纸";
            this.import_panel.ResumeLayout(false);
            this.import_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel import_panel;
        private System.Windows.Forms.TextBox inputdwg_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}