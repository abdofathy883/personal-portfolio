using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminDashboard.Data;
using AdminDashboard.Models;

namespace AdminDashboard.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly AdminDashboard.Data.ApplicationDbContext _context;

        public IndexModel(AdminDashboard.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Project = await _context.Projects
                .Include(p => p.Category).ToListAsync();
        }
    }
}
