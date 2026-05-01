using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalayBalayResort.Models
{
    public class Amenity_Property
    {
        [Key]
        public int PropertyAmenity_ID { get; set; }

        public int Property_ID { get; set; }

        [ForeignKey(nameof(Property_ID))]
        public Property? Property { get; set; }

        public int Amenity_ID { get; set; }

        [ForeignKey(nameof(Amenity_ID))]
        public Amenity? Amenity { get; set; }
    }
}
