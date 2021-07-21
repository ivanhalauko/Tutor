using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condition = false;
            if(condition==true)
            {
                goto Label;
            }
            Console.WriteLine("First line");
        Label:
            Console.WriteLine("Second Line");
            Console.ReadKey();
        }
    }
}
