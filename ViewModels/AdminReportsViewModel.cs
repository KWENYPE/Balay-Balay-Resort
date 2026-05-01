namespace BalayBalayResort.ViewModels;

public class TopProperty
{
    public int Rank { get; set; }
    public string Name { get; set; } = "";
    public string Location { get; set; } = "";
    public decimal Revenue { get; set; }
    public int Bookings { get; set; }
    public string ImageUrl { get; set; } = "/images/bg-login.png";
}

public class PaymentMethodRevenue
{
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public int Transactions { get; set; }
    public decimal Amount { get; set; }
    public int Percentage { get; set; }
    public string Color { get; set; } = "#2563eb";
}

public class AdminReportsViewModel
{
    public decimal TotalRevenue { get; set; }
    public int TotalBookings { get; set; }
    public decimal AvgBookingValue { get; set; }
    public int OccupancyRate { get; set; }

    public List<TopProperty> TopProperties { get; set; } = new();
    public List<PaymentMethodRevenue> PaymentMethods { get; set; } = new();

    public int ConfirmedBookings { get; set; }
    public int PendingBookings { get; set; }
    public int CancelledBookings { get; set; }

    public int RevenueGrowthPct { get; set; }
    public int BookingRatePct { get; set; }
    public double CustomerSatisfaction { get; set; }
}
