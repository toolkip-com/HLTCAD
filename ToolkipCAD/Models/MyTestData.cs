using stdole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolkipCAD.CustomForm;

namespace ToolkipCAD
{
    class MyTestData
    {
        //项目管理工具类
        private static HLTDataStruct _HLT = new HLTDataStruct();
        private TreeView _TreeView;
        public MyTestData(ref TreeView tree)
        {
            //构造函数加载树数据
            //先为数据模拟，再按需从文件读取
            List<Project_Manage> projects = new List<Project_Manage> {
                 new Project_Manage {
                id="11111",
                pid="",
                name="测试项目",
                type=Project_type.根节点,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                } ,
                new Project_Manage {
                id="11111-22222-33333",
                pid="11111",
                name="一号楼",
                type=Project_type.号楼,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                } ,
                 new Project_Manage {
                id="11111-22222-1",
                pid="11111-22222-33333",
                name="B1层",
                type=Project_type.楼层,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                },
                  new Project_Manage {
                id="11111-2211",
                pid="11111-22222-1",
                name="区域1",
                type=Project_type.区域,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                },
                  new Project_Manage {
                id="11111-221133",
                pid="11111-2211",
                name="梁",
                type=Project_type.构件,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                },
                new Project_Manage {
                id="11111-22113344",
                pid="11111-221133",
                name="2020081801",
                type=Project_type.记录,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                },
                new Project_Manage {
                id="11111-22113355",
                pid="11111-221133",
                name="20200818023",
                type=Project_type.记录,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                },
                 new Project_Manage {
                id="22222-22222-33333",
                pid="11111",
                name="二号楼",
                type=Project_type.号楼,
                xrecord_type=Xrecord_type.墙,
                xrecord_id=""
                } ,
            };
            _HLT.Project_Manage_Tree = projects;
            this._TreeView = tree;
        }
        //加载这棵树到界面
        public void StructTree()
        {
            Addnode(ref _TreeView);
        }
        //获取树数据
        public List<Project_Manage> GetProjectTree()
        {
            return _HLT.Project_Manage_Tree;
        }
        //创建子项菜单
        public ContextMenuStrip CreateItemMenu(TreeNode node)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            string id = node.Tag.ToString();
            Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
            switch (project.type)
            {
                case Project_type.根节点:
                    ToolStripMenuItem create_build = new ToolStripMenuItem("创建楼号");
                    create_build.Click += new EventHandler(CreateBuild_Click);
                    contextMenu.Items.Add(create_build);
                    break;
                case Project_type.号楼:
                    ToolStripMenuItem create_floor = new ToolStripMenuItem("创建楼层");
                    create_floor.Click += new EventHandler(CreateFloor_Click);
                    contextMenu.Items.Add(create_floor);
                    break;
                case Project_type.楼层:
                    ToolStripMenuItem create_range = new ToolStripMenuItem("创建范围");
                    create_range.Click += new EventHandler(CreateRange_Click);
                    contextMenu.Items.Add(create_range);
                    break;
                case Project_type.区域:
                    ToolStripMenuItem create_componet = new ToolStripMenuItem("创建构件");
                    create_componet.Click += new EventHandler(CreateComponet_Click);
                    contextMenu.Items.Add(create_componet);
                    break;
                case Project_type.构件:
                    ToolStripMenuItem create_recode = new ToolStripMenuItem("创建记录");
                    create_recode.Click += new EventHandler(CreateRecode_Click);
                    contextMenu.Items.Add(create_recode);
                    break;
                case Project_type.记录:
                    ToolStripMenuItem edit = new ToolStripMenuItem("编辑");
                    edit.Click += new EventHandler(Edit_Click);
                    contextMenu.Items.Add(edit);
                    ToolStripMenuItem copy = new ToolStripMenuItem("复制");
                    copy.Click += new EventHandler(Copy_Click);
                    contextMenu.Items.Add(copy);
                    break;
            }
            if (project.type != Project_type.根节点)
            {
                ToolStripMenuItem delete = new ToolStripMenuItem("删除");
                delete.Click += new EventHandler(Delete_Click);
                contextMenu.Items.Add(delete);
            }
            ToolStripMenuItem rename = new ToolStripMenuItem("重命名");
            rename.Click += new EventHandler(Rename_Click);
            contextMenu.Items.Add(rename);
            return contextMenu;
        }

        //新建子项
        public void AddTreeNode(string type)
        {
            ReNameDialog reName = new ReNameDialog();
            reName.Text = $"新建{type}";
            reName.transf += ((string result) =>
            {                
                Project_Manage project = new Project_Manage
                {
                    id = Guid.NewGuid().ToString(),
                    pid = _TreeView.SelectedNode.Tag.ToString(),
                    name = result,
                    type = (Project_type)Enum.Parse(typeof(Project_type), type)
                };
                _HLT.Project_Manage_Tree.Add(project);
                TreeNode node = new TreeNode();
                node.Tag = project.id;
                node.Text = project.name;
                _TreeView.SelectedNode.Nodes.Add(node);
            });
            reName.ShowDialog();
        }
        //重命名
        public void RenameForItem(string name)
        {
            if (_TreeView.SelectedNode != null)
            {
                _TreeView.SelectedNode.Text = name;
                string id = _TreeView.SelectedNode.Tag.ToString();
                Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
                project.name = name;
            }
        }
        //删除
        public void DeleteItem()
        {
            if (_TreeView.SelectedNode != null)
            {
                string id = _TreeView.SelectedNode.Tag.ToString();
                NodeRemove(id);
                Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
                _HLT.Project_Manage_Tree.Remove(project);
                _TreeView.SelectedNode.Remove();
            }
        }
        //复制  只有记录能复制
        public void CopyItem()
        {
            if (_TreeView.SelectedNode != null)
            {
                TreeNode node = (TreeNode)_TreeView.SelectedNode.Clone();
                Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == node.Tag.ToString());
                node.Text += "-副本";
                node.Tag = Guid.NewGuid().ToString();
                _TreeView.SelectedNode.Parent.Nodes.Add(node);
                _HLT.Project_Manage_Tree.Add(new Project_Manage()
                {
                    id = node.Tag.ToString(),
                    pid = project.pid,
                    name = node.Text,
                    type = project.type,
                    xrecord_type = project.xrecord_type,
                    xrecord_id = project.xrecord_id
                });
            }
        }
        //编辑  只有记录能编辑
        public void EditItem(string id)
        {

        }
        //右键菜单，不同类型对应不同菜单

        #region 节点递归加载/删除 2020/08/18
        public void Addnode(ref TreeView treeView1)
        {
            for (int i = 0; i < _HLT.Project_Manage_Tree.Count; i++)
            {
                if (_HLT.Project_Manage_Tree[i].pid == "")
                {
                    TreeNode pnode = new TreeNode();
                    pnode.Text = _HLT.Project_Manage_Tree[i].name;
                    pnode.Tag = _HLT.Project_Manage_Tree[i].id;
                    treeView1.Nodes.Add(pnode);
                    AddChildnode(_HLT.Project_Manage_Tree[i].id, pnode);
                }
            }
        }

        public void AddChildnode(string pid, TreeNode pnode)
        {
            for (int i = 0; i < _HLT.Project_Manage_Tree.Count; i++)
            {
                if (_HLT.Project_Manage_Tree[i].pid == pid)
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = _HLT.Project_Manage_Tree[i].name;
                    cnode.Tag = _HLT.Project_Manage_Tree[i].id;
                    pnode.Nodes.Add(cnode);
                    AddChildnode(_HLT.Project_Manage_Tree[i].id, cnode);
                }
            }
        }
        //删除
        public void NodeRemove(string id)
        {
            List<Project_Manage> projects = _HLT.Project_Manage_Tree.Where(x => x.pid == id).ToList();
            if (projects.Count > 0)
            {
                foreach (var item in projects)
                {
                    _HLT.Project_Manage_Tree.Remove(item);
                    NodeRemove(item.id);
                }
            }
        }
        #endregion

        #region 右键菜单事件 2020/08/18
        void CreateBuild_Click(object sender, EventArgs e)
        {
            //创建号楼
            AddTreeNode("号楼");
        }
        void CreateFloor_Click(object sender, EventArgs e)
        {
            //创建楼层
            AddTreeNode("楼层");
        }
        void CreateRange_Click(object sender, EventArgs e)
        {
            //创建范围
            AddTreeNode("区域");
        }
        void CreateComponet_Click(object sender, EventArgs e)
        {
            //创建构件
            AddTreeNode("构件");
        }
        void CreateRecode_Click(object sender, EventArgs e)
        {
            //创建记录
            AddTreeNode("记录");
        }
        void Edit_Click(object sender, EventArgs e) => RenameForItem("123");//编辑
        void Delete_Click(object sender, EventArgs e) => DeleteItem();//删除
        void Copy_Click(object sender, EventArgs e) => CopyItem();//复制
        void Rename_Click(object sender, EventArgs e) => RenameForItem("123");//重命名
        #endregion
    }
}
