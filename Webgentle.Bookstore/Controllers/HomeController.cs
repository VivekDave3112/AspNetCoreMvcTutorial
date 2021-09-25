using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel book1 { get; set; }

        public ViewResult Index()
        {
            Title = "Home";

            book1 = new BookModel() { Id = 10, Title = "hello", Author = "Vivek", Category = "Nothing" };
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "AboutUs";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "ContactUs";

            return View();
        }
    }
}
