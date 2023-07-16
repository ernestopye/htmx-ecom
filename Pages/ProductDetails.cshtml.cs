using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace htmx_ecom.Pages;

public class ProductDetailsModel : PageModel
{
    private readonly ILogger<ProductDetailsModel> _logger;

    public ProductDetailsModel(ILogger<ProductDetailsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
