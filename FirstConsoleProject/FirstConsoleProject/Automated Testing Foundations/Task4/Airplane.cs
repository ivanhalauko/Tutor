using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Airplane : IFlyble
    {
        private int _speed = 0;
        private int _currentPosition;
        private const int VELOSITYSTEP = 10;
        private int _endPoint;
        private int _flyTime;

        public int Speed 
        { 
            get => _speed = _speed + VELOSITYSTEP;
        }

        public int CurrentPosition { get => _currentPosition; set { _currentPosition = value; } }

        public int EndPoint { get => _endPoint; set { _endPoint = value; } }

        public int FlyTime { get => GetFlyTime(EndPoint); set { _flyTime = value; } }


        public Airplane(int _endPoint, int _currenPosition)
        {
            EndPoint = _endPoint;
            CurrentPosition = _currenPosition;
        }


        public int FlyTo(int finish)
        {
            EndPoint = finish;
            return EndPoint - CurrentPosition;
        }
        public int GetFlyTime(int finish)
        {
            int time = 0;
            int step = FlyTo(finish) / 10;
            for (int i = 0; i < step; i++)
            {
               int timeStep = step / Speed;
                time = time + timeStep;
            }
            FlyTime = time;
            return FlyTime;
        }
        public override string ToString()
        {
            return $"Speed: {Speed}, Curreent Position:{CurrentPosition}";
        }
    }
}

