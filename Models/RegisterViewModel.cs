using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BalayBalayResort.Models;
// Don Commented
public class RegisterViewModel
{
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

// TODO: VALIDATION - SHOULD ONLY ACCEPT PHONE NUMBER
//                 - Ensure input accepts only numeric phone number format
//                - Consider adding validation(regex or model validation)
//              - Prevent letters or invalid characters
    [Required]
    [Phone]
    [Display(Name = "Phone No.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
