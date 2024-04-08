using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FunOlympic1
{
    [Authorize]
    public class LiveVideoModel : PageModel
    {
        private readonly ILogger<LiveVideoModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public List<SelectListItem> Users { get; set; }
        [BindProperty]
        public string MyUser { get; set; }
        public LiveVideoModel(ILogger<LiveVideoModel> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        public void OnGet()
        {
            //get all the users from the database
            Users = _userManager.Users.ToList()
                .Select(a => new SelectListItem { Text = a.UserName, Value = a.UserName })
                .OrderBy(s => s.Text).ToList();
            //get logged in user name


            MyUser = User.Identity.Name;
        }
    }
}
