using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ecommerce;

namespace htmx_ecom.Pages;

public class AddModel : PageModel
{
    private readonly ILogger<AddModel> _logger;

    public AddModel(ILogger<AddModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public int ProductId { get; set; }

    public IActionResult OnGet()
    {
        return NotFound();
    }

    public IActionResult OnPost() {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        CartRepository.AddItem(Catalog.Products().First(p => p.Id == ProductId));
        return Page();
    }
}
