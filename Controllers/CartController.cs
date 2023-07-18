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

        _logger.LogInformation("Added to Cart: {0}", productId);
        
        return View("Added");
    }

    [HttpPost("full")]
    public IActionResult AddFull(int productId)
    {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        HttpContext.Response.Headers.Add("HX-Push-Url", "/cart");
        CartRepository.AddItem(Catalog.Products().First(p => p.Id == productId));
        
        return View("Index");
    }

    [HttpGet("current")]
    public async Task<IActionResult> Cart()
    {
        await Task.Delay(500);
        var items = CartRepository.GetItems();
        
        _logger.LogInformation("CartItems Count {0}", items.Count());
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
        _logger.LogInformation("CartItems Count {0}", items.Count());
        return View("Current", new UserCartViewModel { 
            IsHtmxRequest = true,
            CartItems = items
        });
    }
}
