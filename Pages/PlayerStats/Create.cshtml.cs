using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Downloads.Data;

namespace Downloads.Pages_PlayerStats
{
    public class CreateModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public CreateModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlayerStats PlayerStats { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlayerStats.Add(PlayerStats);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/AdminPlayer");
        }
    }
}
