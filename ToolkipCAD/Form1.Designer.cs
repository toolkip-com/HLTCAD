namespace ToolkipCAD
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMxDrawX1 = new AxMxDrawXLib.AxMxDrawX();
            this.PR_Panel = new System.Windows.Forms.Panel();
            this.tab_Proandresource = new System.Windows.Forms.TabControl();
            this.tab_project = new System.Windows.Forms.TabPage();
            this.tab_resource = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.project_contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建子项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resource_contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重命名ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤消UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重复RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.梁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单梁识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单段识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单段编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.功能2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.三维窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).BeginInit();
            this.PR_Panel.SuspendLayout();
            this.tab_Proandresource.SuspendLayout();
            this.project_contextMenuStrip1.SuspendLayout();
            this.resource_contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMxDrawX1
            // 
            this.axMxDrawX1.Enabled = true;
            this.axMxDrawX1.Location = new System.Drawing.Point(0, 0);
            this.axMxDrawX1.Name = "axMxDrawX1";
            this.axMxDrawX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMxDrawX1.OcxState")));
            this.axMxDrawX1.Size = new System.Drawing.Size(1152, 658);
            this.axMxDrawX1.TabIndex = 4;
            this.axMxDrawX1.ImplementCommandEvent += new AxMxDrawXLib._DMxDrawXEvents_ImplementCommandEventEventHandler(this.axMxDrawX1_ImplementCommandEvent);
            this.axMxDrawX1.InitComplete += new System.EventHandler(this.axMxDrawX1_InitComplete);
            // 
            // PR_Panel
            // 
            this.PR_Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PR_Panel.Controls.Add(this.tab_Proandresource);
            this.PR_Panel.Controls.Add(this.label1);
            this.PR_Panel.Location = new System.Drawing.Point(1149, 0);
            this.PR_Panel.Name = "PR_Panel";
            this.PR_Panel.Size = new System.Drawing.Size(238, 658);
            this.PR_Panel.TabIndex = 5;
            // 
            // tab_Proandresource
            // 
            this.tab_Proandresource.Controls.Add(this.tab_project);
            this.tab_Proandresource.Controls.Add(this.tab_resource);
            this.tab_Proandresource.Location = new System.Drawing.Point(3, 25);
            this.tab_Proandresource.Name = "tab_Proandresource";
            this.tab_Proandresource.SelectedIndex = 0;
            this.tab_Proandresource.Size = new System.Drawing.Size(231, 604);
            this.tab_Proandresource.TabIndex = 2;
            // 
            // tab_project
            // 
            this.tab_project.ContextMenuStrip = this.project_contextMenuStrip1;
            this.tab_project.Location = new System.Drawing.Point(4, 22);
            this.tab_project.Name = "tab_project";
            this.tab_project.Padding = new System.Windows.Forms.Padding(3);
            this.tab_project.Size = new System.Drawing.Size(223, 578);
            this.tab_project.TabIndex = 0;
            this.tab_project.Text = "项目管理";
            this.tab_project.UseVisualStyleBackColor = true;
            // 
            // tab_resource
            // 
            this.tab_resource.ContextMenuStrip = this.resource_contextMenuStrip1;
            this.tab_resource.Location = new System.Drawing.Point(4, 22);
            this.tab_resource.Name = "tab_resource";
            this.tab_resource.Padding = new System.Windows.Forms.Padding(3);
            this.tab_resource.Size = new System.Drawing.Size(223, 578);
            this.tab_resource.TabIndex = 1;
            this.tab_resource.Text = "资源管理";
            this.tab_resource.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(59, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目及资源管理";
            // 
            // project_contextMenuStrip1
            // 
            this.project_contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建子项ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.project_contextMenuStrip1.Name = "project_contextMenuStrip1";
            this.project_contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 新建子项ToolStripMenuItem
            // 
            this.新建子项ToolStripMenuItem.Name = "新建子项ToolStripMenuItem";
            this.新建子项ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建子项ToolStripMenuItem.Text = "新建子项";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // resource_contextMenuStrip1
            // 
            this.resource_contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重命名ToolStripMenuItem1,
            this.删除ToolStripMenuItem1});
            this.resource_contextMenuStrip1.Name = "resource_contextMenuStrip1";
            this.resource_contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // 重命名ToolStripMenuItem1
            // 
            this.重命名ToolStripMenuItem1.Name = "重命名ToolStripMenuItem1";
            this.重命名ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem1.Text = "重命名";
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.保存SToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem.Image")));
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤消UToolStripMenuItem,
            this.重复RToolStripMenuItem,
            this.toolStripSeparator3,
            this.剪切TToolStripMenuItem,
            this.复制CToolStripMenuItem,
            this.粘贴PToolStripMenuItem,
            this.toolStripSeparator4});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 撤消UToolStripMenuItem
            // 
            this.撤消UToolStripMenuItem.Name = "撤消UToolStripMenuItem";
            this.撤消UToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.撤消UToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.撤消UToolStripMenuItem.Text = "撤消(&U)";
            // 
            // 重复RToolStripMenuItem
            // 
            this.重复RToolStripMenuItem.Name = "重复RToolStripMenuItem";
            this.重复RToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重复RToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.重复RToolStripMenuItem.Text = "重复(&R)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // 剪切TToolStripMenuItem
            // 
            this.剪切TToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("剪切TToolStripMenuItem.Image")));
            this.剪切TToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切TToolStripMenuItem.Name = "剪切TToolStripMenuItem";
            this.剪切TToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切TToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.剪切TToolStripMenuItem.Text = "剪切(&T)";
            // 
            // 复制CToolStripMenuItem
            // 
            this.复制CToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制CToolStripMenuItem.Image")));
            this.复制CToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripMenuItem.Name = "复制CToolStripMenuItem";
            this.复制CToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制CToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.复制CToolStripMenuItem.Text = "复制(&C)";
            // 
            // 粘贴PToolStripMenuItem
            // 
            this.粘贴PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("粘贴PToolStripMenuItem.Image")));
            this.粘贴PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripMenuItem.Name = "粘贴PToolStripMenuItem";
            this.粘贴PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴PToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.粘贴PToolStripMenuItem.Text = "粘贴(&P)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(158, 6);
            // 
            // 梁ToolStripMenuItem
            // 
            this.梁ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.批量识别ToolStripMenuItem,
            this.单梁识别ToolStripMenuItem,
            this.单段识别ToolStripMenuItem,
            this.单段编辑ToolStripMenuItem});
            this.梁ToolStripMenuItem.Name = "梁ToolStripMenuItem";
            this.梁ToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.梁ToolStripMenuItem.Text = "梁(&L)";
            // 
            // 批量识别ToolStripMenuItem
            // 
            this.批量识别ToolStripMenuItem.Name = "批量识别ToolStripMenuItem";
            this.批量识别ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.批量识别ToolStripMenuItem.Text = "批量识别(&F)";
            // 
            // 单梁识别ToolStripMenuItem
            // 
            this.单梁识别ToolStripMenuItem.Name = "单梁识别ToolStripMenuItem";
            this.单梁识别ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.单梁识别ToolStripMenuItem.Text = "单梁识别(&G)";
            // 
            // 单段识别ToolStripMenuItem
            // 
            this.单段识别ToolStripMenuItem.Name = "单段识别ToolStripMenuItem";
            this.单段识别ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.单段识别ToolStripMenuItem.Text = "单段识别(&T)";
            // 
            // 单段编辑ToolStripMenuItem
            // 
            this.单段编辑ToolStripMenuItem.Name = "单段编辑ToolStripMenuItem";
            this.单段编辑ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.单段编辑ToolStripMenuItem.Text = "单段编辑(&E)";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能1ToolStripMenuItem1,
            this.功能2ToolStripMenuItem1,
            this.三维窗口ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.显示ToolStripMenuItem.Text = "显示(&V)";
            // 
            // 功能1ToolStripMenuItem1
            // 
            this.功能1ToolStripMenuItem1.Name = "功能1ToolStripMenuItem1";
            this.功能1ToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.功能1ToolStripMenuItem1.Text = "抗震等级(&D)";
            // 
            // 功能2ToolStripMenuItem1
            // 
            this.功能2ToolStripMenuItem1.Name = "功能2ToolStripMenuItem1";
            this.功能2ToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.功能2ToolStripMenuItem1.Text = "混凝土等级(&H)";
            // 
            // 三维窗口ToolStripMenuItem
            // 
            this.三维窗口ToolStripMenuItem.Name = "三维窗口ToolStripMenuItem";
            this.三维窗口ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.三维窗口ToolStripMenuItem.Text = "三维窗口(&P)";
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.绘制ToolStripMenuItem.Text = "绘制(&X)";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem1});
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem1.Text = "帮助(&H)";
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.关于ToolStripMenuItem1.Text = "关于(&A)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.梁ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.绘制ToolStripMenuItem,
            this.帮助ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1387, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1387, 657);
            this.Controls.Add(this.PR_Panel);
            this.Controls.Add(this.axMxDrawX1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).EndInit();
            this.PR_Panel.ResumeLayout(false);
            this.PR_Panel.PerformLayout();
            this.tab_Proandresource.ResumeLayout(false);
            this.project_contextMenuStrip1.ResumeLayout(false);
            this.resource_contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AxMxDrawXLib.AxMxDrawX axMxDrawX1;
        private System.Windows.Forms.Panel PR_Panel;
        private System.Windows.Forms.TabControl tab_Proandresource;
        private System.Windows.Forms.TabPage tab_project;
        private System.Windows.Forms.TabPage tab_resource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip project_contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建子项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip resource_contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤消UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重复RToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 剪切TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 梁ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批量识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单梁识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单段识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单段编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 功能2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 三维窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

