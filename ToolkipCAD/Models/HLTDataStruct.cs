using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxDrawXLib;

namespace ToolkipCAD
{
    public class HLTDataStruct  //项目文件数据结构
    {
        public string Project_name { get; set; }//项目名称
        public string Project_path { get; set; }//项目目录
        public List<Project_Manage> Project_Manage_Tree { get; set; }  //项目管理树结构
        public List<Drawing_Manage> Drawing_Manage_Tree { get; set; }  //图纸管理树结构
        public List<XRecord> XRecords { get; set; }//记录
    }
    public class Project_Manage   //项目管理结构
    {
        /// <summary>
        /// id号，6位GUID
        /// </summary>
        public string id { get; set; }   //id号，16位GUID
        /// <summary>
        /// 父亲的id号
        /// </summary>
        public string pid { get; set; }   //父id号
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }   //节点名称
        /// <summary>
        /// 节点类型  0--根节点   1--号楼    2--楼层   3---区域   4--构件   5--记录
        /// </summary>
        public Project_type type { get; set; }   //节点类型  0--根节点   1--号楼    2--楼层   3---区域   4--构件   5--记录
        /// <summary>
        /// 当type=4时，此项  1--梁   2--板  3--柱  4--墙  5--其它
        /// </summary>
        public Xrecord_type xrecord_type { get; set; }   //当type=4时，此项  1--梁   2--板  3--柱  4--墙  5--其它
        /// <summary>
        /// 记录的id号
        /// </summary>
        public string xrecord_id { get; set; }   //记录的id号
    }
    public enum Project_type
    {
        根节点,
        号楼,
        楼层,
        区域,
        构件,
        记录
    }
    public enum Xrecord_type
    {
        None,
        梁,
        板,
        柱,
        墙,
        其它
    }
    public class Drawing_Manage   //资源管理结构
    {
        public string id { get; set; }   //id号，12位GUID
        public string pid { get; set; }   //父id号
        public string name { get; set; }   //节点名称
        public Drawing_type type { get; set; }   //节点类型  0--根节点   1--资源类型    2--文件
        public string ext { get; set; }  //当type=2时，记录扩展名，节点名称则为文件名
    }
    public enum Drawing_type
    {
        根节点,
        资源类型,
        构造配置,
        文件
        
    }
    public class XRecord  //针对一张图纸识别、计算等一切数据的记录
    {
        public string id { get; set; }  //12位 GUID
        public string Drawing_Manage_id { get; set; }  //基于哪张图纸
        public Xrecord_type type { get; set; }   //1--梁   2--板  3--柱  4--墙  5--其它
        public string json { get; set; } //存详细记录数据，包括梁数据 Beam_XRrecord等        
    }

    public class Beam_XRrecord
    {
       public string Drawing_Manage_id { get; set; }  //基于哪张图纸
        //设置数据
        public string Concrete_type { get; set; }  //默认混凝土等级
        public string Rebar_type { get; set; }     //默认主筋等级
        public string Strup_type { get; set; }     //默认箍筋等级
        public string earth_type { get; set; }     //默认抗震等级
        //选择集
        public List<long> side_lines { get; set; }  //梁线集合
        public List<long> seat_lines { get; set; }  //支座线集合
        public List<long> dim_texts { get; set; }  //标注及标注线集合
        public List<Point3d> pto { get; set; } //识别范围
        //梁数据
        public List<Beam> beams { get; set; }
        public string overmm { get; set; }//超过N mm
        public string Rebar_overmm { get; set; }//超过N mm 用箍筋
    }
    public enum Side_type
    {
        主梁,//(KL)
        次梁,//(L)
        屋框梁,//(WKL)
        屋面次梁,//(WL)
        框支梁,//(KZL)
        连梁,//(LL)
        地梁//(JL或DL)
    }
    public class Beam //一段梁
    {
        public string id { get; set; }  //梁编号GUID
        //数据采集
        public List<long> side_lines { get; set; }  //梁边线
        public List<long> left_seat_lines { get; set; }  //左支座线
        public List<long> right_seat_lines { get; set; }  //右支座线
        public List<long> turn_lines { get; set; }  //折梁转折线
        public List<long> globe_dim { get; set; } //集中标注及线
        public List<long> public_frame_dim { get; set; } //原位：通长及架力钢筋标注
        public List<long> left_seat_dim { get; set; } //原位：左支座标注
        public List<long> right_seat_dim { get; set; } //原位：右支座标注
        public List<long> mid_dim { get; set; } //原位：跨中标注，含主筋、箍筋、腰筋
        //数据存储
        public bool isStartBeam { get; set; }  //是否为首段梁
        public string pid { get; set; } //梁归属id，即连续梁的左侧梁
        public Side_type type { get; set; } //梁类型 0主梁(KL)、1次梁(L)、2屋框梁(WKL)、3屋面次梁(WL)、4框支梁(KZL)、5连梁(LL)、6地梁(JL或DL)
        public string Concrete_type { get; set; }  //混凝土等级
        public string Rebar_type { get; set; }     //主筋等级
        public string Stirrup_type { get; set; }     //箍筋等级 
        public string earth_type { get; set; }     //抗震等级
        public List<Beam_Section> Sections { get; set; } //截面及标高
        public List<Rebar_Dim> Public_Bar { get; set; } //通长钢筋
        public List<Rebar_Dim> Frame_Bar { get; set; } //架力钢筋
        public List<List<Rebar_Dim>> Left_Seat_Rebars { get; set; } //左支座钢筋 每排什么样的钢筋组合
        public List<List<Rebar_Dim>> Right_Seat_Rebars { get; set; } //右支座钢筋 每排什么样的钢筋组合
        public List<List<Rebar_Dim>> Mid_Beam_Rebars { get; set; } //跨中钢筋 每排什么样的钢筋组合
        public List<Stirrup_Dim> Stirrup_info { get; set; }  //箍筋直径与间距,采用list是为多种直径箍筋混用准备的数据结构        
        public List<Rebar_Dim> Waist_Bar { get; set; } //腰筋
        public List<Rebar_Dim> Twist_Bar { get; set; } //抗扭筋
        //数据应用--平显   
        public List<long> PM_Line { get; set; }  //平显中心线
        public List<long> PM_Text { get; set; }  //平显文字
        //?1、当绘制出来后必须跟踪否则就会重新绘制
    }

    public class Beam_Section  //截面
    {
        public double a { get; set; }  //0~1，指距离左侧距离与全长之比
        public double b { get; set; }  //梁截面宽度
        public double h { get; set; }  //梁截面高度
        public double H { get; set; }  //梁顶标高
    }

    public class Rebar_Dim //主筋
    {
        public int n { get; set; }  //n根
        public double D { get; set; }  //直径
    }

    public class Stirrup_Dim  //箍筋
    {
        public double D { get; set; }  //直径
        public int n { get; set; } //箍筋肢数
        public double Sa { get; set; }  //箍筋非加密区间距
        public double Se { get; set; }  //箍筋加密区间距
    }


    public class GRecord   //资源下的构造类型文件
    {
        string name { get; set; } //构造方案的名称
        string json { get; set; } //记录配置设置
    }

}
