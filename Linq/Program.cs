using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book(){Title = "ADO.NET Step by Step", Price = 5},
                new Book(){Title = "ASP.NET MVC", Price = 9.99f},
                new Book(){Title = "ADO.NET Web API", Price = 12},
                new Book(){Title = "C# Advanced Topics", Price = 7},
                new Book(){Title = "C# Advanced Topics", Price = 9}
            };
        }
    }

    public class Book
    {
        public float Price { get; set; }
        public string Title { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // Without LINQ
//            var cheapBooks = new List<Book>();
//            foreach (var book in books)
//            {
//                if (book.Price < 10)
//                    cheapBooks.Add(book);
//            }

            // LINQ query operators
            var cheaperBooks = from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // LINQ extension methods
            var cheapBooks = books
                            .Where(b => b.Price < 10)
                            .OrderBy(b => b.Title)
                            .Select(b => b.Title);

            foreach (var book in cheapBooks)
//                Console.WriteLine(book.Title + " " + book.Price);
                Console.WriteLine(book);

            var bookSingle = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
            var bookFirst = books.FirstOrDefault(b => b.Title == "C# Advanced Topics");
            var count = books.Count();
            var maxPrice = books.Max(b => b.Price);


            Console.WriteLine(bookSingle == null);
            Console.WriteLine(bookFirst.Title + " " + bookFirst.Price);
            Console.WriteLine(maxPrice);

            /*
            books.Where();
            books.Single();
            books.SingleOrDefault();

            books.First();
            books.FirstOrDefault();

            books.Last();
            books.LastOrDefault();

            books.Min();
            books.Max();
            books.Count();
            books.Sum();
            books.Average(b => b.Price);

            books.Skip(2).Take(3);
            */

        }
    }
}
