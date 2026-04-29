namespace BalayBalayResort.Models;

public class AdminBookingRow
{
    public string PropertyName { get; set; } = "";
    public string Date { get; set; } = "";
    public string Status { get; set; } = "";
}

public class AdminTransactionRow
{
    public string TransactionId { get; set; } = "";
    public string PaymentMethod { get; set; } = "";
    public decimal Amount { get; set; }
    public string Date { get; set; } = "";
}

public class AdminDashboardViewModel
{
    public int TotalUsers { get; set; }
    public int TotalProperties { get; set; }
    public int ActiveBookings { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<AdminBookingRow> RecentBookings { get; set; } = new();
    public List<AdminTransactionRow> RecentTransactions { get; set; } = new();
}
