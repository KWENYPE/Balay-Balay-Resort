using Microsoft.AspNetCore.Mvc;
using BalayBalayResort.ViewModels;

namespace BalayBalayResort.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // Admin credentials → admin panel
        if (model.Email == "admin@rentgala.com" && model.Password == "Admin123!")
        {
            return RedirectToAction("Index", "Admin");
        }

        // Guest credentials → guest dashboard
        if (model.Email == "dainne@example.com" && model.Password == "Guest123!")
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password.");
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // TODO: Replace with real registration logic
        return RedirectToAction("Login");
    }
}
