using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BalayBalayResort.Models;
using BalayBalayResort.ViewModels;

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

    [Route("my-bookings")]
    public IActionResult MyBookings(string search = "")
    {
        var allBookings = new List<BookingModel>
        {
            new BookingModel
            {
                BookingId    = "BK001",
                PropertyName = "Luxurious Beachfront Villa",
                CheckIn      = new DateTime(2026, 5, 15),
                CheckOut     = new DateTime(2026, 5, 20),
                Guests       = 6,
                PaymentMethod = "GCash",
                TotalAmount  = 195000,
                Status       = "Confirmed"
            },
            new BookingModel
            {
                BookingId    = "BK002",
                PropertyName = "Modern Mountain Retreat",
                CheckIn      = new DateTime(2026, 5, 15),
                CheckOut     = new DateTime(2026, 5, 20),
                Guests       = 6,
                PaymentMethod = "GCash",
                TotalAmount  = 95000,
                Status       = "Confirmed"
            }
        };

        var allTransactions = new List<TransactionModel>
        {
            new TransactionModel
            {
                TransactionId = "TXN001",
                BookingId     = "BK001",
                PaymentMethod = "GCash",
                Date          = "2026-04-10",
                Reference     = "GC-202604101234",
                Total         = 195000,
                Status        = "Completed"
            },
            new TransactionModel
            {
                TransactionId = "N/A",
                BookingId     = "BK002",
                PaymentMethod = "N/A",
                Date          = "N/A",
                Reference     = "N/A",
                Total         = 0,
                Status        = "Pending"
            }
        };

        List<BookingModel> bookings = allBookings;
        List<TransactionModel> transactions = allTransactions;

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.ToLower();
            bookings = allBookings
                .Where(b => b.PropertyName.ToLower().Contains(s)
                         || b.BookingId.ToLower().Contains(s)
                         || b.Status.ToLower().Contains(s)
                         || b.PaymentMethod.ToLower().Contains(s))
                .ToList();

            var matchedIds = bookings.Select(b => b.BookingId).ToHashSet();
            transactions = allTransactions
                .Where(t => matchedIds.Contains(t.BookingId)
                         || t.TransactionId.ToLower().Contains(s)
                         || t.Status.ToLower().Contains(s))
                .ToList();
        }

        var vm = new MyBookingsViewModel
        {
            Bookings     = bookings,
            Transactions = transactions,
            SearchQuery  = search
        };

        return View(vm);
    }

    [Route("edit-profile")]
    public IActionResult EditProfile()
    {
        var vm = new EditProfileViewModel
        {
            FullName    = "Dainne Chua",
            Email       = "dainne@example.com",
            PhoneNumber = "+63 912 345 6789"
        };
        return View(vm);
    }

    [Route("edit-profile")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.SuccessMessage = "Profile updated successfully!";
        model.Password = null;
        model.ConfirmPassword = null;
        return View(model);
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
