using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalayBalayResort.Models
{
    public class Feedback
    {
        [Key]
        public int Feedback_ID { get; set; }

        public int User_ID { get; set; }

        [ForeignKey(nameof(User_ID))]
        public User? User { get; set; }

        public string? Comment { get; set; }

        public decimal ReviewRate { get; set; }

        public int Property_ID { get; set; }

        [ForeignKey(nameof(Property_ID))]
        public Property? Property { get; set; }
    }
}
