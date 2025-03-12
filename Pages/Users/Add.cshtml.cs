using AdminDashboard.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages.Users
{
    public class AddModel : PageModel
    {
        private UserManager<IdentityUser> User;
        //public List<Iden>
        public AddModel(UserManager<IdentityUser> User)
        {
            this.User = User;
        }
        public void OnGet()
        {

        }
    }
}
