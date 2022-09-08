using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            :base(options)
        {

        }

        public DbSet<Books> Book_Tbl { get; set; }
        public DbSet<Language> Language_Tbl { get; set; }
        public DbSet<BookGallery> Gallery_Tbl { get; set; }
    }
}
