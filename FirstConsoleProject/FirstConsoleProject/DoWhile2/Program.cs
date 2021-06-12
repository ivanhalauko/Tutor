using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhile2
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
                break;
                Console.WriteLine("This string don't work!");
            }
            while (counter < 3);
            Console.WriteLine("iteracii {0}",counter);
            Console.ReadKey();
            
        }
    }
}
