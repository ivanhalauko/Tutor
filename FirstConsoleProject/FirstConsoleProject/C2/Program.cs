using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
        Label1:
            counter++;
            Console.WriteLine("Counter={0}",counter);
            if (counter < 20)
            {
                goto Label1;
            }
            else
            {
                Console.WriteLine("End");
            }
            Console.ReadKey();
        }
    }
}
