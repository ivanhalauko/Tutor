using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
        Label1:
            Console.WriteLine("Hello!");
            goto Label1;
        }
    }
}
