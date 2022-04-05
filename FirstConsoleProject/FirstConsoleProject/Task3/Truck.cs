using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Truck
    {
        private Transmission _transmission;
        private Engine _engine;
        private Chassis _chassis;

        public Transmission Transmission { get => _transmission; set {_transmission = value; } }

        public Engine Engine { get => _engine; set {_engine = value; } }

        public Chassis Chassis { get => _chassis; set { _chassis = value; } }

        public Truck 
            (string typeTran, int numberOfGeats, string manufacturer,
            int _power, string _volume, string _type, int _serialNumber,
            int wheelsNumber, int number, int permissibleLoad)
        {
            Transmission = new Transmission(typeTran, numberOfGeats, manufacturer);
            Engine = new Engine(_power, _volume, _type, _serialNumber);
            Chassis = new Chassis(wheelsNumber, number, permissibleLoad);
        }
        public override string ToString()
        {
            return $"Transmission:{Transmission}, Engine: {Engine}, Chassis:{Chassis}";
        }
    }
}
