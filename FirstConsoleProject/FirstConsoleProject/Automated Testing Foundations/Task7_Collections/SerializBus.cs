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
    class SerializBus
    {
        public void Serialize(Bus bus)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bus));
            using (FileStream fs = new FileStream("Bus.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, bus);
            }
        }

        public Bus Deserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bus));
            Bus bus= null;
            using (FileStream fs = new FileStream("Bus.xml", FileMode.OpenOrCreate))
            {
                bus = xmlSerializer.Deserialize(fs) as Bus;
            }

            return bus;
        }
    }
}
