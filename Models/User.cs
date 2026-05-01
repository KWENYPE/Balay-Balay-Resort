using System.ComponentModel.DataAnnotations;

namespace BalayBalayResort.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ProfileImagePath { get; set; } = "/images/profile-picture.jpg";

        public string UserType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
