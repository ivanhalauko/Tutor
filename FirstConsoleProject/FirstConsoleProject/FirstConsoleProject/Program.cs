using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //кастинг типов переменных
            int a = 10;
            double b = 254736532095836755;
            //b = a; //не явное преобразорвание
            //a = b;
            a = (int)b;//явное преобразование
            Console.WriteLine(a);
        }
    }
}
