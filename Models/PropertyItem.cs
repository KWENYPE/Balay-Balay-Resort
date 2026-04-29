using System.ComponentModel.DataAnnotations;

namespace BalayBalayResort.Models;

public class PropertyItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Unit number is required.")]
    public string UnitNumber { get; set; } = "";

    [Required(ErrorMessage = "Property name is required.")]
    public string Name { get; set; } = "";

    [Required]
    [Range(1, 20)]
    public int Beds { get; set; }

    [Required]
    [Range(1, 20)]
    public int Baths { get; set; }

    [Required]
    [Range(1, 50)]
    public int Guests { get; set; }

    [Required]
    [Range(1, 9999999)]
    public decimal PricePerNight { get; set; }

    public string Description { get; set; } = "";
    public string Amenities { get; set; } = "";
    public double Rating { get; set; } = 4.9;
    public int ReviewCount { get; set; } = 0;
    public string ImageUrl { get; set; } = "/images/bg-login.png";
}

public class AdminPropertiesViewModel
{
    public List<PropertyItem> Properties { get; set; } = new();
    public string SearchQuery { get; set; } = "";
    public PropertyItem NewProperty { get; set; } = new();
}
