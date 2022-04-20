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
    public class Serialaizer
    {
        public void Serialaize<T>(T entities) where T : List<Vehicle>
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream("CarsList.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, entities);
            }
        }
    }
}
