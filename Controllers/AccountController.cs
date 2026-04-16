using Microsoft.AspNetCore.Mvc;
using BalayBalayResort.Models;

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

        // TODO: Replace with real authentication logic
        if (model.Email == "admin@rentgala.com" && model.Password == "Admin123!")
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
