using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoEFCore.Models;

namespace DemoPE.Web.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly DemoEFCore.Models.BookPublisherContext _context;

        public IndexModel(DemoEFCore.Models.BookPublisherContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Publisher).ToListAsync();
        }
    }
}
