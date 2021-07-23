using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.ShowStudents();
            Console.WriteLine(new string('_',10));
            string name = "Vasya";
            student.AddStudent(name);
            student.ShowStudents();
        }
    }
    class Student
    {
        private string[] _studentsName=new string[5];
        public string Name { get; set; }
        public void ShowStudents()
        {
            int length =_studentsName.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(_studentsName[i]);
            }
            
        }
        public void AddStudent(string name)//Экземплярный метод
        {
            int i = 0;
            int length = _studentsName.Length;
            for ( i = 0; i < length; i++)
            {
                if (_studentsName[i]==null)
                {
                    break ;
                }

            }
            _studentsName[i] = name;
        }
    }
}
