using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FunOlympic1;
using FunOlympic1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FunOlympic1.Pages.Comments
{
    public class CreateModel : PageModel
    {
        private readonly FunOlympic1.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(FunOlympic1.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        [BindProperty]
        public int videoId { get; set; }
  

        public IActionResult OnGet(int? videoId)
        {
           
            //var video = _context.Videos.FirstOrDefault(v => v.VideoID == videoId);
            Video VideoUpload = _context.Videos
            .Include(v => v.Comments)
               .ThenInclude(c => c.User)
            .FirstOrDefault(m => m.VideoID == videoId);

            // ViewData["Comments"] = VideoUpload.Comments.ToList();
            ViewData["Comments"] = VideoUpload.Comments.OrderByDescending(c => c.CreatedAt).ToList();

            ViewData["VideoLink"] = VideoUpload.VideoLink;

            ViewData["VideoUploadId"] = videoId;

          //  ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
       // ViewData["VideoUploadId"] = new SelectList(_context.Videos, "VideoID", "Category");
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Comments == null || Comment == null)
          //  {
          //      return Page();
          //  }
          Comment.CreatedAt=DateTime.Now;

          Comment.UserId= _userManager.GetUserId(User);
            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create", new { videoId = Comment.VideoUploadId });
            // return RedirectToPage("./Index");
        }
    }
}
