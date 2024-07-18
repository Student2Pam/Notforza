using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Downloads.Data;

namespace Downloads.Pages_PlayerStats
{
    public class ViewProfileModel : PageModel
    {
        private readonly Downloads.Data.NotForzaContext _context;

        public ViewProfileModel(Downloads.Data.NotForzaContext context)
        {
            _context = context;
        }

        
        public PlayerStats PlayerStats { get; set; } = default!;

        public IList<Car> Cars { get; set; } = new List<Car>();

        public class CarInfo
        {
            public required string CarPicURL { get; set; }
            public required string CarModel { get; set; }
            public required string CarName { get; set; }
        }

        public required string[,] RandomItemNames { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            // Define your connection string to the .db file
            var connectionString = "Data Source=NotForza.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                // Fetch 3 random items from the Name column in the Items table
                var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT CarPicURL, CarModel, CarName
                    FROM CAR
                    ORDER BY RANDOM()
                    LIMIT 3";

                using var reader = command.ExecuteReader();
                RandomItemNames = new string[3, 3]; // Initialize the 2D array: 3 cars, 3 details each
                int row = 0;
                while (reader.Read() && row < 3)
                {
                    RandomItemNames[row, 0] = reader.GetString(0); // CarPicURL
                    RandomItemNames[row, 1] = reader.GetString(1); // CarModel
                    RandomItemNames[row, 2] = reader.GetString(2); // CarName
                    row++;
                }
            }
            
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
        public async Task<IActionResult> OnPostAsync(int? id, string bio)
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

            // Ensure the logged-in user is the owner of the profile
            if (User!.Identity!.IsAuthenticated && User.Identity.Name == playerstats.Username)
            {
                playerstats.Bio = bio;
                await _context.SaveChangesAsync();
                ViewData["BioUpdated"] = "true"; // Set ViewData to indicate bio update
            }

            PlayerStats = playerstats;
            return RedirectToPage(new { id });
        }

    }
}