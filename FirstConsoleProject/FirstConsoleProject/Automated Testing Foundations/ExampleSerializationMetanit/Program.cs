using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExampleSerializationMetanit
{
    class Program
    {
        static void Main(string[] args)
        {
            //// объект для сериализации
            //Person person = new Person("Tom", 37);

            // передаем в конструктор тип класса Person
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            // получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(fs, person);

            //    Console.WriteLine("Object has been serialized");
            //}

            // десериализуем объект
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                Person person1 = xmlSerializer.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {person1?.Name}  Age: {person1?.Age}");
            }
        }
    }
}
