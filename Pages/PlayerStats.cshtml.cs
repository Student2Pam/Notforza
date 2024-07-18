using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Downloads.Pages;

public class PlayerStatsModel : PageModel
{
    private readonly ILogger<PlayerStatsModel> _logger;

    public PlayerStatsModel(ILogger<PlayerStatsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

