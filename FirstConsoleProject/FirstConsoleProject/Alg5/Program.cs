using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg5
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "Serj";
            string password = "Password";
            Console.Write("Введите ваш login: ");
            string usersLogin = Console.ReadLine();
            if(login==usersLogin)//можно ли писать usersLogin==login
            {
                Console.Write("Введите ваш пароль:");
                string usersPassword = Console.ReadLine();
                if (password==usersPassword)
                {
                    Console.WriteLine("Приветсвую вас повелитель {0},вы вошли в систему.",usersLogin);
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный пароль,повторите попытку!");
                }
            }
            else
            {
                Console.WriteLine("Нет пользователя с таким именем!");
            }
            Console.ReadKey();
        }
    }
}
