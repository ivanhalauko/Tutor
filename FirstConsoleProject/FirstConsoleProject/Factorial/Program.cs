﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter=4;
            int factorial = 1;
            Console.Write("Factorial number: {0}!",counter);
            do
            {
                factorial *= counter--;

            }
            while (counter>0);
            Console.WriteLine(" {0}",factorial);
            Console.ReadKey();
        }
    }
}
