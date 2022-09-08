using ASPNET_Core_Books_Demo.Data;
using ASPNET_Core_Books_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Repository
{
    public class LanguageRepo
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepo(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language_Tbl.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
        }

    }
}
