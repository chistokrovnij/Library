using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }

        public Book(string title, string author)
        {
            Title = title; 
            Author = author; 
            IsCheckedOut = false;
        }

        public void CheckedOut()
        {
            if (IsCheckedOut)
            {
                Console.WriteLine($"Книга \"{Title}\" уже забронирована!");
            }
            else
            {
                IsCheckedOut = true;
                Console.WriteLine($"Вы забронировали книгу \"{Title}\"");
            }
        }

        public void Return()
        {
            if (IsCheckedOut)
            {
                IsCheckedOut = false;
                Console.WriteLine($"Вы вернули книгу под названием \"{Title}\" обратно в библиотеку.");
            }
            else
            {
                Console.WriteLine($"Книга не была забронирована.");
            }
        }
    }
}
