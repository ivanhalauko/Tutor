using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 0, B = 5, x = 7;
            if (A<x&&x<B)
            {
                Console.WriteLine("Число {0} находится в диапазоне от {1} до {2}.",x,A,B);
            }
            else
            {
                Console.WriteLine("Число {0} не попадает в диапазон чисел от {1} до {2}.",x,A,B);
            }
            Console.ReadKey();
        }
    }
}
