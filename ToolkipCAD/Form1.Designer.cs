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
            this.PR_Panel = new System.Windows.Forms.Panel();
            this.tab_Proandresource = new System.Windows.Forms.TabControl();
            this.tab_project = new System.Windows.Forms.TabPage();
            this.tree_project = new System.Windows.Forms.TreeView();
            this.tab_resource = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.axMxDrawX1 = new AxMxDrawXLib.AxMxDrawX();
            this.重命名ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resource_contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.project_contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建楼号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建楼层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建构件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree_drawing = new System.Windows.Forms.TreeView();
            this.PR_Panel.SuspendLayout();
            this.tab_Proandresource.SuspendLayout();
            this.tab_project.SuspendLayout();
            this.tab_resource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).BeginInit();
            this.resource_contextMenuStrip1.SuspendLayout();
            this.project_contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.tab_Proandresource.Size = new System.Drawing.Size(231, 633);
            this.tab_Proandresource.TabIndex = 2;
            // 
            // tab_project
            // 
            this.tab_project.Controls.Add(this.tree_project);
            this.tab_project.Location = new System.Drawing.Point(4, 22);
            this.tab_project.Name = "tab_project";
            this.tab_project.Padding = new System.Windows.Forms.Padding(3);
            this.tab_project.Size = new System.Drawing.Size(223, 607);
            this.tab_project.TabIndex = 0;
            this.tab_project.Text = "项目管理";
            this.tab_project.UseVisualStyleBackColor = true;
            // 
            // tree_project
            // 
            this.tree_project.Location = new System.Drawing.Point(3, 6);
            this.tree_project.Name = "tree_project";
            this.tree_project.Size = new System.Drawing.Size(217, 598);
            this.tree_project.TabIndex = 0;
            this.tree_project.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_project_AfterSelect);
            this.tree_project.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_project_NodeMouseClick);
            // 
            // tab_resource
            // 
            this.tab_resource.Controls.Add(this.tree_drawing);
            this.tab_resource.Location = new System.Drawing.Point(4, 22);
            this.tab_resource.Name = "tab_resource";
            this.tab_resource.Padding = new System.Windows.Forms.Padding(3);
            this.tab_resource.Size = new System.Drawing.Size(223, 607);
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.axMxDrawX1.MxKeyUp += new AxMxDrawXLib._DMxDrawXEvents_MxKeyUpEventHandler(this.axMxDrawX1_MxKeyUp_1);
            this.axMxDrawX1.InitComplete += new System.EventHandler(this.axMxDrawX1_InitComplete);
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
            // resource_contextMenuStrip1
            // 
            this.resource_contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重命名ToolStripMenuItem1,
            this.删除ToolStripMenuItem1});
            this.resource_contextMenuStrip1.Name = "resource_contextMenuStrip1";
            this.resource_contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // project_contextMenuStrip1
            // 
            this.project_contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建楼号ToolStripMenuItem,
            this.创建楼层ToolStripMenuItem,
            this.创建范围ToolStripMenuItem,
            this.创建构件ToolStripMenuItem,
            this.创建记录ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.project_contextMenuStrip1.Name = "project_contextMenuStrip1";
            this.project_contextMenuStrip1.Size = new System.Drawing.Size(125, 202);
            // 
            // 创建楼号ToolStripMenuItem
            // 
            this.创建楼号ToolStripMenuItem.Name = "创建楼号ToolStripMenuItem";
            this.创建楼号ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建楼号ToolStripMenuItem.Text = "创建楼号";
            // 
            // 创建楼层ToolStripMenuItem
            // 
            this.创建楼层ToolStripMenuItem.Name = "创建楼层ToolStripMenuItem";
            this.创建楼层ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建楼层ToolStripMenuItem.Text = "创建楼层";
            // 
            // 创建范围ToolStripMenuItem
            // 
            this.创建范围ToolStripMenuItem.Name = "创建范围ToolStripMenuItem";
            this.创建范围ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建范围ToolStripMenuItem.Text = "创建范围";
            // 
            // 创建构件ToolStripMenuItem
            // 
            this.创建构件ToolStripMenuItem.Name = "创建构件ToolStripMenuItem";
            this.创建构件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建构件ToolStripMenuItem.Text = "创建构件";
            // 
            // 创建记录ToolStripMenuItem
            // 
            this.创建记录ToolStripMenuItem.Name = "创建记录ToolStripMenuItem";
            this.创建记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建记录ToolStripMenuItem.Text = "创建记录";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // tree_drawing
            // 
            this.tree_drawing.Location = new System.Drawing.Point(3, 4);
            this.tree_drawing.Name = "tree_drawing";
            this.tree_drawing.Size = new System.Drawing.Size(217, 598);
            this.tree_drawing.TabIndex = 1;
            this.tree_drawing.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_drawing_NodeMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1387, 657);
            this.Controls.Add(this.PR_Panel);
            this.Controls.Add(this.axMxDrawX1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "好蓝图平面CAD";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PR_Panel.ResumeLayout(false);
            this.PR_Panel.PerformLayout();
            this.tab_Proandresource.ResumeLayout(false);
            this.tab_project.ResumeLayout(false);
            this.tab_resource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).EndInit();
            this.resource_contextMenuStrip1.ResumeLayout(false);
            this.project_contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AxMxDrawXLib.AxMxDrawX axMxDrawX1;
        private System.Windows.Forms.Panel PR_Panel;
        private System.Windows.Forms.TabControl tab_Proandresource;
        private System.Windows.Forms.TabPage tab_project;
        private System.Windows.Forms.TabPage tab_resource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tree_project;
        private System.Windows.Forms.ContextMenuStrip project_contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 创建楼号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建楼层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建范围ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建构件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip resource_contextMenuStrip1;
        private System.Windows.Forms.TreeView tree_drawing;
    }
}

