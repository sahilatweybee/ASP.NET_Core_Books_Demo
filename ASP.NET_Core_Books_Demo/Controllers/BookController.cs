using ASP.NET_Core_Books_Demo.Models;
using ASP.NET_Core_Books_Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Books_Demo.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepo _bookRepo = null;

        public BookController()
        {
            _bookRepo = new BookRepo();
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public ViewResult GetAllBooks()
        {
            var data = _bookRepo.GetAllBooks();

            return View(data);
        }

        public BookModel GetBook(int id)
        {
            return _bookRepo.GetBookById(id); 
        }

        public List<BookModel> SearchBooks(string bookname, string Author)
        {
            return _bookRepo.SearchBooks(bookname, Author);
        }
    }
}
