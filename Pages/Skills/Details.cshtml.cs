using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminDashboard.Data;
using AdminDashboard.Models;

namespace AdminDashboard.Pages.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly AdminDashboard.Data.ApplicationDbContext _context;

        public DetailsModel(AdminDashboard.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Skill Skill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            else
            {
                Skill = skill;
            }
            return Page();
        }
    }
}
