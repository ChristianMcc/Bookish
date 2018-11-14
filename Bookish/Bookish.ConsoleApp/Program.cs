using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookish.DataAccess;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookList = new List<Book>();
            bookList = SqlAccesser.GetAllBooks();

            foreach (var book in bookList)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nBook ID: " + book.BookId);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine("ISBN " + book.ISBN + "\n");
                Console.WriteLine(new string('*', 20));
            }

            Console.ReadLine();
        }
    }
}
