using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImagePath = model.CoverImagePath,
                PdfUrl = model.PdfUrl
            };

            newBook.Images = new List<Gallery>();

            foreach(var img in model.Gallery)
            {
                newBook.Images.Add(new Gallery()
                {
                   Name = img.Name,
                   URL = img.URL
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            List<BookModel> bookModels = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if(allBooks.Any())
            {
                foreach(var book in allBooks)
                {

                    bookModels.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        CoverImagePath = book.CoverImagePath,
                        Gallery = book.Images.Select(g => new GalleryModel()
                        {
                            Id = g.Id,
                            Name = g.Name,
                            URL = g.URL
                        }).ToList()
                    });
                }

            }
            return bookModels;
        }

        public async Task<IEnumerable<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Title = book.Title,
                TotalPages = book.TotalPages,
                Id = book.Id,
                LanguageId = book.LanguageId,
                CoverImagePath = book.CoverImagePath,
            }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id ).Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.language.Name,
                    CoverImagePath = book.CoverImagePath,
                    Gallery = book.Images.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    PdfUrl = book.PdfUrl
            }).FirstOrDefaultAsync();
        }

        public  List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

    }
}
