using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Point
    {
        private int _x;
        private int _y;
        private string _name;
        public int X { get => _x;}
        public int Y { get => _y;}
        public string Name { get => _name;}
        public Point(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
        }
    }
}
