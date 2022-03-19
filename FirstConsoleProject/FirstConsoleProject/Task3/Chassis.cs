using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//"Chassis" (wheels number, number, permissible load)

namespace Task3
{
    class Chassis
    {
       public int wheelsNumber;
        public int number;
        public int permissibleLoad;
        public Chassis(int wheelsNumber, int number, int permissibleLoad)
        {
            this.wheelsNumber = wheelsNumber;
            this.number = number;
            this.permissibleLoad = permissibleLoad;
        }
    }
}
