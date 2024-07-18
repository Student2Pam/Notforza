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
    public class DeleteModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public DeleteModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FirstOrDefaultAsync(m => m.CarID == id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                Car = car;
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/AdminCar");
        }
    }
}
