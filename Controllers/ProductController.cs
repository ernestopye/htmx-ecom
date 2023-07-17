using System.Diagnostics;
using Ecommerce;
using HtmxEcomSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtmxEcomSample.Controllers;

[Route("products")]
public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ProductController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public IActionResult Index(int id)
    {
        var product = Catalog.Products().First(p => p.Id == id);
        return View(new ProductDetailsViewModel { Product = product });
    }
}