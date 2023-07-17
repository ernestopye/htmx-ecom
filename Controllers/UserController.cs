using System.Diagnostics;
using HtmxEcomSample.Models;
using Microsoft.AspNetCore.Mvc;
using Ecommerce;

namespace HtmxEcomSample.Controllers;

[Route("user")]
public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Summary", new UserSummaryViewModel { 
            IsHtmxRequest = true,
            TotalItemsInCart = CartRepository.GetTotalCount()
        });
    }

    [HttpGet("cart")]
    public async Task<IActionResult> Cart()
    {
        await Task.Delay(1000);
        var items = CartRepository.GetItems();
        Console.WriteLine("CartItems: " + items.Count());
        return View("Cart", new UserCartViewModel { 
            IsHtmxRequest = true,
            CartItems = items
        });
    }
}
