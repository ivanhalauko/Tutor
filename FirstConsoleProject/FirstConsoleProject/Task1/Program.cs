using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////Task1 Написать программу, которая принимает из командной
////строки последовательность символов (строку) в качестве
////аргумента и выводит в консоль максимальное количество
////неодинаковых последовательных символов в строке
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "aabccdff";
            Console.WriteLine(myString);
            int result = Program.GetMaxConsecutive(myString);
            Console.WriteLine(result);
        }

        public static int GetMaxConsecutive(string value)
        {
            int j = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (i + 1 == value.Length)
                {
                    return j;
                }
                if (value[i] != value[i + 1])
                {

                     j = j + 1;
                }
            }
            return j;
        }
    }

}
