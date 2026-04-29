namespace BalayBalayResort.Models;

public class TransactionModel
{
    public string TransactionId { get; set; } = "";
    public string BookingId { get; set; } = "";
    public string PaymentMethod { get; set; } = "N/A";
    public string Date { get; set; } = "N/A";
    public string Reference { get; set; } = "N/A";
    public decimal Total { get; set; }
    public string Status { get; set; } = ""; // Completed, Pending
}
