using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Bookish.DataAccess
{
    public class SqlAccesser
    {
        public static List<Book> GetAllBooks()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnectionString"].ConnectionString);
            string sqlString = "SELECT TOP 100 [BookId],[Author],[Title],[ISBN] FROM [Books]";
            var bookList = db.Query<Book>(sqlString).ToList();
            return bookList;
        }

        public static List<Book> GetYourBooks(string userid)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnectionString"].ConnectionString);
            string sqlString1 = "SELECT * FROM TABLE WHERE ID IS "+ userid +" [BookId],[Author],[Title],[ISBN] FROM [Books]";
            var bookIdList = db.Query<Book>(sqlString1).ToList();

            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnectionString"].ConnectionString);
            string sqlString2 = "SELECT TOP 100 [BookId],[Author],[Title],[ISBN] FROM [Books]";
            var bookList = db.Query<Book>(sqlString2).ToList();
            return bookList;
        }

        public void AddBookToLibrary(string author, string title, string ISBN)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnectionString"].ConnectionString);
            db.Open();
            var book = new Book();
            book.Title = title;
            book.Author = author;
            book.ISBN = ISBN;
            string processQuery = "INSERT INTO BOOKS VALUES (@A, @B)";
            db.Execute(processQuery, book);
        }
    }
}