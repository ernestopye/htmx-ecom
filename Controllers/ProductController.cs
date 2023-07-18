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

    [HttpGet("{id:int}/variants")]
    public IActionResult Index(int id, [FromQuery]int? variantId)
    {
        var product = Catalog.Products().First(p => p.Id == id);
        HttpContext.Response.Headers.Add("HX-Push-Url", "/products/" + id + "/variants?variantId=" + variantId);
        return View(new ProductDetailsViewModel { Product = product, VariantId = variantId });
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery]string q)
    {
        if (string.IsNullOrEmpty(q))
            return View(new ProductSearchViewModel { SearchResults = new List<Product>() });
            
        var products = Catalog.Products().Where(p => p.Name.ToLower().StartsWith(q.ToLower()));
        var model = new ProductSearchViewModel {
            SearchResults = products.ToList()
        };
        HttpContext.Response.Headers.Add("HX-Push-Url", "/products/search?q=" + q);
        return View(model);
    }
}