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
            int power = 3;
            string volume = "low";
            string type = "super car";
            int serialNumber = 52469;
            int wheelsNumber = 2;
            int number = 1;
            int permissibleLoad = 512;
            string typeTran = "super car";
            int numberOfGears = 6;
            string manufacturer = "Ferrari";
            PassengerCar passengerCar = new PassengerCar(typeTran, numberOfGears, manufacturer,
                power, volume, type, serialNumber,
                wheelsNumber, number, permissibleLoad);
            Console.WriteLine(passengerCar.ToString());

             typeTran ="Truck trans";
            numberOfGears = 10;
            manufacturer = "Volvo";
            power = 120;
            volume = "high";
            type = "Truck";
            serialNumber = 565469;
            wheelsNumber = 6;
            number = 4;
            permissibleLoad = 2390;
            Truck truck = new Truck(typeTran, numberOfGears, manufacturer,
                power, volume, type, serialNumber,
                wheelsNumber, number, permissibleLoad);
            Console.WriteLine(truck.ToString());

            typeTran = "Bus trans";
            numberOfGears = 7;
            manufacturer = "Volvo";
            power = 90;
            volume = "high";
            type = "Bus";
            serialNumber = 4524;
            wheelsNumber = 4;
            number = 2;
            permissibleLoad = 523;
            Bus bus = new Bus(typeTran, numberOfGears, manufacturer,
                power, volume, type, serialNumber,
                wheelsNumber, number, permissibleLoad);
            Console.WriteLine(bus.ToString());

            typeTran = "Scooter trans";
            numberOfGears = 2;
            manufacturer = "Minsk";
            power = 12;
            volume = "very low";
            type = "Scooter";
            serialNumber = 542;
            wheelsNumber = 2;
            number = 3;
            permissibleLoad = 12;
            Scooter scooter = new Scooter(typeTran, numberOfGears, manufacturer,
                power, volume, type, serialNumber,
                wheelsNumber, number, permissibleLoad);
            Console.WriteLine(scooter.ToString());
        }
    }
}
