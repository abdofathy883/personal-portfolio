using AdminDashboard.Data;
using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages.Projects
{
    public class AllModel : PageModel
    {
        private ApplicationDbContext context;
        public List<Project> Projects { get; set; } = new List<Project>();
        public AllModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Projects = context.Projects.ToList();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var deletedProject = await context.Projects.FindAsync(id);
            if(deletedProject != null)
            {
                context.Projects.Remove(deletedProject);
                await context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
