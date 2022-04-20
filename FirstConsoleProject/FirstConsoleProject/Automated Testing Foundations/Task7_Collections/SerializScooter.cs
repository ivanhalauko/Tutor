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
    class SerializScooter
    {
        public void Serialize(Scooter scooter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scooter));
            using (FileStream fs = new FileStream("Scooter.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, scooter);
            }
        }

        public Scooter Deserialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Scooter));
            Scooter scooter = null;
            using (FileStream fs = new FileStream("Scooter.xml", FileMode.OpenOrCreate))
            {
                scooter = xmlSerializer.Deserialize(fs) as Scooter;
            }

            return scooter;
        }
    }
}
