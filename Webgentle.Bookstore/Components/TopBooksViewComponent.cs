using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private BookRepository _bookRepository;

        public TopBooksViewComponent(BookRepository bookRepository )
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var data = await _bookRepository.GetTopBooksAsync(count);

            return View(data);
        }
    }
}
