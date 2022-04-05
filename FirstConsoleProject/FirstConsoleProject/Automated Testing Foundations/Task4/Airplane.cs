using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Airplane
    {
        private int _speed;
        private string _currentPosition;

        public int Speed { get => _speed; set { _speed = value; } }

        public string CurrentPosition { get => _currentPosition; set { _currentPosition = value; } }

        public Airplane(int _speed, string _currenPosition)
        {
            Speed = _speed;
            CurrentPosition = _currenPosition;
        }
        public override string ToString()
        {
            return $"Speed: {Speed}, Curreent Position:{CurrentPosition}";
        }
    }
}

