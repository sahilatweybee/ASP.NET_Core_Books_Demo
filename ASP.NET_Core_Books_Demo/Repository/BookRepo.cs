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
                Language = model.Language,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.Book_Tbl.AddAsync(newBook);
            await _context.SaveChangesAsync();
            
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var data = new List<BookModel>();
            var allbooks = await _context.Book_Tbl.ToListAsync();
            if(allbooks?.Any() == true){
                foreach (var itm in allbooks)
                {
                    data.Add(new BookModel() { 
                        Author = itm.Author,
                        Name = itm.Name,
                        Description = itm.Description,
                        Category = itm.Category,
                        Id = itm.Id,
                        Language = itm.Language,
                        TotalPages = itm.TotalPages
                    });
                }
            }
            return data;
        }

        public async Task<BookModel> GetBookById(int Id)
        {
            // await _context.Book_Tbl.Where(x => x.Id == Id).FirstOrDefault();
            var book = await _context.Book_Tbl.FindAsync(Id);
            if (book != null)
            {
                var BookDetails = new BookModel()
                {
                    Author = book.Author,
                    Name = book.Name,
                    Description = book.Description,
                    Category = book.Category,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };
            return BookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBooks(string tital, string authorName)
        {
            return DataSource().Where(x => x.Name.Contains(tital) && x.Author.Contains(authorName)).ToList();
        }
        
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=3, Name="Python", Author="pqr", Description="Description of Python book.", Category="Programming", Language="Russian", TotalPages=839},
                new BookModel(){Id=4, Name="PHP", Author="abc", Description="Description of PHP book.", Category="Programming", Language="Spanish", TotalPages=790 },
                new BookModel(){Id=5, Name="C++", Author="xyz", Description="Description of C++ book.", Category="Programming", Language="French", TotalPages=1150},
                new BookModel(){Id=6, Name="AWS", Author="xyz", Description="Description of AWS book.", Category="Service", Language="English", TotalPages=303},
                new BookModel(){Id=7, Name="Go Language", Author="xyz", Description="Description of Go Language book.", Category="Programming", Language="German", TotalPages=209},
            };
        }
    }
}
