using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Authorization;



namespace Downloads.Pages.Admin
{
   [Authorize(Roles = "Admin")]
    public class AdminMenuModel : PageModel
    {
        public void OnGet()
        {
            // Initialization code or data loading can go here
            // For this specific example, there might not be any initialization required
        }
    }
}
