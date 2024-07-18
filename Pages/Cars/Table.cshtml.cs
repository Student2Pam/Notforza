using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Downloads.Data;

namespace Downloads.Pages_Cars
{
    public class IndexModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public IndexModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
