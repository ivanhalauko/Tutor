using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double side1 = 5;
            double side2 = 3;
            Rectangle rectangle = new Rectangle(side1,side2);
            Console.WriteLine(rectangle.Area);
            Console.WriteLine(rectangle.Perimetr);
        }
    }
    class Rectangle
    {
        private double _side1;
        private double _side2;
        public Rectangle(double side1,double side2)
        {
            _side1 = side1;
            _side2 = side2;
        }
        public double AreaCalculate(double side1,double side2)
        {
            return side1 * side2;
        }
        public double PerimCalculate(double side1,double side2)
        {
            return 2 * (side1 + side2);
        }
        public double Area
        {
           get
            {
                return AreaCalculate(_side1,_side2);
            }
        }
        public double Perimetr
        {
            get
            {
                return PerimCalculate(_side1, _side2);
            }
        }
    }
}
