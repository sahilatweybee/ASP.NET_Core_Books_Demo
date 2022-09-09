using ASPNET_Core_Books_Demo.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepo;
        public TopBooksViewComponent(IBookRepository repo)
        {
            this._bookRepo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books = await _bookRepo.GetTopBooksAsync(count);
            return View(books);
        }
    }
}
