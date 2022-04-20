using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//беспилотник парит в воздухе каждые 10 минут полета в течение 1 минуты.
//На основе поставленной задачи ввести дополнительные ограничения (например, невозможность управления беспилотником на расстоянии более 1000 км)

namespace Task4
{
    class Drone
    {
        private int _hoversSpeed;
        private int _flightSpeed;
        private int _currentPosition;
        private int _myProperty;
        private int _mySecondProperty;
        private int _flyTime;
        private int _endPoint;
        private int _hoverTime;
        private int _totalTime;
        private int _distance;

        public int HoversSpeed { get => _hoversSpeed; set { _hoversSpeed = value; } }

        public int FlightSpeed { get => _flightSpeed; set {_flightSpeed = value; } }
        public int CurrentPosition { get => _currentPosition; set { _currentPosition = value; } }

        public int FlyTime { get => _flyTime; set { _flyTime = value; } }

        public int HoverTime { get => _hoverTime; }

        public int EndPoint { get => _endPoint; set {_endPoint = value; } }

        public double Distance => FlyTo(); 
        public int MyProperty 
        {
            get
            { 
                if (_myProperty > 10)
                {
                    return _myProperty;
                }
                else
                {
                    throw new Exception("my property less 10");
                }
            }

            set
            {
                if (value > 100)
                {
                    throw new Exception("Value can't be more 100!!!");
                }
                else
                {
                    _myProperty = value;
                }
            }
        }
        public int MySecondProperty
        {
            get
            {
                if (_mySecondProperty > 10)
                {
                    return _mySecondProperty;
                }
                else
                {
                    throw new Exception("my property less 10");
                }
            }

            set
            {
                ////if (value > 100)
                ////{
                ////    throw new Exception("Value can't be more 100!!!");
                ////}
                ////else
                ////{
                ////    _mySecondProperty = value;
                ////}

                try
                {
                    if (value > 100)
                    {
                        throw new Exception("Value can't be more 100!!!");
                    }
                }
                catch (Exception)
                {
                    PrintMethod();
                }
                
                finally
                {
                    FinallyMethod();
                }
            }
        }

        private void FinallyMethod()
        {
            Console.WriteLine("Сработал файнэли");
        }

        private void PrintMethod()
        {
            Console.WriteLine("Yttffff");
        }

        //public Drone(int _speed, string _currenPosition)
        //{
        //    Speed = _speed;
        //    CurrentPosition = _currenPosition;
        //}
        //public override string ToString()
        //{
        //    return $"Speed: {Speed}, Curreent Position:{CurrentPosition}";
        //}

        private double FlyTo()
        {
            double dist = 0;
            try
            {
                dist= EndPoint - CurrentPosition;
                if (dist >1000)
                {
                    dist = 1000;
                    throw new Exception("The drone can't flight more than 1000 km");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dist;
        }
        private double GetFlyTime(double dist)
        {
            double distOnePiece = 0;
            double result = 0;
            double numberOfPieces;
            distOnePiece = FlyTime * FlightSpeed + HoverTime * HoversSpeed;
            numberOfPieces = dist / distOnePiece;
            result = numberOfPieces * 11;
            return result;
        }

        //private int GetFlyTime(int dist)
        //{
            
        //    return;
        //}
    }
}

