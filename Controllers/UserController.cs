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
}
