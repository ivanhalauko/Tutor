using Constructors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Animal();
            //dog.quantityLegs = 2;
            //dog.quantityTail = 1;

            int _quanitityLeg=-2;
            int _quantityTail = 1;
            Animal gog = new Animal(quantityLegs: _quanitityLeg, quantityTail: _quantityTail);  //явное задание параметров внутри конструктора!!!!!!!!
            Console.WriteLine(Convert.ToString(gog.QuantityLegs) + ' ' + Convert.ToString(gog.QuantityTail));
        }
        
    }

}
