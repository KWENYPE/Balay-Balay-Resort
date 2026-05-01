using BalayBalayResort.Models;

namespace BalayBalayResort.ViewModels;

public class MyBookingsViewModel
{
    public List<BookingModel> Bookings { get; set; } = new();
    public List<TransactionModel> Transactions { get; set; } = new();
    public string SearchQuery { get; set; } = "";
}
