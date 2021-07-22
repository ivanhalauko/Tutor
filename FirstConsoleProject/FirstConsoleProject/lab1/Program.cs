using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int z;
            int y;
            int x;
            Mathan mathan = new Mathan();
            mathan.Add(out z, out y, out x);
            mathan.Calculation(z, y, x);
            mathan.Show(z, y, x);
        }
    }
    class Mathan
    {
        public void Add(out int z,out int y,out int x)
        {
            Console.WriteLine("Введите значение z:");
            z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение y:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение x:");
            x = Convert.ToInt32(Console.ReadLine());
        }
        public double Calculation(int z,int y,int x)
        {
            double b;
            b = z * (y - (Math.Pow(x + y, -2)));
            return b;
        }
        public void Show(int z,int y,int x)
        {
            double b = Calculation(z, y, x);
            Console.WriteLine(b);
        }
    }
}
