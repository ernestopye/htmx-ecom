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
}