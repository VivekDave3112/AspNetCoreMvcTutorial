using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
           return  await _context.Languages.Select(x => new LanguageModel
                        {
                            Id = x.Id,
                            Description = x.Description,
                            Name = x.Name
                        }).ToListAsync();
        }
    }
}
