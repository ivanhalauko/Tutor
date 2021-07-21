using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while(counter<3)
            {
                counter++;
                Console.WriteLine("Counter {0}",counter);
            }
            Console.WriteLine("Proizvedeno {0} iteracii",counter);
            Console.ReadKey();
        }
    }
}
