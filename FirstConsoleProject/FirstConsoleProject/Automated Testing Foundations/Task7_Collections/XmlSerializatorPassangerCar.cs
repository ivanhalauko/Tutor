using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task3;

namespace Task7_Collections
{
    public class XmlSerializatorPassangerCar
    {
        public void Serialize(PassengerCar passengerCar)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PassengerCar));
            using (FileStream fs = new FileStream("passangerCar.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, passengerCar);
            }
        }

        public PassengerCar Deserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PassengerCar));
            PassengerCar passengerCar = null;
            using (FileStream fs = new FileStream("passangerCar.xml", FileMode.OpenOrCreate))
            {
                passengerCar = xmlSerializer.Deserialize(fs) as PassengerCar;
            }

            return passengerCar;
        }
    }
}
