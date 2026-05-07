using System.ComponentModel.DataAnnotations;

namespace Balay_Balay_Resort.ViewModels
{
    public class BookingCreateViewModel
    {
        public int Property_ID { get; set; }

        public string PropertyName { get; set; } = "";

        public string? PropertyImagePath { get; set; }

        public decimal PricePerNight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Number of guests must be between 1 and 8.")]
        public int NumberOfGuest { get; set; } = 1;

        [Required]
        public string PaymentMode { get; set; } = "";

        public string? ReferenceNum { get; set; }
    }
}