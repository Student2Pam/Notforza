using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Downloads.Pages;

public class MarketplaceModel : PageModel
{
    private readonly ILogger<MarketplaceModel> _logger;

    public MarketplaceModel(ILogger<MarketplaceModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}