﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public static class Lib
    {
        private static readonly Dictionary<int, string> _numbers = new Dictionary<int, string>()
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
        public static Dictionary<int, string> Numbers => _numbers;
    }
}
