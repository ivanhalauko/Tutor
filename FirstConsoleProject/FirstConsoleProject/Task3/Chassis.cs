using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"Chassis" (wheels number, number, permissible load)

namespace Task3
{
    public class Chassis
    {
       private int _wheelsNumber;
       private int _number;
       private int _permissibleLoad;

        public int WheelsNumber { get => _wheelsNumber; set { _wheelsNumber = value; } }
        public int Number { get => _number; set {_number = value; } }
        public int PermissibleLoad { get => _permissibleLoad; set {_permissibleLoad = value; }
        }
        public Chassis(int _wheelsNumber, int _number, int _permissibleLoad)
        {
            WheelsNumber = _wheelsNumber;
            Number = _number;
            PermissibleLoad = _permissibleLoad;
        }
        public override string ToString()
        {
            return $"Wheels Number: {WheelsNumber}, Number:{Number},Permissible Load:{PermissibleLoad}";
        }
    }
}
