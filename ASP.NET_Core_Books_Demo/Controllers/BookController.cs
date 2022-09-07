using ASPNET_Core_Books_Demo.Models;
using ASPNET_Core_Books_Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepo _bookRepo = null;
        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepo bookrepo)
        {
            _bookRepo = bookrepo;
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            var data = await _bookRepo.GetAllBooks();

            return View(data);
        }
        [Route("book-details/", Name= "BookDetailsRoute")]
        public async Task<ViewResult> GetBook(int Id)
        {
            var book = await _bookRepo.GetBookById(Id);
            Title = book.Name + " Book Details";
            return View(book);
        }

        public List<BookModel> SearchBooks(string bookname, string Author)
        {
            return _bookRepo.SearchBooks(bookname, Author);
        }

        public ViewResult AddNewBook(bool IsSuccess=false, int bookId = 0)
        {
            ViewBag.BookId = bookId;
            ViewBag.IsSuccess = IsSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModl) 
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepo.addNewBook(bookModl);
                if(id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { IsSuccess = true, bookId = id });
                }
            }
            //ViewBag.IsSuccess = false;
            return View();
        }
    }
}
