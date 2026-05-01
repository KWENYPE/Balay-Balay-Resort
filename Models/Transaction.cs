using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalayBalayResort.Models
{
    public class Transaction
    {
        [Key]
        public int Transaction_ID { get; set; }

        public string PaymentMode { get; set; }

        public string ReferenceNum { get; set; }

        public int Booking_ID { get; set; }

        [ForeignKey(nameof(Booking_ID))]
        public Booking? Booking {  get; set; }

        public string Status { get; set; }
    }
}
