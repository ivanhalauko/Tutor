using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////Написать программу, принимающую из командной строки целое число в
////десятичной системе, и основание новой системы счисления (от 2 до 20),
////вывести в консоль преобразованное в эту систему исходное число.
namespace Task_2
{
    class Program

    {
        static void Main(string[] args)
        {
            int baseNumber = 11;
            int value = 21;
            Console.WriteLine(value);
            string result = Program.ConverTo2(value, baseNumber);
            Console.WriteLine(result);
        }

            public static string ConverTo2(int value, int baseNumber)
        {
            Dictionary<int, string> numbers = new Dictionary<int, string>()
            {
                {0,"0" },
                {1,"1" },
                {2, "2" },
                {3, "3" },
                {4, "4" },
                {5, "5" },
                {6, "6" },
                {7, "7" },
                {8, "8" },
                {9, "9" },
                {10, "A" },
                {11, "B" },
                {12, "C" },
                {13, "D"},
                {14, "E" },
                {15, "F" },
                {16, "G" },
                {17, "H" },
                {18, "I" },
                {19, "J" },
                {20, "K" },
            };
            int remOfDiv = 0;
            string result = null;
            if (baseNumber>9 && baseNumber <20)
            {
                int key = 0;
                string valueFromDictionary = null;
                numbers.TryGetValue(key,out valueFromDictionary);
                value = Math.DivRem(value, baseNumber, out remOfDiv);
                if (remOfDiv > 9)
                {
                    result = valueFromDictionary; 
                }
                else
                {
                    result = Convert.ToString(remOfDiv);
                }
                result = result + Convert.ToString(value);
            }
            else
            {
                while (value >= baseNumber)
                {
                    while (value >= baseNumber)
                    {
                        value = Math.DivRem(value, baseNumber, out remOfDiv);
                        result = result + Convert.ToString(remOfDiv);
                    }
                    if (value < baseNumber)
                    {
                        result = result + Convert.ToString(value);
                    }
                }
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = new string(charArray);
            return result;
        }
    }
}
