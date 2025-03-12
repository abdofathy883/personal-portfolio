using AdminDashboard.Data;
using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDashboard.Pages.Projects
{
    public class AddModel : PageModel
    {
        private ApplicationDbContext context;
        IWebHostEnvironment environment;
        [BindProperty]
        public ProjectDTO Project { get; set; } = new ProjectDTO();
        public List<Skill> skills { get; set; } = new List<Skill>();
        public List<Category> categories { get; set; } = new List<Category>();
        public AddModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public void OnGet()
        {
            skills = context.Skills.ToList();
            categories = context.Categories.ToList();
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    fileName += Path.GetExtension(Project.ImageURL.FileName);
                    string fullPath = Path.Combine(environment.WebRootPath + "ProjectsImages" + fileName);
                    using (var fileStream = System.IO.File.Create(fullPath))
                    {
                        Project.ImageURL.CopyTo(fileStream);
                    }
                    Project NewProject = new Project
                    {
                        Title = Project.Title,
                        Discription = Project.Discription,
                        URL = Project.URL,
                        //Bug
                        //Technologies = Project.Technologies != null ? string.Join(",", Project.Technologies) : "",
                        //Technologies = string.Join(",", Project.Technologies),
                        Technologies = Project.Technologies.ToString(),
                        //Technologies = Project.Technologies != null ? string.Join(",", Project.Technologies) : "",
                        CreatedAt = Project.CreatedAt,
                        ImageURL = fileName,
                        IsFeatured = Project.IsFeatured ?? false,
                        CategoryID = Project.CategoryID ?? 0
                    };
                    context.Projects.Add(NewProject);
                    context.SaveChanges();
                    Response.Redirect("/Projects/All");
                }
                catch 
                {
                    Response.Redirect("/Projects/Add");
                }
            }
        }
    }
}
