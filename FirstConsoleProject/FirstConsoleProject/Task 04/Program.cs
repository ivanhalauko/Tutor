using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Point firstPoint = new Point(3,5,"a");
            Point secondPoint = new Point(6, 7, "b");
            Point thirdPoint = new Point(8, 9, "c");
            Point fourPoint = new Point(1, 2, "d");
            Point fivePoint = new Point(4, 0, "e");
            Figure figure = new Figure(firstPoint,secondPoint,thirdPoint,fourPoint, fivePoint);
            Console.WriteLine(figure._name);
            Console.WriteLine(figure.CalculatePerimetr(figure));
        }
    }
}
