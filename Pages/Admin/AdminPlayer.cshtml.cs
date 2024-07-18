using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Downloads.Data;
using Microsoft.AspNetCore.Authorization;


namespace Downloads.Pages_PlayerStats
{


    [Authorize(Roles = "Admin")]
    public class AdminPlayerModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public AdminPlayerModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        public IList<PlayerStats> PlayerStats { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PlayerStats = await _context.PlayerStats.ToListAsync();
        }
    }
}
