using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task3;
using System.IO;

namespace Task7_Collections
{
    class SerializTruck
    {
        public void Serialize(Truck truck)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Truck));
            using (FileStream fs = new FileStream("Truck.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, truck);
            }
        }

        public Truck Deserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Truck));
            Truck truck = null;
            using (FileStream fs = new FileStream("Truck.xml", FileMode.OpenOrCreate))
            {
                truck = xmlSerializer.Deserialize(fs) as Truck;
            }

            return truck;
        }
    }
}
