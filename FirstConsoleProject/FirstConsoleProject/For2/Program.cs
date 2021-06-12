using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For2
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int counter=0;counter<3;counter++)
            {
                Console.WriteLine("Counter={0}",counter);
                break;
                Console.WriteLine("This string don't work");
            }
            Console.ReadKey();
        }
    }
}
