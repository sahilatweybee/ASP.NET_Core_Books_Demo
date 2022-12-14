using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CoverImgPathUrl { get; set; }
        public Language Language { get; set; }
        public ICollection<BookGallery> Book_Gallery { get; set; } 
        public string BookPdfUrl { get; set; }
    }
}
