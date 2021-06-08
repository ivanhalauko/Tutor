using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg9_SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите Y или N");
            string selection = Console.ReadLine();
            selection = selection.ToUpper();
            switch (selection)
            {
                case "Y":
                    Console.WriteLine("Вы нажали букву Y");
                    break;
                case "N":
                    Console.WriteLine("Вы нажали букву N");
                    break;
                default:
                    Console.WriteLine("Вы нажали неизвестную букву");
                    break;
            }
        }
    }
}
