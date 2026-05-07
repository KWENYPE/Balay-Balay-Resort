using Balay_Balay_Resort.Models;

namespace Balay_Balay_Resort.ViewModels;
public class AdminPropertiesViewModel
{
    public List<Property> Properties { get; set; } = new();
    public string SearchQuery { get; set; } = "";
    public Property NewProperty { get; set; } = new();
}
