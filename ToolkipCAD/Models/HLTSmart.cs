using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MxDrawXLib;

namespace ToolkipCAD.Models
{
    class HLTSmart
    {
        //关键字搜索函数  GetWord（源，正则组）
        public List<Text> GetWord(List<Text> ctext, List<Regex> regex)
        {
            List<Text> re = new List<Text>();
            for (int i = 0; i < ctext.Count; i++)
            {

                //寻找关键项
                for (int j = 0; j < regex.Count; j++)
                {
                    if (regex[j].IsMatch(ctext[i].TextString))
                    {
                        re.Add(ctext[i]);
                        break;
                    }
                }
            }
            return re;
        }

        //框选文字   只要文字的一部分或者全部在这两个点组成的box里面，就被选中
        public List<Text> SelectTextByBox(List<Text> ctext, Point3d p1, Point3d p2)
        {
            List<Text> re = new List<Text>();
            Line lv = new Line(p1, p2);
            for (int i = 0; i < ctext.Count; i++)
            {
                Point3d pp1 = ctext[i].Position;
                Point3d pp2 = ctext[i].PositionMoveToEnd();
                Line l2 = new Line(pp1, pp2);
                if (lv.iscross(l2, ref pp1, 1)) re.Add(ctext[i]);
            }
            return re;
        }
        public List<Text> SelectTextByBox(List<Text> texts,MxDrawPoint ps,Point3d pe)
        {
            List<Text> re = new List<Text>();

            return re;
        }

    }
}
