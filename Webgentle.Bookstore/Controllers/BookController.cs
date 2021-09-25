using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookrepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
             _bookrepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult>  GetAllBooks()
        {
            Title = "Books";

            var data =await  _bookrepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            
            var data = await _bookrepository.GetBookById(id);

            return View(data);
        }

        public List<BookModel> FindBooks(string bookName, string authName)
        {
            return _bookrepository.SearchBook(bookName, authName);
        }

        public async Task<ViewResult> AddNewBookAsync(bool isSuccess = false, int bookId = 0)
        {

            var model = new BookModel();

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImagePath = await UploadFile(bookModel.CoverPhoto, folder);
                }

                if(bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();
                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadFile(file, folder)
                        };

                        bookModel.Gallery.Add(gallery);
                    }

                    
                }

                if (bookModel.PdfFile != null)
                {
                    string folder = "books/pdffile/";
                    bookModel.PdfUrl = await UploadFile(bookModel.PdfFile, folder);
                }

                int id = await _bookrepository.AddNewBook(bookModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }

                

            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");





            return View();

        }

        private async Task<string> UploadFile(IFormFile image, string folder)
        {
            folder += Guid.NewGuid().ToString() + "_" + image.FileName;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

            string imagePath = "/" + folder;

            await image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return imagePath;
        }

        private async Task<List<LanguageModel>> GetLanguages()
        {
            return await _languageRepository.GetLanguages();
        }
    }
}
