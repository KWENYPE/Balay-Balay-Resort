using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalayBalayResort.Models
{
    public class Booking
    {
        [Key]
        public int Booking_ID { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int Property_ID { get; set; }

        [ForeignKey(nameof(Property_ID))]
        public Property? Property { get; set; }

        public int User_ID { get; set; }

        [ForeignKey(nameof(User_ID))]
        public User? User { get; set; }

        public int NumberOfGuest { get; set; }

        public string Status { get; set; }

        public Transaction? Transaction { get; set; }
    }
}
