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
    }
}