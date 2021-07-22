using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int z;
            Mathan mathan = new Mathan();
            mathan.Add(out x, out z);
            mathan.Calculation(x, z);
            mathan.Show(x,z);
        }
    }
    class Mathan
    {
        public void Add(out int x,out int z)
        {
            Console.WriteLine("Введите значение x:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение z:");
            z = Convert.ToInt32(Console.ReadLine());
        }
        public double Calculation(int x,int z)
        {
            double f;
            if ((-5 < z) && (z < 0))
            {
                f = (Math.Sqrt(x) + 2);
                return f;
            }
            else if (z <= -5)
            {
                f = 2.5 * z;
                return f;
            }
            else
            {
                f = ((Math.Pow(x, 3) + 2)) / z;
                return f;
            }
        }
        public void Show(int x,int z)
        {
            double f = Calculation(x, z);
            Console.WriteLine(f);
        }
    }
}
