using System.Diagnostics;
using HtmxEcomSample.Models;
using Microsoft.AspNetCore.Mvc;
using Ecommerce;

namespace HtmxEcomSample.Controllers;

[Route("cart")]
public class CartController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public CartController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var isHtmxRequest = Request.Headers["HX-Request"] == "true";
        return View();
    }

    [HttpPost]
    public IActionResult Add(int productId)
    {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        CartRepository.AddItem(Catalog.Products().First(p => p.Id == productId));
        
        return View("Added");
    }

    [HttpGet("current")]
    public async Task<IActionResult> Cart()
    {
        await Task.Delay(500);
        var items = CartRepository.GetItems();
        
        Console.WriteLine("CartItems: " + items.Count());
        return View("Current", new UserCartViewModel { 
            IsHtmxRequest = true,
            CartItems = items
        });
    }

    [HttpDelete]
    public IActionResult Remove(int cartItemId)
    {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        CartRepository.RemoveItem(cartItemId);
        
        var items = CartRepository.GetItems();
        Console.WriteLine("CartItems: " + items.Count());
        return View("Current", new UserCartViewModel { 
            IsHtmxRequest = true,
            CartItems = items
        });
    }
}
