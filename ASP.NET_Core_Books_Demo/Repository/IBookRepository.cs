using ASPNET_Core_Books_Demo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Repository
{
    public interface IBookRepository
    {
        Task<int> addNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int Id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBooks(string tital, string authorName);
    }
}