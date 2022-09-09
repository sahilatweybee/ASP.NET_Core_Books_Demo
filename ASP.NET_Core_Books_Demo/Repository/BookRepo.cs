using ASPNET_Core_Books_Demo.Data;
using ASPNET_Core_Books_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_Core_Books_Demo.Repository
{
    public class BookRepo : IBookRepository
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
                TotalPages = model.TotalPages ?? 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImgPathUrl = model.CoverImgUrl,
                BookPdfUrl = model.BookPdfUrl
            };
            newBook.Book_Gallery = new List<BookGallery>();
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
                CoverImgUrl = x.CoverImgPathUrl,
                BookPdfUrl = x.BookPdfUrl
            }).ToListAsync();

            return books;
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
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
                CoverImgUrl = x.CoverImgPathUrl,
                BookPdfUrl = x.BookPdfUrl
            }).Take(count).ToListAsync();

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
                    Description = book.Description,
                    Category = book.Category,
                    Id = book.Id,
                    Language = book.Language.Name,
                    LanguageId = book.LanguageId,
                    TotalPages = book.TotalPages,
                    CoverImgUrl = book.CoverImgPathUrl,
                    Gallery = book.Book_Gallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBooks(string tital, string authorName)
        {
            return null;
        }
    }
}
