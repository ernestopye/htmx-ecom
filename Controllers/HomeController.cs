using System.Diagnostics;
using HtmxEcomSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace HtmxEcomSample.Controllers;

[Route("")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("sample")]
    public IActionResult Sample()
    {
        return View();
    }

    [HttpGet("date")]
    public IActionResult Date()
    {
        return View();
    }
}
