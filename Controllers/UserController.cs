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

    [HttpPost("login")]
    public IActionResult Login() {
        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        UserState.IsLoggedIn = true;
        return Ok();
    }

    [HttpPost("logout")]
    public IActionResult Logout() {
        HttpContext.Response.Headers.Add("HX-Trigger", "updateSummary");
        UserState.IsLoggedIn = false;
        CartRepository.Clear();
        return Ok();
    }

    [HttpGet("register")]
    public IActionResult Register() {
        return View();
    }

    [HttpPost("register")]
    public IActionResult Register(UserRegisterViewModel model) {
        if (string.IsNullOrWhiteSpace(model.Email)) {
            ModelState.AddModelError(nameof(model.Email), "Email is required");
        } else if (model.Email != "test@test.com") {
            ModelState.AddModelError(nameof(model.Email), "Email is already taken");
        }
        
        if (string.IsNullOrWhiteSpace(model.Password)) {
            ModelState.AddModelError(nameof(model.Password), "Password is required");
        }

        if (!ModelState.IsValid) {
            model.IsHtmxRequest = HttpContext.Request.Headers["HX-Request"] == "true";
            return View(model);
        }

        UserState.IsLoggedIn = true;
        HttpContext.Response.Headers.Add("HX-Redirect", "/");
        return Ok();
    }
}
