using System;

namespace Task3
{
    [Serializable]
    public class Scooter : Vehicle
    {
        public Scooter
            (string typeTran, int numberOfGeats, string manufacturer,
            int _power, string _volume, string _type, int _serialNumber,
            int wheelsNumber, int number, int permissibleLoad)
        {
            Transmission = new Transmission(typeTran, numberOfGeats, manufacturer);
            Engine = new Engine(_power, _volume, _type, _serialNumber);
            Chassis = new Chassis(wheelsNumber, number, permissibleLoad);
        }

        public Scooter()
        {
        }

        public override string ToString()
        {
            return $"Transmission:{Transmission}, Engine: {Engine}, Chassis:{Chassis}";
        }
    }
}
