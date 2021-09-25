using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int TotalPages { get; set; }
        public int LanguageId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Language language { get; set; }
        public string CoverImagePath { get; set; }
        public ICollection<Gallery> Images { get; set; }
        public string PdfUrl { get; set; }

    }
}
