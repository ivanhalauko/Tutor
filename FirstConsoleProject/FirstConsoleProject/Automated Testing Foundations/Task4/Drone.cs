using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Drone
    {
        private int _speed;
        private string _currentPosition;
        private int _myProperty;
        private int _mySecondProperty;

        public int Speed { get => _speed; set { _speed = value; } }

        public string CurrentPosition { get => _currentPosition; set { _currentPosition = value; } }

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

        public Drone(int _speed, string _currenPosition)
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

