using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Library
    {
        public List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книга \"{book.Title}\" добавлена.");
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
            Console.WriteLine($"Книга \"{book.Title}\" удалена.");
        }

        public Book FindBook(string title)
        {
            return books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}