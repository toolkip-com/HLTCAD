namespace ToolkipCAD.CustomForm
{
    partial class ReNameDialog
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
            this.input_value = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cencel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_value
            // 
            this.input_value.Location = new System.Drawing.Point(12, 12);
            this.input_value.Name = "input_value";
            this.input_value.Size = new System.Drawing.Size(251, 21);
            this.input_value.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(109, 41);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(67, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cencel
            // 
            this.btn_cencel.Location = new System.Drawing.Point(196, 41);
            this.btn_cencel.Name = "btn_cencel";
            this.btn_cencel.Size = new System.Drawing.Size(67, 23);
            this.btn_cencel.TabIndex = 1;
            this.btn_cencel.Text = "取消";
            this.btn_cencel.UseVisualStyleBackColor = true;
            this.btn_cencel.Click += new System.EventHandler(this.btn_cencel_Click);
            // 
            // ReNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 76);
            this.Controls.Add(this.btn_cencel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.input_value);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReNameDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重命名";
            this.Load += new System.EventHandler(this.ReNameDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_value;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cencel;
    }
}