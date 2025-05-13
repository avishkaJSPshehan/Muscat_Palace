using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Muscat_Palace.Models;

namespace Muscat_Palace.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Menu()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    public IActionResult Arabian()
    {
        return View();
    }

    public IActionResult Indian()
    {
        return View();
    }

    public IActionResult Chinese()
    {
        return View();
    }

    public IActionResult Refreshments()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
