using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Downloads.Data;

namespace Downloads.Pages_PlayerStats
{
    public class EditModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public EditModel(Downloads.Data.NotForzaContext context)
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

            var playerstats =  await _context.PlayerStats.FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerstats == null)
            {
                return NotFound();
            }
            PlayerStats = playerstats;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlayerStats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStatsExists(PlayerStats.PlayerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Admin/AdminPlayer");
        }

        private bool PlayerStatsExists(int id)
        {
            return _context.PlayerStats.Any(e => e.PlayerID == id);
        }
    }
}
