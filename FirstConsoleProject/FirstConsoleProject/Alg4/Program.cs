using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3, b = 3;
            if(a>b)
            {
                Console.WriteLine("a>b");
            }
            else if(a<b)
            {
                Console.WriteLine("a<b");
            }
            else
            {
                Console.WriteLine("a==b");//а приравнивается к б??
            }
            Console.ReadKey();
        }
    }
}
