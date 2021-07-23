using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1var3
{
    class Program
    {
        static void Main(string[] args)
        {
            int y;
            int z;
            //int x;
            Mathematika mathematika = new Mathematika();
            mathematika.EnterData(out  y, out  z);
            mathematika.Counting(y, z);
            mathematika.ShowData(y, z);
        }
    }
    class Mathematika
    {
        public void EnterData(out int y, out int z)
        {
            Console.WriteLine("Здраствуйте");
            Console.ReadKey();
            Console.WriteLine("Введите значение y:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение z:");
            z = Convert.ToInt32(Console.ReadLine());
          
        }
        public double Counting(int y,int z)
        {
            double b;
                b=((Math.Sqrt(y))/(z+Math.Pow(y,3)*z))+1.35;
            return b;
        }
        public void ShowData(int y,int z)
        {
            double b = Counting(y, z);
            Console.WriteLine(b);
        }
    }
}
