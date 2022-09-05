using ASP.NET_Core_Books_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Books_Demo.Repository
{
    public class BookRepo
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string tital, string authorName)
        {
            return DataSource().Where(x => x.Name.Contains(tital) && x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){id=1, Name="C#", Author="abc"},
                new BookModel(){id=2, Name="JAVA", Author="xzy"},
                new BookModel(){id=3, Name="PYTHON", Author="pqr"},
                new BookModel(){id=4, Name="PHP", Author="abc"},
                new BookModel(){id=1, Name="C++", Author="xyz"},
            };
        }
    }
}
