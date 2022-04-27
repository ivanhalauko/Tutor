using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task7_Collections
{
    public class GenericSerializer<T>
    {
        public void Serialaize(T entities)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream("CarsList.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, entities);
            }
        }
    }
}
