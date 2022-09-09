using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ASPNET_Core_Books_Demo.Helpers;
using Microsoft.AspNetCore.Http;

namespace ASPNET_Core_Books_Demo.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "* Name of The Book must be atleast 3 Characters Long")]
        [Required(ErrorMessage = "* Book Name is Required!")]
        //[MyCustomValidationAttribute("asd")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "* Name of the Author Must be Atleast 3 Characters Long")]
        [Required(ErrorMessage = "* Author Name is Required!")]
        public string Author { get; set; }
        [StringLength(200, MinimumLength = 15, ErrorMessage = "* Description must be between 15 and 200 Characters")]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "* language of the book can't be null")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "* Invalid Number of pages!")]
        [Display(Name = "Total Pages of the Book")]
        public int? TotalPages { get; set; }
        [Display(Name="Cover Photo of the Book")]
        [Required(ErrorMessage ="* Cover Photo is Required and must be under __kb Size")]
        public IFormFile CoverImg { get; set; }
        public List<IFormFile> GalleryFiles { get; set; }
        public string CoverImgUrl { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Upload Book in PDF format")]
        [Required(ErrorMessage ="* Pdf File is Required")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
