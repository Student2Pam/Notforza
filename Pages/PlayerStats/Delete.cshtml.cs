using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Downloads.Data;

namespace Downloads.Pages_PlayerStats
{
    public class DeleteModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public DeleteModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlayerStats PlayerStats { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerstats = await _context.PlayerStats.FirstOrDefaultAsync(m => m.PlayerID == id);

            if (playerstats == null)
            {
                return NotFound();
            }
            else
            {
                PlayerStats = playerstats;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerstats = await _context.PlayerStats.FindAsync(id);
            if (playerstats != null)
            {
                PlayerStats = playerstats;
                _context.PlayerStats.Remove(PlayerStats);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/AdminPlayer");
        }
    }
}
