using AdminDashboard.Data;
using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private ApplicationDbContext context;
    public List<Project> Projects { get; set; }
    public List<Category> Categories { get; set; }
    public List<Skill> Skills { get; set; }
    public List<ContactForm> Entries { get; set; }



    public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public void OnGet()
    {
        Projects = context.Projects.ToList();
        Categories = context.Categories.ToList();
        Skills = context.Skills.ToList();
        Entries = context.ContactForms.ToList();
    }
}
