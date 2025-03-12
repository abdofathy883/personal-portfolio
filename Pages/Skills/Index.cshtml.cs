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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        private const int PageSize = 10;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync(int PageNumber = 1)
        {
            CurrentPage = PageNumber;
            var TotalRecords = await _context.Categories.CountAsync();
            TotalPages = (int)Math.Ceiling(TotalRecords / (double)PageSize);
            //Fetching
            Skill = await _context.Skills
                .OrderBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostAsyn(int id)
        {
            var deleteskill = await _context.Skills.FindAsync(id);
            if (deleteskill != null)
            {
                _context.Skills.Remove(deleteskill);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
