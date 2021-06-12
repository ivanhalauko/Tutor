using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhile4
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            do
            {
                counter++;
                Console.WriteLine("Counter {0}", counter);
                continue;
                Console.WriteLine("This string don't work.");
            }
            while (counter < 3);
            Console.WriteLine("Iteracii {0}",counter);
            Console.ReadKey();
        }
    }
}
