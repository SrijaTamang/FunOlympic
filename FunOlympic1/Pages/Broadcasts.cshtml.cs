using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FunOlympic1.Pages
{
    [Authorize]
    public class BroadcastModel : PageModel
    {
        private readonly ILogger<BroadcastModel> _logger;
        private readonly FunOlympic1.Data.ApplicationDbContext _context;

        public BroadcastModel(FunOlympic1.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<Video> Video { get; set; } = default!;
       

        public void OnGet()
        {
            // IEnumerable<Video> videoList = _context.Videos.ToList();
            if (_context.Videos != null)
            {
                Video = _context.Videos.ToList();
            }

        }
    }
}