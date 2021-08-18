using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03_Book
{
    class Title
    {

        private string _text;

        public Title(string text)
        {
            _text = text;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(_text);
            Console.ResetColor();
        }
    }
}
