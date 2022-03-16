using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.WriteLine(prog.ToString());

        }
        public override string ToString()
        {
            return numberOfWheels + powerOfEngine + nameOfClass;
        }
    }
    }
}
