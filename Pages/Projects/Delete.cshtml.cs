﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly AdminDashboard.Data.ApplicationDbContext _context;

        public DeleteModel(AdminDashboard.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ID == id);

            if (project == null)
            {
                return NotFound();
            }
            else
            {
                Project = project;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                Project = project;
                _context.Projects.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
