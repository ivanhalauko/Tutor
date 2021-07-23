using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int z;
            int x;
            Ras ras = new Ras();
            ras.Add(out z, out x);
            ras.Couting(z,x);
            ras.Show(z, x);
        }
    }
    class Ras
    {
        public void Add(out int z,out int x)
        {
            Console.WriteLine("Enter z:");
            z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter x:");
            x = Convert.ToInt32(Console.ReadLine());
        }
        public double Couting(int z,int x)
        {
            double f;
            if((-5<=x)&&(x<-2))
            {
                f = (Math.Sqrt(z) * Math.Sqrt(x)) + (1.2 / (x + 2));
                return f;
            }
            else if(x>=-2)
            {
                f = (3 * x + z);
                return f;
            }
            else
            {
                f = (0.01 * (Math.Pow(x, 4)));
                return f;
            }
        }
        public void Show(int z,int x)
        {
            double f = Couting(z,x);
            Console.WriteLine(f);
        }
    }
}
