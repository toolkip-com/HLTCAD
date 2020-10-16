using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxDrawXLib;
using AxMxDrawXLib;

namespace ToolkipCAD.Toolbar
{
    public class CommandList
    {
        /// <summary>
        /// 命令注册
        /// </summary>
        /// <param name="axMx">控件</param>
        public CommandList(ref AxMxDrawX axMx)
        {
            axMx.RegistUserCustomCommand("select_layer", 1001);//选择图层
            axMx.RegistUserCustomCommand("TK_NewObj", 1002);//新建项目
            axMx.RegistUserCustomCommand("TK_OpenObj", 1003);//打开项目
            axMx.RegistUserCustomCommand("TK_SaveAsObj", 10041);//另存为
            axMx.RegistUserCustomCommand("TK_SaveObj", 1004);//保存操作
            axMx.RegistUserCustomCommand("TK_OutObj", 1005);//退出操作
            axMx.RegistUserCustomCommand("TK_PLSB", 1006);//梁批量识别
            axMx.RegistUserCustomCommand("TK_PLSB_select", 1007);//梁批量识别-选择
            axMx.RegistUserCustomCommand("TK_DDBJ",1008);//单段编辑
            axMx.RegistUserCustomCommand("TK_DLSB", 1009);//单梁识别
            axMx.RegistUserCustomCommand("TK_DDSB", 1010);//单段识别
            axMx.RegistUserCustomCommand("TK_KZDJ", 1011);//抗震等级
            axMx.RegistUserCustomCommand("TK_HNTDJ", 1012);//混凝土等级
            axMx.RegistUserCustomCommand("TK_SWCK", 1013);//三维窗口
            axMx.RegistUserCustomCommand("TK_PSHOW", 1014);//平显


            axMx.RegistUserCustomCommand("Delete_Layer", 12);//删除图层
            axMx.RegistUserCustomCommand("MyTest",11);//测试命令
        }
    }
}
