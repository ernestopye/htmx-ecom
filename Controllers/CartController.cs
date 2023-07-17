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

    [HttpPost("add")]
    public IActionResult Add(int productId)
    {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        CartRepository.AddItem(Catalog.Products().First(p => p.Id == productId));
        
        return View("Added");
    }
}
