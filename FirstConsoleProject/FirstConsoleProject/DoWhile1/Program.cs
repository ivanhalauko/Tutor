using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhile1
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
            }
            while (counter < 3);
            Console.WriteLine("Произведено {0} итераций",counter);
            Console.ReadKey();
        }
    }
}
