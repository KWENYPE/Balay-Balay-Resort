namespace BalayBalayResort.Models;

public class BookingModel
{
    public string BookingId { get; set; } = "";
    public string PropertyName { get; set; } = "";
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int Guests { get; set; }
    public string PaymentMethod { get; set; } = "";
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = ""; // Confirmed, Pending, Cancelled
}
