using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessColor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Угадайте задуманный цвет с пяти попыток.");
            Console.WriteLine("Для выхода из программы введи - exit.");
            const int maxAttempt = 5;//количество попыток
            int attempt = 0;//счетчик попыток
            string color = "red";
            while (attempt < maxAttempt)
            {
                attempt++;
                Console.WriteLine("Попытка {0}:", attempt);
                string value = Console.ReadLine();
                if (value == "exit")
                {
                    break;
                }
                if (value != color)
                {
                    continue;
                }
                Console.WriteLine("Поздравляем,Вы угадали с {0} попытки", attempt);
                break;
            }
            Console.WriteLine("Конец игры");
        }
        
    }
}
