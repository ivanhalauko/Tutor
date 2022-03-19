using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"Transmission" (type, number of gears, manufacturer).

namespace Task3
{
    class Transmission
    {
        public string typeTran;
        public int numberOfGears;
        public string manufacturer;
        public Transmission(string typeTran, int numberOfGears, string manufacturer)
        {
            this.typeTran = typeTran;
            this.numberOfGears = numberOfGears;
            this.manufacturer = manufacturer;
        }
    }
}
