using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Enums;
using Webgentle.Bookstore.Helpers;

namespace Webgentle.Bookstore.Models
{
    public class BookModel
    {
        

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title")]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter the name of the Author")]
        public string Author { get; set; }

        [StringLength(250, ErrorMessage = "Description can not have more length than 250 characters.")]
        public string Description { get; set; }
        public string Category { get; set; }
       
        [Required(ErrorMessage = "Please enter Total Number of Pages")]
        [Display(Name = "Total Number of Pages")]
        public int? TotalPages { get; set; }

        [Required(ErrorMessage = "Please choose a language")]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Please choose your languages")]
        public LanguageEnum LanguageEnum  { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set;}
        public string CoverImagePath { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        public int MyProperty { get; set; }

        [Display(Name = "Choose the pdf file of your book")]
        public IFormFile PdfFile { get; set; }
        public string PdfUrl { get; set; }

    }
}
