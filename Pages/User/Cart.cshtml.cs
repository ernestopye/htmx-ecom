using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ecommerce;

namespace htmx_ecom.Pages.User;

public class UserCartModel : PageModel
{
    private readonly ILogger<UserCartModel> _logger;

    public UserCartModel(ILogger<UserCartModel> logger)
    {
        _logger = logger;
    }

    public IEnumerable<CartItem> CartItems { get; set; }

    public IActionResult OnGet()
    {
        CartItems = CartRepository.GetItems();
        Console.WriteLine("CartItems: " + CartItems.Count());
        return Page();
    }
}
