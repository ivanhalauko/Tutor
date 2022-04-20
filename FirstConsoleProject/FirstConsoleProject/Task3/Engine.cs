using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//"Engine" (includes the next fields: power, volume, type, serial number),

namespace Task3
{
    public class Engine
    {
        private  int _power;
        private  string _volume;
        private  string _type;
        private  int _serialNumber;
        public int Power { get { return _power; } set { _power = value; } }

        public string Volume { get=>_volume; set {_volume = value; } }

        public string Type { get=>_type; set {_type = value;} }

        public int SerialNumber { get=>_serialNumber; set {_serialNumber = value; } }

        public Engine(int power, string volume, string type, int serialNumber)
        {
            Power = _power;
            Volume = _volume;
            Type = _type;
            SerialNumber = _serialNumber;
        }

        public Engine()
        {
        }

        public override string ToString()
        {
            return $"EnginePower: {Power}, Volume:{Volume},Type{Type}, SerialNumber:{SerialNumber}";
        }
    }
}
