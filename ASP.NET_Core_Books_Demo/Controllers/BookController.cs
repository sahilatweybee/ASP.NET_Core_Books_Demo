using ASPNET_Core_Books_Demo.Models;
using ASPNET_Core_Books_Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ASPNET_Core_Books_Demo.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepo _bookRepo = null;
        private readonly LanguageRepo _langRepo = null;
        private readonly IWebHostEnvironment _WebHostEnv = null;
        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepo bookrepo, 
            LanguageRepo languageRepo,
            IWebHostEnvironment WebHostEnv)
        {
            _bookRepo = bookrepo;
            _langRepo = languageRepo;
            _WebHostEnv = WebHostEnv;
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
            return null;
        }

        public async Task<ViewResult> AddNewBook(bool IsSuccess=false, int bookId = 0)
        {
            ViewBag.languages = new SelectList(await _langRepo.GetLanguages(), "Id", "Name");
            ViewBag.BookId = bookId;
            ViewBag.IsSuccess = IsSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModl) 
        {
            if (ModelState.IsValid)
            {
                if(bookModl.CoverImg != null)
                {
                    string folder = "Books/Covers/";
                    bookModl.CoverImgUrl =  await UploadImg(folder, bookModl.CoverImg);
                }
                if (bookModl.GalleryFiles != null)
                {
                    string folder = "Books/Gallery/";
                    bookModl.Gallery = new List<GalleryModel>();
                    foreach (var img in bookModl.GalleryFiles)
                    {
                        var galleryImg = new GalleryModel()
                        {
                            Name = img.FileName,
                            URL = await UploadImg(folder, img)
                        };
                        bookModl.Gallery.Add(galleryImg);
                    }
                }
                int id = await _bookRepo.addNewBook(bookModl);
                if(id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { IsSuccess = true, bookId = id });
                }
            }
            ViewBag.languages = new SelectList(await _langRepo.GetLanguages(), "Id", "Name");
            //ViewBag.IsSuccess = false;
            return View();
        }

        private async Task<string> UploadImg(string folderPath, IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_WebHostEnv.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
