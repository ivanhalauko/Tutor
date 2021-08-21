using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Figure
    {
        private Point _firstPoint;
        private Point _secondPoint;
        private Point _thirdPoint;
        private Point _fourPoint;
        private Point _fivePoint;
        public string _name;
        public Figure(Point firstPoint,Point secondPoint,Point thirdPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
            _thirdPoint = thirdPoint;
            _name = "Triangle";
        }

        public Figure(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
            _thirdPoint = thirdPoint;
            _fourPoint = fourPoint;
            _name = "Tetragon";
        } 

        public Figure(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourPoint, Point fivePoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
            _thirdPoint = thirdPoint;
            _fourPoint = fourPoint;
            _fivePoint = fivePoint;
            _name = "Pentagon";
        }
        public double CalculateLenghtSide(Point A, Point B)
        {
            double length=0;
            int xA = A.X;
            int yA = A.Y;
            int xB = B.X;
            int yB = B.Y;
            int x = xB - xA;
            int y = yB - yA;
            length = Math.Pow(x*x + y*y,1/2);
            return length;
        }
        public double CalculatePerimetr(Figure figure)
        {
            double sideA;
            double sideB;
            double sideC;
            double sideD;
            double sideE;
            double p = 0;
            Point a;
            Point b;
            Point c;
            Point d;
            Point e;
            a = figure._firstPoint;
            b = figure._secondPoint;
            c = figure._thirdPoint;
            d = figure._fourPoint;
            e = figure._fivePoint;
            if (figure._name == "Triangle")
            {
                sideA = CalculateLenghtSide(a, b);
                sideB = CalculateLenghtSide(c, b);
                sideC = CalculateLenghtSide(c, a);
                p = sideA + sideB + sideC;
            }
            else if(figure._name == "Tetragon")
            {
                sideA = CalculateLenghtSide(a, b);
                sideB = CalculateLenghtSide(c, b);
                sideC = CalculateLenghtSide(c, d);
                sideD= CalculateLenghtSide(d, a);
                p = sideA + sideB + sideC + sideD;
            }
           else if (figure._name == "Pentagon")
            {
                sideA = CalculateLenghtSide(a, b);
                sideB = CalculateLenghtSide(c, b);
                sideC = CalculateLenghtSide(c, d);
                sideD = CalculateLenghtSide(d, e);
                sideE = CalculateLenghtSide(e, a);
                p = sideA + sideB + sideC + sideD + sideE;
            }
            return p;
        }
    }
}
