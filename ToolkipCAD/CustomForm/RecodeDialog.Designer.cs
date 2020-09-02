namespace ToolkipCAD.CustomForm
{
    partial class RecodeDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.input_recode = new System.Windows.Forms.TextBox();
            this.inputdwg_path = new System.Windows.Forms.TextBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.import_panel = new System.Windows.Forms.Panel();
            this.import_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "基于图纸:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 12;
            this.comboBox1.Location = new System.Drawing.Point(80, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(112, 136);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(67, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
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
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(198, 136);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(67, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "记录名称:";
            // 
            // input_recode
            // 
            this.input_recode.Location = new System.Drawing.Point(80, 14);
            this.input_recode.Name = "input_recode";
            this.input_recode.Size = new System.Drawing.Size(184, 21);
            this.input_recode.TabIndex = 3;
            // 
            // inputdwg_path
            // 
            this.inputdwg_path.Location = new System.Drawing.Point(55, 8);
            this.inputdwg_path.Name = "inputdwg_path";
            this.inputdwg_path.ReadOnly = true;
            this.inputdwg_path.Size = new System.Drawing.Size(144, 21);
            this.inputdwg_path.TabIndex = 3;
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
            // import_panel
            // 
            this.import_panel.Controls.Add(this.inputdwg_path);
            this.import_panel.Controls.Add(this.label2);
            this.import_panel.Controls.Add(this.btn_select);
            this.import_panel.Location = new System.Drawing.Point(27, 79);
            this.import_panel.Name = "import_panel";
            this.import_panel.Size = new System.Drawing.Size(238, 32);
            this.import_panel.TabIndex = 4;
            // 
            // RecodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(277, 168);
            this.Controls.Add(this.import_panel);
            this.Controls.Add(this.input_recode);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecodeDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建记录";
            this.Load += new System.EventHandler(this.RecodeDialog_Load);
            this.import_panel.ResumeLayout(false);
            this.import_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox input_recode;
        private System.Windows.Forms.TextBox inputdwg_path;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Panel import_panel;
    }
}