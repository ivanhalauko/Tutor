using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg8
{
    class Program
    {
        static void Main(string[] args)
        {
            string @string = "Hello";
            Console.WriteLine("Введите свой логин: ");
            string login = Console.ReadLine();
            @string += login == "Admin" ? "Administrator" : "User";
            Console.WriteLine(@string);
            Console.ReadKey();
        }
    }
}
