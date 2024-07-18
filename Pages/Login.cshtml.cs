using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Data.SQLite;
using Dapper;
using System.Security.Cryptography;
using System.Text;

namespace Downloads.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        private readonly string connectionString = "Data Source = NotForza.db"; // Adjust your connection string

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ValidateUser(Username, Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username ?? string.Empty)
                };

                // Check if the user is 'jackyc' and add a role claim accordingly
                if (Username == "jackyc" || Username == "SleepyPumpk1n")
                {
                    // Add a role claim for admin
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Admin/AdminMenu");
                }
                else
                {
                    // Optionally, add a role claim for regular users
                    // claims.Add(new Claim(ClaimTypes.Role, "User"));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your username and password and try again.");
            return Page();
        }


        private bool ValidateUser(string? username, string? password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            using (var connection = new SQLiteConnection(connectionString))
            {
                var query = "SELECT HashedPassword, Salty FROM Credentials WHERE PlayerID = (SELECT PlayerID FROM PlayerStats WHERE Username = @Username)";
                var user = connection.QueryFirstOrDefault<dynamic>(query, new { Username = username });

                if (user == null)
                    return false;

                string storedHashedPassword = user.HashedPassword;
                string storedSalt = user.Salty;

                string hashedPassword = HashPassword(password, storedSalt);

                return storedHashedPassword == hashedPassword;
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashedPasswordBytes = sha256.ComputeHash(saltedPasswordBytes);
                return BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();
            }
        }
    }
}
