using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03_Book
{
    class Content
    {
        private string _text;

        public Content(string text)
        {
            _text = text;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_text);
            Console.ResetColor();
        }
    }
}
