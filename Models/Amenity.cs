using System.ComponentModel.DataAnnotations;

namespace BalayBalayResort.Models
{
    public class Amenity
    {
        [Key]
        public int Amenity_ID { get; set; }

        public string Amenity_Name { get; set; }

        public ICollection<Amenity_Property> Amenity_Properties { get; set; } = new List<Amenity_Property>();
    }
}
