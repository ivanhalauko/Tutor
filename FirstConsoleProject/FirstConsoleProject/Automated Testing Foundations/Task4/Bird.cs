using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Bird : IFlyble
    {
        private int _speed;
        private int _currentPosition;
        private int _endPoint;
        private int _flyTime;

        public int Speed { get => _speed; set {_speed = value; } }

        public int CurrentPosition { get => _currentPosition; set {_currentPosition = value; } }
        public int EndPoint { get => _endPoint; set {_endPoint = value; } }

        public int FlyTime { get => GetFlyTime(); set {_flyTime = value; } }

        public Bird(int _speed , int _currenPosition)
        {
            Speed = _speed;
            CurrentPosition = _currenPosition;
        }
        public override string ToString()
        {
            return $"Speed: {Speed}, Curreent Position:{CurrentPosition}";
        }

        public int FlyTo(int finish)
        {
            _endPoint = finish;
            return _endPoint; 
        }

        public int GetFlyTime()
        {
            FlyTime = (_currentPosition - _endPoint) / _speed;
            return FlyTime;
        }
    }
}
