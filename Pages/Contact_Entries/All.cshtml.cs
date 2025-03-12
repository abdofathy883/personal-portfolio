using AdminDashboard.Data;
using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages.Contact_Entries
{
    public class AllModel : PageModel
    {
        private ApplicationDbContext context;
        public List<ContactForm> ContactEntries { get; set; }
        public AllModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            ContactEntries = context.ContactForms.ToList();
        }
        public IActionResult OnPost()
        {
            foreach (var entry in ContactEntries)
            {
                var ExistingEntry = ContactEntries.FirstOrDefault(c => c.Id == entry.Id);
                if (ExistingEntry != null)
                {
                    ExistingEntry.Status = entry.Status;
                    context.SaveChanges();
                }
            }
            return RedirectToPage();
        }
    }
}
