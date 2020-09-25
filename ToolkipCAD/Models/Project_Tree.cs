using stdole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ToolkipCAD.CustomForm;

namespace ToolkipCAD
{
    class Project_Tree
    {
        //项目管理工具类
        public HLTDataStruct _HLT = new HLTDataStruct();
        private TreeView _TreeView;
        private TreeView _DrawView;
        public Project_Tree(ref TreeView tree, ref TreeView draw)
        {
            #region
            //List<Project_Manage> projects = new List<Project_Manage> {
            //     new Project_Manage {
            //    id="11111",
            //    pid="",
            //    name="测试项目",
            //    type=Project_type.根节点,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    } ,
            //    new Project_Manage {
            //    id="11111-22222-33333",
            //    pid="11111",
            //    name="一号楼",
            //    type=Project_type.号楼,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    } ,
            //     new Project_Manage {
            //    id="11111-22222-1",
            //    pid="11111-22222-33333",
            //    name="B1层",
            //    type=Project_type.楼层,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    },
            //      new Project_Manage {
            //    id="11111-2211",
            //    pid="11111-22222-1",
            //    name="区域1",
            //    type=Project_type.区域,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    },
            //      new Project_Manage {
            //    id="11111-221133",
            //    pid="11111-2211",
            //    name="梁",
            //    type=Project_type.构件,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    },
            //    new Project_Manage {
            //    id="11111-22113344",
            //    pid="11111-221133",
            //    name="2020081801",
            //    type=Project_type.记录,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    },
            //    new Project_Manage {
            //    id="11111-22113355",
            //    pid="11111-221133",
            //    name="20200818023",
            //    type=Project_type.记录,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    },
            //     new Project_Manage {
            //    id="22222-22222-33333",
            //    pid="11111",
            //    name="二号楼",
            //    type=Project_type.号楼,
            //    xrecord_type=Xrecord_type.墙,
            //    xrecord_id=""
            //    } ,
            //};
            //List<Drawing_Manage> drawings = new List<Drawing_Manage>
            //{
            //    new Drawing_Manage
            //    {
            //        id="111111",
            //        pid="",
            //        name="根节点",
            //        type=Drawing_type.根节点,
            //        ext=""
            //    },
            //    new Drawing_Manage
            //    {
            //        id="22222",
            //        pid="111111",
            //        name="类型1",
            //        type=Drawing_type.资源类型,
            //        ext=""
            //    },
            //    new Drawing_Manage
            //    {
            //        id="33333",
            //        pid="22222",
            //        name="文件1",
            //        type=Drawing_type.文件,
            //        ext="dwg"
            //    },
            //    new Drawing_Manage
            //    {
            //        id="33333-2",
            //        pid="22222",
            //        name="文件2",
            //        type=Drawing_type.文件,
            //        ext="dwg"
            //    }

            //};
            //_HLT.Project_Manage_Tree = projects;
            //_HLT.Drawing_Manage_Tree = drawings;
            #endregion
            this._TreeView = tree;
            this._DrawView = draw;
        }
        //打开项目数据
        public void LoadHLTTree(string HltPath)
        {
            XmlSerializer xs = new XmlSerializer(_HLT.GetType());
            TextReader tw = new StreamReader(HltPath);
            _HLT = (HLTDataStruct)xs.Deserialize(tw);
            tw.Close();
            this._TreeView.Nodes.Clear();
            this._DrawView.Nodes.Clear();
            StructTree();
            Program.MainForm.Text = $"好蓝图平面CAD-[{_HLT.Project_name}.hlt]";
            Program.MainForm.Tag = new
            {
                name = _HLT.Project_name,
                path = HltPath.Substring(0,HltPath.LastIndexOf('\\'))// _HLT.Project_path
            };
        }
        //存储新建项目信息
        public void SaveProjectInfo(dynamic info)
        {
            _HLT.Project_name = info.name;
            //_HLT.Project_path = info.path;
            List<Project_Manage> project = new List<Project_Manage>{ new Project_Manage
            {
                id = Guid.NewGuid().ToString(),
                pid="",
                name=info.name,
                type=Project_type.根节点,
            } };
            List<Drawing_Manage> drawing = new List<Drawing_Manage>{ new Drawing_Manage
            {
                id=Guid.NewGuid().ToString(),
                pid="",
                name=info.name,
                type=Drawing_type.根节点
            }};
            drawing.Add(new Drawing_Manage
            {
                id = Guid.NewGuid().ToString(),
                pid = drawing[0].id,
                name = "图纸",
                type = Drawing_type.资源类型
            });
            drawing.Add(new Drawing_Manage
            {
                id = Guid.NewGuid().ToString(),
                pid = drawing[0].id,
                name = "构造方案",
                type = Drawing_type.构造配置
            });
            _HLT.Project_Manage_Tree = project;
            _HLT.Drawing_Manage_Tree = drawing;
            this._TreeView.Nodes.Clear();
            this._DrawView.Nodes.Clear();
            XmlSerializer xs = new XmlSerializer(_HLT.GetType());
            TextWriter tw = new StreamWriter($@"{info.path}\{info.name}.hlt");
            xs.Serialize(tw, _HLT);
            tw.Close();
            StructTree();
        }
        //加载这棵树
        public void StructTree()
        {
            Addnode(ref _TreeView);
            AddDrawnode(ref _DrawView);
            _TreeView.ExpandAll();
            _DrawView.ExpandAll();
        }
        //获取树数据
        public HLTDataStruct GetTreeData()
        {
            return _HLT;
        }
        //获取选择的树节点(Project)
        public Project_Manage GetSelectProjectTree()
        {
            TreeNode node= _TreeView.SelectedNode;
            if (node != null)
            {
                Project_Manage project= _HLT.Project_Manage_Tree.Find(x=>x.id==node.Tag.ToString());
                return project;
            }
            else
            {
                return new Project_Manage();
            }
        }
        //获取梁识别数据
        public object GetBeamData(string id)
        {
            return _HLT.XRecords.Find(x => x.id == id).json;
        }
        //保存梁识别数据
        public void SaveBeamData(string id,Beam_XRrecord beam)
        {
            Project_Manage project = _HLT.Project_Manage_Tree.Find(x=>x.id==id);
            XRecord record = _HLT.XRecords.Find(x=>x.id==project.xrecord_id);
            record.json = beam;
        }
        //创建子项菜单(项目)
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
        //创建子项菜单(图纸)
        public ContextMenuStrip CreateDrawMenu()
        {
            
            string id = _DrawView.SelectedNode.Tag.ToString();
            Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x=>x.id==id);
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            if (drawing.type == Drawing_type.资源类型)
            {
                ToolStripMenuItem AddDrawing = new ToolStripMenuItem("添加");
                AddDrawing.Click += new EventHandler(Draw_AddDrawing_Click);
                contextMenu.Items.Add(AddDrawing);
            }
            if (drawing.type == Drawing_type.文件)
            {
                ToolStripMenuItem Rename = new ToolStripMenuItem("重命名");
                Rename.Click += new EventHandler(Draw_Rename_Click);
                ToolStripMenuItem Delete = new ToolStripMenuItem("删除");
                Delete.Click += new EventHandler(Draw_Delete_Click);
                contextMenu.Items.Add(Rename);
                contextMenu.Items.Add(Delete);
            }
            if (drawing.type == Drawing_type.构造配置)
            {
                ToolStripMenuItem CreateNew = new ToolStripMenuItem("新建");
                CreateNew.Click += new EventHandler(Draw_CreateNew_Click);
                contextMenu.Items.Add(CreateNew);
            }
            if (drawing.type == Drawing_type.配置)
            {
                ToolStripMenuItem EditItem = new ToolStripMenuItem("编辑");
                EditItem.Click += new EventHandler(Draw_Edit_Click);
                ToolStripMenuItem ReNameItem = new ToolStripMenuItem("重命名");
                ReNameItem.Click += new EventHandler(Draw_Rename_Click);
                ToolStripMenuItem RemoveItem = new ToolStripMenuItem("删除");
                RemoveItem.Click += new EventHandler(Draw_Delete_Click);
                contextMenu.Items.Add(EditItem);
                contextMenu.Items.Add(ReNameItem);
                contextMenu.Items.Add(RemoveItem);
            }
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
                _TreeView.SelectedNode.Expand();
            });
            reName.ShowDialog();
        }

        //重命名
        public void RenameForItem()
        {
            if (_TreeView.SelectedNode != null)
            {
                ReNameDialog reName = new ReNameDialog();
                reName.Text = "重命名";
                reName.Tag = _TreeView.SelectedNode.Text;
                reName.transf += ((string result) =>
                {
                    string id = _TreeView.SelectedNode.Tag.ToString();
                    Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
                    project.name = result;
                    _TreeView.SelectedNode.Text = result;
                });
                reName.ShowDialog();
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
        //创建记录
        public void CreateRecode()
        {
            //创建记录
            RecodeDialog recode = new RecodeDialog();
            recode.Tag = new
            {
                name = "",
                oner =new List<Drawing_Manage>(_HLT.Drawing_Manage_Tree.ToArray()),
                path = "",
            };
            recode.transf += (dynamic result) =>
            {
                Project_Manage project = new Project_Manage
                {
                    id = Guid.NewGuid().ToString(),
                    pid = _TreeView.SelectedNode.Tag.ToString(),
                    name = result.name,
                    type = Project_type.记录,
                    xrecord_type=Xrecord_type.梁
                };
                XRecord record=new XRecord();
                if (result.file != ""&&result.combo=="")//导入的
                {
                    FileInfo file = new FileInfo(result.file);
                    string name = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                    string ext = file.Name.Substring(file.Name.LastIndexOf('.')+1,file.Name.Length- file.Name.LastIndexOf('.')-1);
                    Drawing_Manage drawing = new Drawing_Manage
                    {
                        id = Guid.NewGuid().ToString(),
                        pid = _DrawView.Nodes[0].FirstNode.Tag.ToString(),
                        name =name,
                        type = Drawing_type.文件,
                        ext = ext                   
                    };
                    record = new XRecord
                    {
                        id = Guid.NewGuid().ToString(),
                        Drawing_Manage_id=drawing.id,
                        type=Xrecord_type.梁
                    };
                    _DrawView.Nodes[0].FirstNode.Nodes.Add(new TreeNode { Text=name,Tag=drawing.id});                    
                    _HLT.Drawing_Manage_Tree.Add(drawing);
                }
                if (result.file == "" && result.combo != "")//基于图纸的
                {
                    record = new XRecord
                    {
                        id = Guid.NewGuid().ToString(),
                        Drawing_Manage_id = result.combo,
                        type = Xrecord_type.梁
                    };
                }
                if (_HLT.XRecords == null) _HLT.XRecords = new List<XRecord> { record };
                else _HLT.XRecords.Add(record);
                project.xrecord_id = record.id;
                _HLT.Project_Manage_Tree.Add(project);
                TreeNode node = new TreeNode();
                node.Tag = project.id;
                node.Text = project.name;
                _TreeView.SelectedNode.Nodes.Add(node);
                //Program.MainForm.axMxDrawX1.OpenDwgFile();
                _TreeView.SelectedNode = node;
                Program.MainForm.axMxDrawX1.OpenDwgFile(RecodeClick());
            };
            recode.ShowDialog();
        }
        //编辑  只有记录能编辑
        public void EditRecode()
        {
            //编辑记录
            RecodeDialog recode = new RecodeDialog();
            recode.Text = "编辑记录";
            string id = _TreeView.SelectedNode.Tag.ToString();
            Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
            recode.Tag = new
            {
                name = project.name,
                oner = new List<Drawing_Manage>(_HLT.Drawing_Manage_Tree.ToArray()),
                path = "",
            };
            recode.transf += (dynamic result) =>
            {
                project.name = result.name;
                XRecord record = _HLT.XRecords.Find(x=>x.id==project.xrecord_id);
                if (result.file != "")
                {
                    FileInfo file = new FileInfo(result.file);
                    string name = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                    string ext = file.Name.Substring(file.Name.LastIndexOf('.') + 1, file.Name.Length - file.Name.LastIndexOf('.') - 1);
                    //Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x=>x.id==record.Drawing_Manage_id);
                    Drawing_Manage drawing = new Drawing_Manage
                    {
                        id=Guid.NewGuid().ToString(),
                        pid= _DrawView.Nodes[0].FirstNode.Tag.ToString(),
                        type=Drawing_type.文件,
                        name=name,
                        ext=ext
                    };
                    record.Drawing_Manage_id = drawing.id;
                    _HLT.Drawing_Manage_Tree.Add(drawing);
                    _DrawView.Nodes[0].FirstNode.Nodes.Add(new TreeNode { Text = name, Tag = drawing.id });
                }
                if (result.combo != "")
                {
                    record.Drawing_Manage_id = result.combo;
                }
                _TreeView.SelectedNode.Text = result.name;
            };
            recode.ShowDialog();
        }
        //删除图纸
        public void DrawDelete()
        {
            if (_DrawView.SelectedNode != null)
            {
                string id = _DrawView.SelectedNode.Tag.ToString();
                Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x => x.id == id);
                dynamic pro = Program.MainForm.Tag;
                if (File.Exists($@"{pro.path}\src\{drawing.name}.dwg"))
                    File.Delete($@"{pro.path}\src\{drawing.name}.dwg");
                _HLT.Drawing_Manage_Tree.Remove(drawing);
                _DrawView.SelectedNode.Remove();
            }
        }
        //添加图纸
        public void DrawAddDrawing()
        {
            string id=_DrawView.SelectedNode.Tag.ToString();
            //MessageBox.Show($"id:{id},功能开发中");
            AddDrawingDialog add = new AddDrawingDialog();
            add.transf += (dynamic result) =>
            {
                string Nid = Guid.NewGuid().ToString();
                _HLT.Drawing_Manage_Tree.Add(new Drawing_Manage { 
                id=Nid,
                pid=id,
                type=Drawing_type.文件,
                ext="dwg",
                name=result
                });
                _DrawView.SelectedNode.Nodes.Add(new TreeNode { Text=result,Tag=Nid});
            };
            add.ShowDialog();
        }
        //重命名图纸
        public void DrawRename()
        {
            if (_DrawView.SelectedNode != null)
            {
                ReNameDialog reName = new ReNameDialog
                {
                    Text = "重命名"
                };
                reName.Tag = _DrawView.SelectedNode.Text;
                reName.transf += ((string result) =>
                {
                    string id = _DrawView.SelectedNode.Tag.ToString();
                    Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x => x.id == id);
                    if (drawing.name == result) return;
                    dynamic pro = Program.MainForm.Tag;
                    if (File.Exists($@"{pro.path}\src\{drawing.name}.dwg"))
                        File.Move($@"{pro.path}\src\{drawing.name}.dwg", $@"{pro.path}\src\{result}.dwg");
                    drawing.name = result;
                    _DrawView.SelectedNode.Text = result;
                });
                reName.ShowDialog();
            }
        }
        //新建构造
        public void DrawCreateStruct()
        {
            GouzaoRecord record = new GouzaoRecord();
            string id = _DrawView.SelectedNode.Tag.ToString();
            record.Tag = new
            {
                type = "",
            };
            record.transf += (dynamic result) =>
            {
                _HLT.Drawing_Manage_Tree.Add(new Drawing_Manage
                {
                    id = result.id,
                    pid = _HLT.Drawing_Manage_Tree.Find(x=>x.type==Drawing_type.构造配置).id,
                    name=result.name,
                    type=Drawing_type.配置,                    
                }) ;
                _DrawView.SelectedNode.Nodes.Add(new TreeNode { Tag=result.id,Text=result.name});
            };
            record.ShowDialog();
        }
        //修改构造
        public void DrawEditStruct()
        {
            GouzaoRecord record = new GouzaoRecord();
            string id = _DrawView.SelectedNode.Tag.ToString();
            record.Tag = new
            {
                type = "Edit",
                name = _DrawView.SelectedNode.Text,
                id = _HLT.Drawing_Manage_Tree.Find(x => x.id == id).id
            };
            record.transf += (dynamic result) =>
              {
                  _DrawView.SelectedNode.Text = result.name;
                  Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x=>x.id==id);
                  drawing.name = result.name;
              };
            record.ShowDialog();
        }
        //记录的点击事件
        public string RecodeClick()
        {            
            if (_TreeView.SelectedNode != null)
            {
                Program.MainForm.axMxDrawX1.SaveDwgFile(Program.MainForm.axMxDrawX1.DwgFilePath);
                if (Program.MainForm.Tag != null)
                {
                    string id = _TreeView.SelectedNode.Tag.ToString();
                    Project_Manage project = _HLT.Project_Manage_Tree.Find(x => x.id == id);
                    if (project.type != Project_type.记录) return "";
                    XRecord record = _HLT.XRecords.Find(x=>x.id==project.xrecord_id);
                    Drawing_Manage drawing = _HLT.Drawing_Manage_Tree.Find(x=>x.id==record.Drawing_Manage_id);
                    if (drawing == null) return "";
                    dynamic Propath = Program.MainForm.Tag;
                    string file = $@"{Propath.path}\src\{drawing.name}.dwg";
                    if (!File.Exists(file)) return "";
                    return file;
                }
            }
            return "";
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

        // 图纸资源管理
        public void AddDrawnode(ref TreeView treeView1)
        {
            for (int i = 0; i < _HLT.Drawing_Manage_Tree.Count; i++)
            {
                if (_HLT.Drawing_Manage_Tree[i].pid == "")
                {
                    TreeNode pnode = new TreeNode();
                    pnode.Text = _HLT.Drawing_Manage_Tree[i].name;
                    pnode.Tag = _HLT.Drawing_Manage_Tree[i].id;
                    treeView1.Nodes.Add(pnode);
                    AddDrawChildnode(_HLT.Drawing_Manage_Tree[i].id, pnode);
                }
            }
        }

        public void AddDrawChildnode(string pid, TreeNode pnode)
        {
            for (int i = 0; i < _HLT.Drawing_Manage_Tree.Count; i++)
            {
                if (_HLT.Drawing_Manage_Tree[i].pid == pid)
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = _HLT.Drawing_Manage_Tree[i].name;
                    cnode.Tag = _HLT.Drawing_Manage_Tree[i].id;
                    pnode.Nodes.Add(cnode);
                    AddDrawChildnode(_HLT.Drawing_Manage_Tree[i].id, cnode);
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
        void CreateBuild_Click(object sender, EventArgs e) => AddTreeNode("号楼"); //创建号楼
        void CreateFloor_Click(object sender, EventArgs e) => AddTreeNode("楼层");//创建楼层
        void CreateRange_Click(object sender, EventArgs e) => AddTreeNode("区域"); //创建范围
        void CreateComponet_Click(object sender, EventArgs e) => AddTreeNode("构件"); //创建构件
        void CreateRecode_Click(object sender, EventArgs e) => CreateRecode();//创建记录
        void Edit_Click(object sender, EventArgs e) => EditRecode();//编辑记录
        void Delete_Click(object sender, EventArgs e) => DeleteItem();//删除
        void Copy_Click(object sender, EventArgs e) => CopyItem();//复制
        void Rename_Click(object sender, EventArgs e) => RenameForItem();//重命名
        void Draw_AddDrawing_Click(object sender, EventArgs e) => DrawAddDrawing();//图纸添加
        void Draw_Rename_Click(object sender, EventArgs e) => DrawRename();//图纸重命名
        void Draw_Delete_Click(object sender, EventArgs e) => DrawDelete();//图纸删除
        void Draw_CreateNew_Click(object sender, EventArgs e) => DrawCreateStruct();//新建构造
        void Draw_Edit_Click(object sender, EventArgs e) => DrawEditStruct();//编辑构造
        #endregion
    }
}
