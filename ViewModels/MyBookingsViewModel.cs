using Balay_Balay_Resort.Models;

namespace Balay_Balay_Resort.ViewModels;

public class MyBookingsViewModel
{
    public List<Booking> Bookings { get; set; } = new();
    public List<Transaction> Transactions { get; set; } = new();
    public string SearchQuery { get; set; } = "";
}