using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            string textTitle = "monkeys";
            Title title = new Title(textTitle);
            string textAuthor = "Charli";
            Author author = new Author(textAuthor);
            string textContent = "glnskb";
            Content content = new Content(textContent);
            Book book = new Book(title,author,content);
            //Console.WriteLine("Enter title");
            //Console.WriteLine("Enter Author");
            //Console.WriteLine("Enter Content");
            book.ShowTitle();
            book.ShowAuthor();
            book.ShowContent();
        }
    }
    class Book
    {
        Title _title;
        Author _author;
        Content _content;

        public Book(Title title, Author author, Content content)
        {
            _title = title;
            _author = author;
            _content = content;
        }
        public void AddTitle(string text)
        {
            _title = new Title(text);
        }
        public void AddAuthor(string text)
        {
            _author = new Author(text);
        }
        public void AddContent(string text)
        {
            _content = new Content(text);
        }
        public void ShowTitle()
        {
            _title.Show();
        }
        public void ShowAuthor()
        {
            _author.Show();
        }
        public void ShowContent()
        {
            _content.Show();
        }
    }
}
