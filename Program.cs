using ConsoleApp12;

namespace LibraryManagment
{
    class Programm
    {
        static Library library = new Library();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case (int)MenuOptions.ShowAllBooks:
                        ShowAllBooks();
                        break;
                    case (int)MenuOptions.AddBook:
                        AddBook();
                        break;
                    case (int)MenuOptions.ReserveBook:
                        ReserveBook();
                        break;
                    case (int)MenuOptions.ReturnBook:
                        ReturnBook();
                        break;
                    case (int)MenuOptions.FindBook:
                        FindBook();
                        break;
                    case (int)MenuOptions.DeleteBook:
                        DeleteBook();
                        break;
                }
                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Отобразить все книги.");
            Console.WriteLine("2. Добавить книгу.");
            Console.WriteLine("3. Забронировать книгу.");
            Console.WriteLine("4. Вернуть книгу.");
            Console.WriteLine("5. Найти книгу по имени.");
            Console.WriteLine("6. Удалить книгу.");
        }
        static int GetUserChoice()
        {
            Console.Write("\nВаш доступный выбор: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Повторите попытку.");
                Console.Write("\nВаш доступный выбор: ");
            }

            return choice;
        }
        static string PromptUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static Book GetBookFromUserInput(string message)
        {
            string inputTitle = PromptUser(message);
            var book = library.FindBook(inputTitle);

            if (book == null)
            {
                Console.WriteLine("Данной книги нет в библиотеке.");
            }

            return book;
        }
        static void ShowAllBooks()
        {
            List<Book> books = library.GetAllBooks();

            if (books.Count > 0)
            {
                Console.WriteLine("Все книги в библиотеке: ");

                foreach (Book book in books)
                {
                    string status = book.IsCheckedOut ? "Забронировано" : "Доступно";
                    Console.WriteLine($"- {book.Author}, {book.Title} ({status})");
                }
            }
            else
            {
                Console.WriteLine("В библиотеке нет доступных книг.");
            }
        }
        static void AddBook()
        {
            string inputAuthor = PromptUser("Введите автора: ");
            string inputTitle = PromptUser("Введите название книги: ");

            Book newBook = new Book(inputTitle, inputAuthor);

            library.AddBook(newBook);

            Console.WriteLine($"{newBook.Title} - Добавлена в вашу библиотеку.");
        }

        static void ReserveBook()
        {
            var reserveBook = GetBookFromUserInput("Введите название книги: ");
            reserveBook?.Return();
        }
        static void ReturnBook()
        {
            var returnBook = GetBookFromUserInput("Введите название книги: ");
            returnBook?.Return();
        }

        static void FindBook()
        {
            var book = GetBookFromUserInput("Введите название книги: ");

            if (book != null)
            {
                string status = book.IsCheckedOut ? "Забронировано" : "Доступно";
                Console.WriteLine($"- {book.Author}, {book.Title} ({status})");
            }
        }
        static void DeleteBook()
        {
            var bookToDelete = GetBookFromUserInput("Введите название книги: ");

            if (bookToDelete != null)
            {
                library.DeleteBook(bookToDelete);
            }
        }
        enum MenuOptions
        {
            ShowAllBooks = 1,
            AddBook,
            ReserveBook,
            ReturnBook,
            FindBook,
            DeleteBook
        }
    }
}