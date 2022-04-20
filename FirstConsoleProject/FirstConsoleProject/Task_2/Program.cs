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
    public class Program

    {
        //static void Main(string[] args)
        //{
        //    int baseNumber = 11;
        //    int value = 21;
        //    Console.WriteLine(value);
        //   string result = Program.ConverTo(value, baseNumber);
        //   Console.WriteLine(result);
        //}

        //public static string ConverTo(int value, int baseNumber)
        //{
        //    Dictionary<int, string> numbers = new Dictionary<int, string>()
        //    {
        //        {0,"0" },
        //        {1,"1" },
        //        {2, "2" },
        //        {3, "3" },
        //        {4, "4" },
        //        {5, "5" },
        //        {6, "6" },
        //        {7, "7" },
        //        {8, "8" },
        //        {9, "9" },
        //        {10, "A" },
        //        {11, "B" },
        //        {12, "C" },
        //        {13, "D"},
        //        {14, "E" },
        //        {15, "F" },
        //        {16, "G" },
        //        {17, "H" },
        //        {18, "I" },
        //        {19, "J" },
        //        {20, "K" },
        //    };
        //    int remOfDiv = 0;
        //    string result = null;
        //    if (baseNumber>9 && baseNumber <20)
        //    {
        //        string valueFromDictionary = null;
        //        value = Math.DivRem(value, baseNumber, out remOfDiv);
        //        if (remOfDiv > 9)
        //        {
        //            numbers.TryGetValue(remOfDiv, out valueFromDictionary);
        //            result = valueFromDictionary; 
        //        }
        //        else
        //        {
        //            result = Convert.ToString(remOfDiv);
        //        }
        //        result = result + Convert.ToString(value);
        //    }
        //    else
        //    {
        //        while (value >= baseNumber)
        //        {
        //            while (value >= baseNumber)
        //            {
        //                value = Math.DivRem(value, baseNumber, out remOfDiv);
        //                result = result + Convert.ToString(remOfDiv);
        //            }
        //            if (value < baseNumber)
        //            {
        //                result = result + Convert.ToString(value);
        //            }
        //        }
        //    }

        //    char[] charArray = result.ToCharArray();
        //    Array.Reverse(charArray);
        //    result = new string(charArray);
        //    return result;
        //}
        static void Main(string[] args)
        {
            int baseNumber = 11;
            int value = 21;
            Console.WriteLine(value);
            Console.WriteLine(AlgorithmWorking(value,baseNumber, Program.ConverTo(value, baseNumber)));
        }

        public static int ConverTo(int value, int baseNumber)
        {

            int remOfDiv = 0;
            value = Math.DivRem(value, baseNumber, out remOfDiv);
            return remOfDiv;
        }

        public static string AlgorithmWorking(int value, int baseNumber, int remOfDiv)
        {
            Dictionary<int, string> dictionary = Lib.Numbers;
            string result = null;
            if (baseNumber > 9 && baseNumber < 20)
            {
                string valueFromDictionary = null;

                if (remOfDiv > 9)
                {
                    dictionary.TryGetValue(remOfDiv, out valueFromDictionary);
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
