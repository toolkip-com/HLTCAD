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
            axMx.RegistUserCustomCommand("TK_SaveObj", 1004);//保存操作
        }
    }
}
