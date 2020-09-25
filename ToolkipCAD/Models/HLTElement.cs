using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolkipCAD
{
    public class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3d(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Point3d()
        {
        }
        public double DistanceTo(Point3d y)
        {
            return Math.Sqrt(Math.Pow(X - y.X, 2) + Math.Pow(Y - y.Y, 2));
        }
        public bool isEqual(Point3d p)
        {
            if (this.X == p.X && this.Y == p.Y) return true;
            else return false;
        }
        public bool isSimilar(Point3d p, double d)
        {
            if (Math.Abs(this.X - p.X) <= d && Math.Abs(this.Y - p.Y) <= d) return true;
            else return false;
        }
        public bool isSimilar(Point3d p)
        {
            return isSimilar(p, 0.1);
        }
        public double DistanceToLine(Line n)   //点与直线垂直距离
        {
            double ax = this.X; double ay = this.Y;
            double bx = n.StartPoint.X; double by = n.StartPoint.Y;
            double cx = n.EndPoint.X; double cy = n.EndPoint.Y;
            //3个边的长
            double ab = DistanceTo(n.StartPoint);
            double ac = DistanceTo(n.EndPoint);
            double bc = n.StartPoint.DistanceTo(n.EndPoint);
            //半周长
            double p = (ab + ac + bc) / 2;
            //面积(海仑公式)
            double s = Math.Sqrt(p * (p - ab) * (p - ac) * (p - bc));
            //高
            double h = 2 * s / bc;
            return h;
        }

        public bool DistanceToLineAndRelation(Line n, ref double re)
        {
            double vd = this.DistanceToLine(n);
            double a1 = Angle(n.StartPoint, this, n.EndPoint);
            double a2 = Angle(n.EndPoint, this, n.StartPoint);
            if (a1 > 0.001 && a2 > 0.001)
                if (a1 < 1.5708 && a2 < 1.5708)
                {
                    re = vd;
                    return true;
                }
            return false;
        }

        public bool PointSimilarInLine(Line le, double dd)
        {
            //if ((le.StartPoint.X == this.X && le.StartPoint.Y == this.Y) || (le.EndPoint.X == this.X && le.EndPoint.Y == this.Y)) return true;
            if (le.StartPoint.DistanceTo(this) <= dd || le.EndPoint.DistanceTo(this) < dd) return true;
            double vd = this.DistanceToLine(le);
            if (vd > dd) return false;
            double a1 = Angle(le.StartPoint, this, le.EndPoint); if (a1 < 0) a1 = a1 + Math.PI * 2; if (a1 == Math.PI * 2) a1 = 0;
            double a2 = Angle(le.EndPoint, this, le.StartPoint); if (a2 < 0) a2 = a2 + Math.PI * 2; if (a2 == Math.PI * 2) a2 = 0;
            if (a1 >= 0 && a2 >= 0)
                if (a1 <= Math.PI / 2 && a2 <= Math.PI / 2)
                {
                    return true;
                }
            //if ( (this.X >= Math.Min(le.StartPoint.X, le.EndPoint.X) && this.X <= Math.Max(le.StartPoint.X, le.EndPoint.X))
            //    || (this.Y >= Math.Min(le.StartPoint.Y, le.EndPoint.Y) && this.Y <= Math.Max(le.StartPoint.Y, le.EndPoint.Y))) return true;
            return false;
        }

        //求角度
        public double Angle(Point3d cen, Point3d first, Point3d second)
        {
            //CosC=(a^2+b^2-c^2)/2ab
            double angle = -1;
            double a = cen.DistanceTo(first);
            double b = cen.DistanceTo(second);
            double c = first.DistanceTo(second);
            if (a == 0 || b == 0) angle = -1;
            else
            {
                double d = (a * a + b * b - c * c);
                double e = (2 * a * b);

                //if ((d - e) < 0.001) return 0;
                d = Math.Round(d, 4); e = Math.Round(e, 4);
                angle = Math.Acos(d / e);

            }
            return angle;
        }
    }

    public class Color
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public Color()
        {
        }
        public Color(byte Red, byte Green, byte Blue)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
        }
    }

    public class Line
    {
        public Point3d StartPoint { get; set; }
        public Point3d EndPoint { get; set; }
        public string colorstring { get; set; }
        public Color Color { get; set; }
        public string Layer { get; set; }
        public string Linetype { get; set; }
        public double Length()
        {
            return StartPoint.DistanceTo(EndPoint);
        }
        public Line(Point3d StartPoint, Point3d EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public Line()
        {

        }
        public bool isparallel(Line l2, int type)   //type 0:平行|轴平移   1:相关平行
        {
            bool re = false;
            if (this.Equals(l2)) return false;
            switch (type)
            {
                case 0:
                    if (this.Length() == l2.Length())
                    {
                        int bg = 0;
                        if (Math.Min(this.StartPoint.X, this.EndPoint.X) == Math.Min(l2.StartPoint.X, l2.EndPoint.X) && Math.Max(this.StartPoint.X, this.EndPoint.X) == Math.Max(l2.StartPoint.X, l2.EndPoint.X)) bg++;
                        if (Math.Min(this.StartPoint.Y, this.EndPoint.Y) == Math.Min(l2.StartPoint.Y, l2.EndPoint.Y) && Math.Min(this.StartPoint.Y, this.EndPoint.Y) == Math.Min(l2.StartPoint.Y, l2.EndPoint.Y)) bg++;
                        if (bg == 1) re = true;
                    }
                    break;
                case 1:
                    double k1 = this.EndPoint.X - this.StartPoint.X;
                    double k2 = l2.EndPoint.X - l2.StartPoint.X;
                    if (Math.Abs(Math.Abs(k1) - Math.Abs(k2)) < Math.PI / 180 * 1)
                    {
                        if ((l2.StartPoint.Y >= Math.Min(this.StartPoint.Y, this.EndPoint.Y) && l2.StartPoint.Y <= Math.Max(this.StartPoint.Y, this.EndPoint.Y))
                            || (l2.EndPoint.Y >= Math.Min(this.StartPoint.Y, this.EndPoint.Y) && l2.EndPoint.Y <= Math.Max(this.StartPoint.Y, this.EndPoint.Y))) return true;
                    }
                    else
                    {
                        k1 = (this.EndPoint.Y - this.StartPoint.Y) / k1;
                        k2 = (l2.EndPoint.Y - l2.StartPoint.Y) / k2;
                        k1 = Math.Atan(k1); k2 = Math.Atan(k2);
                        if (k1 == k2 || k1 == -k2)
                        {
                            if (TriangleType(this.StartPoint, l2.StartPoint, l2.EndPoint) == 0 || TriangleType(this.EndPoint, l2.StartPoint, l2.EndPoint) == 0) return true;
                        }
                    }
                    break;
            }
            return re;
        }

        public int TriangleType(Point3d a, Point3d b, Point3d c)  //返回0锐角三角形  1直角三角形   2钝角三角形
        {
            double j1 = Angle(a, b, c);
            double j2 = Angle(b, a, c);
            double j3 = Angle(c, a, b);
            if (j1 > Math.PI / 2 || j2 > Math.PI / 2 || j3 > Math.PI / 2) return 2;
            else
            {
                if (j1 == Math.PI / 2 || j2 == Math.PI / 2 || j3 == Math.PI / 2) return 1;
                else
                    return 0;
            }
        }

        public double Angle(Point3d cen, Point3d first, Point3d second)
        {
            //CosC=(a^2+b^2-c^2)/2ab
            double angle = -1;
            double a = cen.DistanceTo(first);
            double b = cen.DistanceTo(second);
            double c = first.DistanceTo(second);
            if (a == 0 || b == 0) angle = -1;
            else angle = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            return angle;
        }


        public double boundingboxarea()
        {
            double w = Math.Abs(this.StartPoint.X - this.EndPoint.X);
            double h = Math.Abs(this.StartPoint.Y - this.EndPoint.Y);
            return w * h;
        }
        public bool issame(Line e)
        {
            if (this.StartPoint.Equals(e.StartPoint) && this.EndPoint.Equals(e.EndPoint)) return true;
            if (this.StartPoint.Equals(e.EndPoint) && this.EndPoint.Equals(e.StartPoint)) return true;
            return false;
        }

        public double K()
        {
            //if (StartPoint.Y == EndPoint.Y) return 0;
            if (StartPoint.X == EndPoint.X) return Math.PI / 2.0;
            else
            {
                double k = Math.Abs(Math.Atan((StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X)));
                if (k < 0) k = k + Math.PI;
                return k;
            }
        }
        //这条线的   这个点，     与  某线      找到    线端的点   距离在wi     凸头连续
        public bool iscontinuecross(Point3d p, Line tline, ref Point3d outnextp, double wi)
        {
            List<Point3d> pk = new List<Point3d>();
            pk.Add(tline.StartPoint); pk.Add(tline.EndPoint);
            for (int i = 0; i < 2; i++)
            {
                if (pk[i].DistanceTo(p) < wi * 2)
                {
                    try
                    {
                        double d1 = pk[i].DistanceToLine(this);
                        double d2 = p.DistanceToLine(tline);
                        if (Math.Abs(d1 - d2) <= wi / 100.0 * 2)
                        {
                            Point3d rep = new Point3d();
                            try
                            {
                                if (this.iscross(tline, ref rep, 0))
                                {
                                    if (i == 0) outnextp = pk[1];
                                    else outnextp = pk[0];
                                    return true;
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            return false;
        }

        public bool iscross(Line le, ref Point3d rep, int type)   //type 0 交点必须在线段内   type 1 近处远处交点都可以
        {
            double x0 = this.StartPoint.X;
            double y0 = this.StartPoint.Y;
            double x1 = this.EndPoint.X;
            double y1 = this.EndPoint.Y;
            double x2 = le.StartPoint.X;
            double y2 = le.StartPoint.Y;
            double x3 = le.EndPoint.X;
            double y3 = le.EndPoint.Y;
            double a = y1 - y0;
            double b = x1 * y0 - x0 * y1;
            double c = x1 - x0;
            double d = y3 - y2;
            double e = x3 * y2 - x2 * y3;
            double f = x3 - x2;
            if (a == 0)
            {
                if (y3 == y0) return false;
                else
                {
                    rep.Y = y0;
                    double m = (y2 - y0) / (y0 - y3);
                    if (m + 1 == 0) return false;
                    rep.X = (x2 + m * x3) / (m + 1);
                    if (type == 0)
                    {
                        if (rep.X >= Math.Min(x0, x1) - 1)
                            if (rep.X >= Math.Min(x2, x3) - 1)
                                if (rep.X <= Math.Max(x0, x1) + 1)
                                    if (rep.X <= Math.Max(x2, x3) + 1)
                                        if (rep.Y >= Math.Min(y0, y1) - 1)
                                            if (rep.Y >= Math.Min(y2, y3) - 1)
                                                if (rep.Y <= Math.Max(y0, y1) + 1)
                                                    if (rep.Y <= Math.Max(y2, y3) + 1)
                                                    {
                                                        return true;
                                                    }
                                                    else { return false; }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            if (a * f - c * d == 0) return false;
            double y = (a * e - b * d) / (a * f - c * d);
            double x = (y * c - b) / a;
            rep = new Point3d(x, y, 0);
            if (type == 0)
            {
                if (x >= Math.Min(x0, x1) - 1)
                    if (x >= Math.Min(x2, x3) - 1)
                        if (x <= Math.Max(x0, x1) + 1)
                            if (x <= Math.Max(x2, x3) + 1)
                                if (y >= Math.Min(y0, y1) - 1)
                                    if (y >= Math.Min(y2, y3) - 1)
                                        if (y <= Math.Max(y0, y1) + 1)
                                            if (y <= Math.Max(y2, y3) + 1)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
            }
            else
            {
                return true;
            }
            return false;
        }


    }

    public class Text
    {
        public Point3d Position { get; set; }
        public string Layer { get; set; }
        public string colorstring { get; set; }
        public Color Color;
        public string TextString { get; set; }
        public double Height { get; set; }
        public double Rotation { get; set; }
        public double Distance(Text c2)
        {
            return Math.Sqrt(Math.Pow((this.Position.X - c2.Position.X), 2) + Math.Pow(this.Position.Y - c2.Position.Y, 2));
        }
        public Point3d PositionMoveToCenter()
        {
            double dis = 0.5 * (0.8 * Height) * TextString.Length;
            double x = Position.X + Math.Cos(Rotation) * dis;
            double y = Position.Y + Math.Sin(Rotation) * dis;
            return new Point3d(x, y, Position.Z);
        }
        public Point3d PositionMoveToEnd()
        {
            double dis = (0.8 * Height) * TextString.Length;
            double x = Position.X + Math.Cos(Rotation) * dis;
            double y = Position.Y + Math.Sin(Rotation) * dis;
            return new Point3d(x, y, Position.Z);
        }
    }
    

    public class ComputeClass
    {
        public double fy(string gtype) {
            double re = 0;
            switch (gtype)
            {
                case "HPB300":
                    re = 270;
                    break;
                case "HRB335,HRBF335":
                    re = 300;
                    break;
                case "HRB400,HRBF400,RRB400":
                    re = 360;
                    break;
                case "HRB500,HRBF500":
                    re = 435;
                    break;
            }
            return re;
        }

        public double ft(string ctype)
        {
            double re = 0;
            switch (ctype)
            {
                case "C15":  re = 0.91; break;
                case "C20": re =1.1; break;
                case "C25": re = 1.27; break;
                case "C30": re = 1.43; break;
                case "C35": re = 1.57; break;
                case "C40": re = 1.71; break;
                case "C45": re = 1.8; break;
                case "C50": re = 1.89; break;
                case "C55": re = 1.96; break;
                case "C60": re = 2.04; break;
                case "C65": re = 2.09; break;
                case "C70": re = 2.14; break;
                case "C75": re = 2.18; break;
                case "C80": re = 2.22; break;
            }
            return re;
        }

        public List<double> GetRebarDList()
        {
            List<double> re = new List<double>();
            for (int i = 1; i <= 9; i++) re.Add(6 + (i - 1) * 2);
            re.Add(25);re.Add(28);re.Add(32);re.Add(36);re.Add(40);re.Add(50);
            return re;
        }

        //腰筋计算，代入b与h，则返回钢筋根数、直径
        public bool waist(double b,double h,ref int n,ref double D)
        {
            bool re = true;
            List<double> dlist = GetRebarDList();
            List<double> drear = new List<double>();
            for (int i = 0; i < dlist.Count; i++) drear.Add(Math.PI*dlist[i]*dlist[i]/4.0);
            double n1 =Convert.ToDouble((h / 200).ToString("0.00"));  
            double n2 = Convert.ToDouble((h / 200).ToString("0"));
            if (n1 != n2) n2 = n2 + 1;
            n = Convert.ToInt32(n2)*2;
            double xas = 0.2 * b * h / 100.0;
            if (n * dlist[dlist.Count - 1] < xas) // 如果最大钢筋都不足
            {

                double n3 = Convert.ToDouble((xas / drear[drear.Count - 1]).ToString("0.00"));
                double n4 = Convert.ToDouble((xas / drear[drear.Count - 1]).ToString("0"));
                double n5 = n4;
                if (n3 != n4) n5 = n4 + 1;
                if (n5 % 2 == 1) n5 = n5 + 1;
                n = Convert.ToInt32(n5); D = dlist[dlist.Count - 1];
                return true;
            }
            else //一般情况
            {
                int bg1 = 0;
                for (int k = 0; k <= drear.Count; k++)
                {
                    if (n * drear[k] >= xas && bg1 == 0)
                    {
                        bg1 = 1;
                        D = dlist[k];
                        return true;
                    }
                }
            }
            return re;
        }

        //锚固长度计算，代入混凝土类型C30、钢筋类型HRB300、直径、抗震等级，返回长度
        public double anchoragelength(string ctype,string gtype,double D=0,string earthquake=null)
        {
            double re = 0;
            //a*fy/ft*d
            int ct = Convert.ToInt32(ctype.Replace("C", ""));
            if (ct > 60) ctype = "C60";
            double a = 0.14;
            if (gtype == "HPB300") a = 0.16;
            double ftv = ft(ctype);
            double fyv = fy(gtype);
            re = a * fyv / ftv;
            re = Convert.ToDouble(re.ToString("0"));
            return re;
        }
        public double AbeliteSet(double d)
        {
            return Math.Round(78.5 * Math.PI * (d / 2000) * (d / 2000) * 100,3);
        }


    }



}
