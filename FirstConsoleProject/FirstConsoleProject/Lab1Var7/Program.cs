using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Var7
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int x;
            double f;
            Mathematic mathematic = new Mathematic();
            mathematic.EnterData(out a,out b,out x);
            mathematic.Calculation(a, b, x);
            mathematic.ShowResult(a, b, x);
        }
    }
    class Mathematic
    {
        public void EnterData(out int a,out int b,out int x)
        {
            Console.WriteLine("Введите значение а:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение b:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение x:");
            x = Convert.ToInt32(Console.ReadLine());
        }
        public double Calculation(int a,int b,int x)
        {
            double f;
            f = (a / 2 * b) + (1.3 + x) / (a + Math.Pow(b, 3));
            return f;
        }
        public void ShowResult(int a,int b,int x)
        {
            double f=Calculation(a, b, x);
            Console.WriteLine(f);
        }
    }
}
