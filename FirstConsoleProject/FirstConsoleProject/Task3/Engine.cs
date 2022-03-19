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
        public int power;
        public string volume;
        public string type;
        public int serialNumber;
        public Engine(int power, string volume, string type, int serialNumber)
        {
            this.power = power;
            this.volume = volume;
            this.type = type;
            this.serialNumber = serialNumber;
        }
    }
}
