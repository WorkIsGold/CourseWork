using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShestakovCourse2Work
{
    internal class Arrow//стрелочка на ориентированном ребре
    {
        protected System.Windows.Shapes.Line line1;
        protected System.Windows.Shapes.Line line2;
        protected Point[] points;
        protected int module1 = 15;
        protected int module2 = 5;
        public Arrow() 
        { 
            points = new Point[5];
            line1 = new System.Windows.Shapes.Line();
            line2 = new System.Windows.Shapes.Line();
            Panel.SetZIndex(line1, 1);
            Panel.SetZIndex(line2, 1);
        }
        public Arrow(Point point1, Point point2, Point point3, Point point4): this(point1, point2, false)
        {
            points[2] = point3;
            points[3] = point4;
            line1.X1 = point3.X;
            line1.Y1 = point3.Y;
            line2.X1 = point4.X;
            line2.Y1 = point4.Y;
        }
        public Arrow(Point point1, Point point2, bool flag = false): this()
        {
            points[0] = point1;
            points[1] = point2;
            line1.X2 = point2.X;
            line1.Y2 = point2.Y;
            line2.X2 = point2.X;
            line2.Y2 = point2.Y;
            if (flag)
            {
                SetArrow(point1, point2);
            }
        }
        public Arrow(Lines line): this(line.XY1, line.XY2, true) { }
        public void SetArrow(Point point1, Point point2)
        {
            Console.WriteLine("Point.X: " + point2.X);
            points[3].X = point2.X - ((point2.X - point1.X) * module1 + (point2.Y - point1.Y)*module2) / (Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2)));
            points[3].Y = point2.Y - ((point2.Y - point1.Y) * module1 - (point2.X - point1.X)*module2) / (Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2)));
            points[4].X = point2.X - ((point2.X - point1.X) * module1 - (point2.Y - point1.Y)*module2) / (Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2)));
            points[4].Y = point2.Y - ((point2.Y - point1.Y) * module1 + (point2.X - point1.X)*module2) / (Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2)));
            line1.X1 = points[3].X;
            line1.Y1 = points[3].Y;
            line2.X1 = points[4].X;
            line2.Y1 = points[4].Y;
        }
        public void RecreateArrow(Lines line)
        {
            points[0] = line.XY1;
            points[1] = line.XY2;
            line1.X2 = line.Line.X2;
            line1.Y2 = line.Line.Y2;
            line2.X2 = line.Line.X2;
            line2.Y2 = line.Line.Y2;
            SetArrow(line.XY1, line.XY2);
        }
        public System.Windows.Style Style
        {
            set { line1.Style = value; line2.Style = value; }
        }
        public System.Windows.Shapes.Line Line1
        {
            get { return line1; }
        }
        public System.Windows.Shapes.Line Line2
        {
            get { return line2; }
        }
    }
}
