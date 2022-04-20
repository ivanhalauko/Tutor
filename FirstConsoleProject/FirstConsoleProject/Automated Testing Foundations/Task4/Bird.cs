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

        public int Speed 
        { 
            get => _speed; 
            set 
            {
                _speed = new Random().Next(0, 20);
                _speed = CatchValueSpeed(_speed);
            } 
        }

        private int CatchValueSpeed(int _speed)
        {
            while (_speed == 0)
            {
                _speed = new Random().Next(0, 20);
            }
            return _speed;
        }
        public int CurrentPosition { get => _currentPosition; set {_currentPosition = value; } }
        public int EndPoint { get => _endPoint; set {_endPoint = value; } }

        public int FlyTime { get => GetFlyTime(EndPoint); set {_flyTime = value; } }

        public Bird(int _endpoint, int _currenPosition)
        {
            EndPoint = _endPoint;
            CurrentPosition = _currenPosition;
        }
        public override string ToString()
        {
            return $"Speed: {Speed}, Curreent Position:{CurrentPosition}";
        }

        public int FlyTo(int finish)
        {
            return finish; 
        }

        public int GetFlyTime(int finish)
        {
            FlyTime = (_currentPosition - finish) / _speed;
            return FlyTime;
        }
    }
}
