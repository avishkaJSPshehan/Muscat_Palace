using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Muscat_Palace.Models;
using Microsoft.EntityFrameworkCore;
using Muscat_Palace.Data;
using BCrypt.Net;

namespace Muscat_Palace.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // SignUp - GET
    public IActionResult SignUp()
    {
        return View();
    }

    // SignUp - POST
    [HttpPost]
    public async Task<IActionResult> SignUp(User user)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Check if user with the same email already exists
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email is already registered.");
                    return View(user);
                }

                // Hash the password before saving
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while signing up the user.");
                ModelState.AddModelError("", "An error occurred. Please try again later.");
            }
        }
        return View(user);
    }

    // Login - GET
    public IActionResult Login()
    {
        return View();
    }

    // Login - POST
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            // Redirect to the Index page or dashboard
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Invalid email or password.");
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
