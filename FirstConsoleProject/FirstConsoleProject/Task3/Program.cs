using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a program which manages a car park. For this purpose, need
//to implement the next entities as separate classes: "Engine"
//(includes the next fields: power, volume, type, serial number),
//"Chassis" (wheels number, number, permissible load),
//"Transmission" (type, number of gears, manufacturer).

//Implement entities "Passenger car", "Truck", "Bus", "Scooter"
//using class described previously(distinguished by unique fields)
//and provide the output of complete information about objects of these types.

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = 0;
            string volume = "low";
            string type = "super car";
            int serialNumber = 52469;
            Engine engine = new Engine(power, volume, type, serialNumber);
            Console.WriteLine(Convert.ToString(engine.power) + ',' +
                volume + ',' + type + ',' +
                Convert.ToString(engine.serialNumber));
            int wheelsNumber = 2;
            int number = 1;
            int permissibleLoad = 512;
            Chassis chassis = new Chassis(wheelsNumber, number, permissibleLoad);
            Console.WriteLine(Convert.ToString(chassis.wheelsNumber) 
                + ',' + Convert.ToString(chassis.number) + ','+ Convert.ToString(chassis.permissibleLoad));
            string typeTran = "super car";
            int numberOfGears = 6;
            string manufacturer = "Ferrari";
            Transmission transmission = new Transmission(typeTran, numberOfGears, manufacturer);
            Console.WriteLine(typeTran + ',' + Convert.ToString(transmission.numberOfGears) + ',' + manufacturer);
        }
    }
}
