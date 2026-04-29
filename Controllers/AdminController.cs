using Microsoft.AspNetCore.Mvc;
using BalayBalayResort.Models;

namespace BalayBalayResort.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    [Route("")]
    [Route("dashboard")]
    public IActionResult Index()
    {
        var vm = new AdminDashboardViewModel
        {
            TotalUsers      = 3,
            TotalProperties = 4,
            ActiveBookings  = 2,
            TotalRevenue    = 100500,
            RecentBookings  = new List<AdminBookingRow>
            {
                new AdminBookingRow { PropertyName = "Luxurious Beachfront Villa", Date = "2026-05-15", Status = "Confirmed" },
                new AdminBookingRow { PropertyName = "Modern Mountain Retreat",    Date = "2026-04-20", Status = "Confirmed" }
            },
            RecentTransactions = new List<AdminTransactionRow>
            {
                new AdminTransactionRow { TransactionId = "TXN001", PaymentMethod = "GCash", Amount = 75000, Date = "2026-04-10" },
                new AdminTransactionRow { TransactionId = "TXN001", PaymentMethod = "GCash", Amount = 23000, Date = "2026-04-10" }
            }
        };
        return View(vm);
    }

    // Shared in-memory list (persists for the session lifetime)
    private static List<PropertyItem> _properties = new()
    {
        new PropertyItem { Id = 1, UnitNumber = "54", Name = "Luxurious Beach Villa",    Beds = 3, Baths = 1, Guests = 4, PricePerNight = 15000, Rating = 4.9, ReviewCount = 234, ImageUrl = "/images/bg-login.png" },
        new PropertyItem { Id = 2, UnitNumber = "55", Name = "Modern Mountain Retreat",  Beds = 4, Baths = 2, Guests = 6, PricePerNight = 19000, Rating = 4.7, ReviewCount = 189, ImageUrl = "/images/bg-login.png" },
        new PropertyItem { Id = 3, UnitNumber = "56", Name = "Luxurious Beachfront Villa", Beds = 5, Baths = 3, Guests = 8, PricePerNight = 39000, Rating = 4.9, ReviewCount = 312, ImageUrl = "/images/bg-login.png" },
        new PropertyItem { Id = 4, UnitNumber = "57", Name = "City Center Studio",       Beds = 1, Baths = 1, Guests = 2, PricePerNight = 8500,  Rating = 4.3, ReviewCount = 97,  ImageUrl = "/images/bg-login.png" },
    };

    [Route("properties")]
    [HttpGet]
    public IActionResult Properties(string search = "")
    {
        var list = string.IsNullOrWhiteSpace(search)
            ? _properties
            : _properties.Where(p =>
                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.UnitNumber.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        return View(new AdminPropertiesViewModel
        {
            Properties  = list,
            SearchQuery = search
        });
    }

    [Route("properties/add")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddProperty(PropertyItem item)
    {
        if (ModelState.IsValid)
        {
            item.Id = _properties.Count > 0 ? _properties.Max(p => p.Id) + 1 : 1;
            if (string.IsNullOrWhiteSpace(item.ImageUrl))
                item.ImageUrl = "/images/bg-login.png";
            _properties.Add(item);
        }
        return RedirectToAction("Properties");
    }

    [Route("properties/delete/{id}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteProperty(int id)
    {
        _properties.RemoveAll(p => p.Id == id);
        return RedirectToAction("Properties");
    }

    [Route("properties/edit/{id}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProperty(PropertyItem item)
    {
        var existing = _properties.FirstOrDefault(p => p.Id == item.Id);
        if (existing != null)
        {
            existing.UnitNumber    = item.UnitNumber;
            existing.Name          = item.Name;
            existing.Beds          = item.Beds;
            existing.Baths         = item.Baths;
            existing.Guests        = item.Guests;
            existing.PricePerNight = item.PricePerNight;
            existing.Description   = item.Description;
            existing.Amenities     = item.Amenities;
            if (!string.IsNullOrWhiteSpace(item.ImageUrl))
                existing.ImageUrl = item.ImageUrl;
        }
        return RedirectToAction("Properties");
    }

    [Route("transactions")]
    public IActionResult Transactions(string search = "")
    {
        var all = new List<TransactionItem>
        {
            new TransactionItem { TransactionId = "TXN001", BookingId = "BK001", PropertyName = "Luxurious Beachfront Villa", Amount = 75000, Method = "GCash", Date = "2026-04-10", Reference = "GC-202604101234", Status = "Completed" },
            new TransactionItem { TransactionId = "TXN002", BookingId = "BK001", PropertyName = "Luxurious Beachfront Villa", Amount = 75000, Method = "GCash", Date = "2026-04-10", Reference = "GC-202604101235", Status = "Completed" },
            new TransactionItem { TransactionId = "TXN003", BookingId = "BK002", PropertyName = "Modern Mountain Retreat",   Amount = 95000, Method = "GCash", Date = "2026-04-12", Reference = "GC-202604120987", Status = "Pending"   },
        };

        var list = string.IsNullOrWhiteSpace(search)
            ? all
            : all.Where(t =>
                t.TransactionId.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                t.BookingId.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                t.PropertyName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                t.Method.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                t.Status.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        var vm = new AdminTransactionsViewModel
        {
            TotalTransactions = list.Count,
            TotalRevenue      = list.Sum(t => t.Amount),
            Completed         = list.Count(t => t.Status == "Completed"),
            Transactions      = list,
            SearchQuery       = search
        };

        return View(vm);
    }

    [Route("reports")]
    public IActionResult Reports()
    {
        var vm = new AdminReportsViewModel
        {
            TotalRevenue      = 100500,
            TotalBookings     = 2,
            AvgBookingValue   = 50250,
            OccupancyRate     = 78,
            ConfirmedBookings = 2,
            PendingBookings   = 0,
            CancelledBookings = 0,
            RevenueGrowthPct  = 12,
            BookingRatePct    = 8,
            CustomerSatisfaction = 4.8,
            TopProperties = new List<TopProperty>
            {
                new TopProperty { Rank = 1, Name = "Luxurious Beachfront Villa", Location = "Boracay, Philippines",  Revenue = 150000, Bookings = 127, ImageUrl = "/images/bg-login.png" },
                new TopProperty { Rank = 2, Name = "Modern Mountain Retreat",   Location = "Tagaytay, Philippines", Revenue = 85000,  Bookings = 89,  ImageUrl = "/images/bg-login.png" },
                new TopProperty { Rank = 3, Name = "Tropical Garden Bungalow",  Location = "Palawan, Philippines",  Revenue = 60000,  Bookings = 64,  ImageUrl = "/images/bg-login.png" },
                new TopProperty { Rank = 4, Name = "Urban Penthouse Suite",     Location = "Makati, Manila",        Revenue = 120000, Bookings = 156, ImageUrl = "/images/bg-login.png" },
            },
            PaymentMethods = new List<PaymentMethodRevenue>
            {
                new PaymentMethodRevenue { Code = "GC", Name = "GCash",         Transactions = 1, Amount = 75000, Percentage = 50, Color = "#2563eb" },
                new PaymentMethodRevenue { Code = "BT", Name = "Bank Transfer", Transactions = 1, Amount = 25500, Percentage = 50, Color = "#16a34a" },
            }
        };
        return View(vm);
    }
}
