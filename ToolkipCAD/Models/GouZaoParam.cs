using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolkipCAD.Models
{
    class GouZaoParam
    {
        public Levels Level { get; set; }
        public int MM { get; set; }
        public string Concrete { get; set; }
        public string Rebars { get; set; }
        public string Value { get; set; }
    }   
    enum Levels
    {
        level1=1,
        level2=2,
        level3=3,
        level4=4        
    }
    class Waist
    {
        public int Hw { get; set; }
        public int B { get; set; }
        public string Value { get; set; }
    }
}
