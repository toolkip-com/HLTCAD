namespace ToolkipCAD
{
    partial class beam_smart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.select_range = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Line_Get = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wiff_Get = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Msg_Get = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.combox_peizhi = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.combox_kzdj = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.combox_Gjcy = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.over_box = new System.Windows.Forms.TextBox();
            this.check_gj = new System.Windows.Forms.CheckBox();
            this.combox_Lgj = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.combox_Lzj = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combox_Hnt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.check_hebin = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.select_range);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "识别范围";
            // 
            // select_range
            // 
            this.select_range.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.select_range.FormattingEnabled = true;
            this.select_range.Items.AddRange(new object[] {
            "显示",
            "窗口"});
            this.select_range.Location = new System.Drawing.Point(92, 25);
            this.select_range.Name = "select_range";
            this.select_range.Size = new System.Drawing.Size(96, 20);
            this.select_range.TabIndex = 1;
            this.select_range.Text = "显示";
            this.select_range.SelectedIndexChanged += new System.EventHandler(this.select_range_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择范围：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // Line_Get
            // 
            this.Line_Get.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.Line_Get.FormattingEnabled = true;
            this.Line_Get.Items.AddRange(new object[] {
            "显示",
            "拾取"});
            this.Line_Get.Location = new System.Drawing.Point(92, 30);
            this.Line_Get.Name = "Line_Get";
            this.Line_Get.Size = new System.Drawing.Size(96, 20);
            this.Line_Get.TabIndex = 1;
            this.Line_Get.Text = "显示";
            this.Line_Get.SelectedIndexChanged += new System.EventHandler(this.Line_Get_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "梁线拾取：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wiff_Get);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.Line_Get);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 111);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "梁信息拾取";
            // 
            // wiff_Get
            // 
            this.wiff_Get.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.wiff_Get.FormattingEnabled = true;
            this.wiff_Get.Items.AddRange(new object[] {
            "显示",
            "拾取"});
            this.wiff_Get.Location = new System.Drawing.Point(92, 71);
            this.wiff_Get.Name = "wiff_Get";
            this.wiff_Get.Size = new System.Drawing.Size(96, 20);
            this.wiff_Get.TabIndex = 2;
            this.wiff_Get.Text = "显示";
            this.wiff_Get.SelectedIndexChanged += new System.EventHandler(this.wiff_Get_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "标注拾取：";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 0;
            // 
            // Msg_Get
            // 
            this.Msg_Get.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.Msg_Get.FormattingEnabled = true;
            this.Msg_Get.Items.AddRange(new object[] {
            "显示",
            "拾取"});
            this.Msg_Get.Location = new System.Drawing.Point(92, 23);
            this.Msg_Get.Name = "Msg_Get";
            this.Msg_Get.Size = new System.Drawing.Size(96, 20);
            this.Msg_Get.TabIndex = 1;
            this.Msg_Get.Text = "显示";
            this.Msg_Get.SelectedIndexChanged += new System.EventHandler(this.Msg_Get_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "信息拾取：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Msg_Get);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 59);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "支座信息拾取";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.combox_peizhi);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.combox_kzdj);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.combox_Gjcy);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.over_box);
            this.groupBox4.Controls.Add(this.check_gj);
            this.groupBox4.Controls.Add(this.combox_Lgj);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.combox_Lzj);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.combox_Hnt);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(237, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 259);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "材料及环境";
            // 
            // combox_peizhi
            // 
            this.combox_peizhi.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_peizhi.FormattingEnabled = true;
            this.combox_peizhi.Location = new System.Drawing.Point(125, 215);
            this.combox_peizhi.Name = "combox_peizhi";
            this.combox_peizhi.Size = new System.Drawing.Size(125, 20);
            this.combox_peizhi.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 220);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "构造配置方案：";
            // 
            // combox_kzdj
            // 
            this.combox_kzdj.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_kzdj.FormattingEnabled = true;
            this.combox_kzdj.Items.AddRange(new object[] {
            "四级",
            "三级",
            "二级",
            "一级",
            "特一级"});
            this.combox_kzdj.Location = new System.Drawing.Point(125, 183);
            this.combox_kzdj.Name = "combox_kzdj";
            this.combox_kzdj.Size = new System.Drawing.Size(125, 20);
            this.combox_kzdj.TabIndex = 12;
            this.combox_kzdj.Text = "四级";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "框架梁抗震等级：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "箍筋采用";
            // 
            // combox_Gjcy
            // 
            this.combox_Gjcy.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_Gjcy.FormattingEnabled = true;
            this.combox_Gjcy.Items.AddRange(new object[] {
            "HPB300",
            "HRB335,HRBF335",
            "HRB400,HRBF400,RRB400",
            "HRB500,HRBF500"});
            this.combox_Gjcy.Location = new System.Drawing.Point(92, 148);
            this.combox_Gjcy.Name = "combox_Gjcy";
            this.combox_Gjcy.Size = new System.Drawing.Size(158, 20);
            this.combox_Gjcy.TabIndex = 9;
            this.combox_Gjcy.Text = "HPB300";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "mm时，";
            // 
            // over_box
            // 
            this.over_box.Location = new System.Drawing.Point(117, 121);
            this.over_box.Name = "over_box";
            this.over_box.Size = new System.Drawing.Size(34, 21);
            this.over_box.TabIndex = 7;
            // 
            // check_gj
            // 
            this.check_gj.AutoSize = true;
            this.check_gj.Location = new System.Drawing.Point(23, 124);
            this.check_gj.Name = "check_gj";
            this.check_gj.Size = new System.Drawing.Size(96, 16);
            this.check_gj.TabIndex = 6;
            this.check_gj.Text = "箍筋直径超过";
            this.check_gj.UseVisualStyleBackColor = true;
            // 
            // combox_Lgj
            // 
            this.combox_Lgj.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_Lgj.FormattingEnabled = true;
            this.combox_Lgj.Items.AddRange(new object[] {
            "HPB300",
            "HRB335,HRBF335",
            "HRB400,HRBF400,RRB400",
            "HRB500,HRBF500"});
            this.combox_Lgj.Location = new System.Drawing.Point(92, 91);
            this.combox_Lgj.Name = "combox_Lgj";
            this.combox_Lgj.Size = new System.Drawing.Size(158, 20);
            this.combox_Lgj.TabIndex = 4;
            this.combox_Lgj.Text = "HPB300";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "梁箍筋：";
            // 
            // combox_Lzj
            // 
            this.combox_Lzj.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_Lzj.FormattingEnabled = true;
            this.combox_Lzj.Items.AddRange(new object[] {
            "HPB300",
            "HRB335,HRBF335",
            "HRB400,HRBF400,RRB400",
            "HRB500,HRBF500"});
            this.combox_Lzj.Location = new System.Drawing.Point(92, 61);
            this.combox_Lzj.Name = "combox_Lzj";
            this.combox_Lzj.Size = new System.Drawing.Size(158, 20);
            this.combox_Lzj.TabIndex = 2;
            this.combox_Lzj.Text = "HPB300";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "梁主筋：";
            // 
            // combox_Hnt
            // 
            this.combox_Hnt.AutoCompleteCustomSource.AddRange(new string[] {
            "显示",
            "窗口"});
            this.combox_Hnt.FormattingEnabled = true;
            this.combox_Hnt.Items.AddRange(new object[] {
            "C15",
            "C20",
            "C25",
            "C30",
            "C35",
            "C40",
            "C45",
            "C50",
            "C55",
            "C60",
            "C65",
            "C70",
            "C75",
            "C80"});
            this.combox_Hnt.Location = new System.Drawing.Point(92, 30);
            this.combox_Hnt.Name = "combox_Hnt";
            this.combox_Hnt.Size = new System.Drawing.Size(158, 20);
            this.combox_Hnt.TabIndex = 1;
            this.combox_Hnt.Text = "C15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "混凝土：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(322, 295);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(434, 295);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 23);
            this.btn_remove.TabIndex = 5;
            this.btn_remove.Text = "取消";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // check_hebin
            // 
            this.check_hebin.AutoSize = true;
            this.check_hebin.Location = new System.Drawing.Point(12, 295);
            this.check_hebin.Name = "check_hebin";
            this.check_hebin.Size = new System.Drawing.Size(96, 16);
            this.check_hebin.TabIndex = 7;
            this.check_hebin.Text = "合并原选择集";
            this.check_hebin.UseVisualStyleBackColor = true;
            // 
            // beam_smart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 335);
            this.Controls.Add(this.check_hebin);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "beam_smart";
            this.ShowIcon = false;
            this.Text = "梁批量识别";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.beam_smart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox select_range;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Line_Get;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Msg_Get;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox combox_peizhi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combox_kzdj;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox combox_Gjcy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox over_box;
        private System.Windows.Forms.CheckBox check_gj;
        private System.Windows.Forms.ComboBox combox_Lgj;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combox_Lzj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combox_Hnt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ComboBox wiff_Get;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox check_hebin;
    }
}