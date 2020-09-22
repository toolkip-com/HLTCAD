using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolkipCAD.Models
{
    public class Gouzao
    {
        //public List<GouZaoParam> gouZaoParams { get; set; }
        //public List<Waist> waists { get; set; }
        //public JsonParam JsonParam { get; set; }
        public List<GouZaoParam> T1Value { get; set; }
        public List<T2Values2> T2Value { get; set; }
        //public T1Values T1Values { get; set; }
        public T3Values T3Values { get; set; }
        public T4Values T4Values { get; set; }
        //public T2Values T2Values { get; set; }
        public string TName { get; set; }
    }
    public class GouZaoParam
    {
        public Levels Level { get; set; }
        public int MM { get; set; }
        public string Concrete { get; set; }//C30
        public string Rebars { get; set; }//HRB3400
        public double Value { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
    public enum Levels
    {
        一级=1,
        二级=2,
        三级=3,
        四级=4        
    }
    public class Waist
    {
        public int Hw { get; set; }
        public int B { get; set; }
        public string Value { get; set; }
    }
    public class JsonParam
    {
        public string TName1 { get; set; }
        public string TName3 { get; set; }
        public T2Values T2Values { get; set; }
        public T4Values T4Values { get; set; }
    }
    public class T1Values
    {
        public List<GouZaoParam> T1Value { get; set; }
        //public string Concrete { get; set; }
        //public string Rebars { get; set; }
        //public double Ratio { get; set; }
        //public double about { get; set; }
    }
    public class T2Values2
    {
        public string CValue { get; set; }
        public double RValue { get; set; }
        public double Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class T2Values
    {
        public List<T2Value> Values { get; set; }
        public double MM { get; set; }
    }
    public class T2Value
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public string Type { get; set; }
    }
    public class T3Values
    {
        public int StartB { get; set; }
        public int EndB { get; set; }
        public int StartHW { get; set; }
        public int EndHW { get; set; }
        public List<Waist> waists { get; set; }
    }
    public class T4Values
    {
        public string Angle { get; set; }
        public int Num { get; set; }
        public string Type { get; set; }
        public string Diam { get; set; }
    }
}
