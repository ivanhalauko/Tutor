using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task7_Collections
{
    [Serializable]
    public class CarParking
    {
        public List<Vehicle> CarParkingCollection { get; set; }
            
        public CarParking()
        {
            CarParkingCollection = InitialaizeCarParkingList(); 
        }

        private List<Vehicle> InitialaizeCarParkingList()
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

            typeTran = "Truck trans";
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

            List<Vehicle> carParkingCollection = new List<Vehicle>();
            carParkingCollection.Add(bus);
            carParkingCollection.Add(scooter);
            //carParkingCollection.Add(truck);
            //carParkingCollection.Add(passengerCar);
            return carParkingCollection;
        }

    }
}
