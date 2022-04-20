using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    [Serializable]
    public class Vehicle
    {
        private Transmission _transmission;
        private Engine _engine;
        private Chassis _chassis;

        public Transmission Transmission { get => _transmission; set { _transmission = value; } }

        public Engine Engine { get => _engine; set { _engine = value; } }

        public Chassis Chassis { get => _chassis; set { _chassis = value; } }

        public override string ToString()
        {
            return $"Transmission:{Transmission}, Engine: {Engine}, Chassis:{Chassis}";
        }
    }
}