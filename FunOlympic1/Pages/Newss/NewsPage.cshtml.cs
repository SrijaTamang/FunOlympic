using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FunOlympic1;
using FunOlympic1.Data;

namespace FunOlympic1.Pages.Newss
{
    public class NewsPageModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public NewsPageModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<News> News { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.News != null)
            {
                News = await _context.News.ToListAsync();
            }
        }
    }
}
