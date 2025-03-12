using AdminDashboard.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages.Users
{
    public class AllModel : PageModel
    {
        public List<IdentityUser> Users = new List<IdentityUser>();
        private ApplicationDbContext context;
        public AllModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Users = context.Users.ToList();
        }
    }
}
