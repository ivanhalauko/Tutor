using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"Transmission" (type, number of gears, manufacturer).

namespace Task3
{
    public class Transmission
    {
        private string _typeTran;
        private int _numberOfGears;
        private string _manufacturer;

        public string TypeTran { get => _typeTran ; set {_typeTran = value; } }

        public int NumberOfGears { get => _numberOfGears; set {_numberOfGears = value; } }

        public string Manufacturer { get => _manufacturer; set{ _manufacturer = value; } }
        public Transmission(string _typeTran, int _numberOfGears, string _manufacturer)
        {
            TypeTran = _typeTran;
            NumberOfGears = _numberOfGears;
            Manufacturer = _manufacturer;
        }

        public Transmission()
        {
        }

        public override string ToString()
        {
            return $"Type Tran: {TypeTran}, Number of Gears:{NumberOfGears},Manufacturer:{Manufacturer}";
        }
    }
}
