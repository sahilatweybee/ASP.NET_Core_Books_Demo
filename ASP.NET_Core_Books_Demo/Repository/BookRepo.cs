using ASPNET_Core_Books_Demo.Data;
using ASPNET_Core_Books_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Core_Books_Demo.Repository
{
    public class BookRepo
    {
        private readonly BookStoreContext _context = null;
        public BookRepo(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> addNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Name = model.Name,
                LanguageId = model.LanguageId,
                CoverImgPathUrl =model.CoverImgUrl,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            foreach (var file in model.Gallery)
            {
                newBook.Book_Gallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }
            await _context.Book_Tbl.AddAsync(newBook);
            await _context.SaveChangesAsync();
            
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            // var data = new List<BookModel>();
            var books = await _context.Book_Tbl.Select(x => new BookModel()
            {
                Author = x.Author,
                Name = x.Name,
                Description = x.Description,
                Category = x.Category,
                Id = x.Id,
                Language = x.Language.Name,
                LanguageId = x.LanguageId,
                TotalPages = x.TotalPages,
                CoverImgUrl = x.CoverImgPathUrl
            }).ToListAsync();

            return books;
        }

        public async Task<BookModel> GetBookById(int Id)
        {
            // await _context.Book_Tbl.Where(x => x.Id == Id).FirstOrDefault();
            return await _context.Book_Tbl.Where(x => x.Id == Id)
                .Select(book => new BookModel()
                {
                Author = book.Author,
                Name = book.Name,
                CoverImgUrl = book.CoverImgPathUrl,
                Description = book.Description,
                Category = book.Category,
                Id = book.Id,
                Language = book.Language.Name,
                LanguageId = book.LanguageId,
                TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBooks(string tital, string authorName)
        {
            return null;
        }
    }
}
