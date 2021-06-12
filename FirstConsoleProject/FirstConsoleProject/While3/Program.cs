using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While3
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while(counter<0)
            {
                counter++;
                Console.WriteLine("Counter {0}",counter);
                continue;
                Console.WriteLine("This string don't work");
            }
            Console.WriteLine("Proizvedeno {0} iteracii.",counter);
            Console.ReadKey();
        }
    }
}
