using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BalayBalayResort.Models;

namespace BalayBalayResort.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Dashboard");
    }

    [Route("dashboard")]
    public IActionResult Dashboard()
    {
        return View("Index");
    }

    [Route("browse-properties")]
    public IActionResult BrowseProperties()
    {
        return View();
    }

    [Route("property/{id}")]
    public IActionResult PropertyDetail(int id)
    {
        ViewBag.PropertyId = id;
        return View();
    }

    [Route("booking/{id}")]
    public IActionResult Booking(int id)
    {
        ViewBag.PropertyId = id;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
