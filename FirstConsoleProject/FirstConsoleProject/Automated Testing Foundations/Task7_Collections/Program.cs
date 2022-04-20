using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;
//Заполнить единую коллекцию, содержащую предметы типа "Грузовик", "Легковой автомобиль", "Автобус",
//    "Скутер" (из предыдущей задачи ООП) с различными значениями поля.. Запишите следующую информацию в соответствующие XML файлы:.
//    Вся информация о всех транспортных средствах, мощность двигателя которых составляет более 1,5 литра;. 
//Тип двигателя, серийный номер и номинальная мощность для всех автобусов и грузовиков;. 
//Вся информация обо всех транспортных средствах, сгруппирована по типу передачи. 


namespace Task7_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            CarParking carParking = new CarParking();
            List<Vehicle> list = carParking.CarParkingCollection;
            IEnumerable<object> enumerableList = list.AsEnumerable<object>();

            //XmlSerializatorPassangerCar xmlSerializatorPassangerCar = new XmlSerializatorPassangerCar();
            //PassengerCar passengerCar1= null;
            //foreach (var item in list)
            //{
            //    if (item is PassengerCar)
            //    {
            //        passengerCar1 = (PassengerCar)item;
            //    }
            //}
            //xmlSerializatorPassangerCar.Serialize(passengerCar1);
            //PassengerCar passengerCar2 = null;
            //passengerCar2 = xmlSerializatorPassangerCar.Deserialize();

            //SerializBus serializBus = new SerializBus();
            //Bus bus1 = null;
            //foreach (var item in list )
            //{
            //    if (item is Bus)
            //    {
            //        bus1 = (Bus)item;
            //    }
            //}
            //serializBus.Serialize(bus1);
            //Bus bus2 = null;
            //bus2 = serializBus.Deserialize();

            //SerializTruck serializTruck = new SerializTruck();
            //Truck truck1 = null;
            //foreach (var item in list)
            //{
            //    if (item is Truck)
            //    {
            //        truck1 = (Truck)item;
            //    }
            //}
            //serializTruck.Serialize(truck1);
            //Truck truck2= null;
            //truck2 = serializTruck.Deserialize();

            //SerializScooter serializScooter = new SerializScooter();
            //Scooter scooter1 = null;
            //foreach (var item in list)
            //{
            //    if (item is Scooter)
            //    {
            //        scooter1 = (Scooter)item;
            //    }
            //}
            //serializScooter.Serialize(scooter1);
            //Scooter scooter2 = null;
            //scooter2 = serializScooter.Deserialize();

            Serialaizer serialaizer = new Serialaizer();
            serialaizer.Serialaize<List<Vehicle>>(list);
        }
    }
}
