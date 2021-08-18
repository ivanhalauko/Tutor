using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03_Book
{
    class Author
    {
        private string _text;

        public Author(string text)
        {
            _text = text;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_text);
            Console.ResetColor();
        }
    }
}
