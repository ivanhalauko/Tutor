using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While2
{
    class Program
    {
        static void Main(string[] args)
        {
            int condition = 0;
            while(condition<3)
            {
                condition++;
                    Console.WriteLine("Condition {0}",condition);
                break;
                Console.WriteLine("Эта строка не выполнится.");
            }
            Console.WriteLine("Proizvedeno {0} iteracii",condition);
            Console.ReadKey();
        }
    }
}
