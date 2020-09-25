using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxDrawXLib;
using ToolkipCAD.Algorithm;

namespace ToolkipCAD.Models
{
    class MyDrawLine
    {
        public string handle { get; set; }
        public MxDrawPoint StartPoint { get; set; }
        public MxDrawPoint EndPoint { get; set; }
        public string Layer { get; set; }
        public void ChangePoint()
        {
            MxDrawPoint p1 = StartPoint;
            MxDrawPoint p2 = EndPoint;
            double angle = MathSience.GetAngle2(StartPoint, EndPoint);
            if ((angle < 3 && angle > -2) || Math.Abs(Math.Round(angle)) == 180)//左右
            {
                if (p1.x > p2.x)
                {
                   StartPoint = p2;
                   EndPoint = p1;
                }
            }
            if ((angle > 80 && angle < 95) || (angle < -80 && angle > -95))//上下
            {
                if (p1.y > p2.y)
                {
                    StartPoint = p2;
                    EndPoint = p1;
                }
            }
        }
    }
}
