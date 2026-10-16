using System.ComponentModel.DataAnnotations;

namespace Boopin.Models;

/// <summary>Dummy customer details captured by the mock checkout. Nothing is sent anywhere.</summary>
public class CheckoutDetails
{
    [Required(ErrorMessage = "Every parcel needs a name on it.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Name should be 2 to 80 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "We need an email for your spooky receipt.")]
    [EmailAddress(ErrorMessage = "That email looks a little ghostly. Try again?")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Where should the parcel haunt?")]
    [StringLength(120, ErrorMessage = "Address is too long.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required.")]
    [StringLength(60, ErrorMessage = "City is too long.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Postal code is required.")]
    [RegularExpression(@"^[A-Za-z0-9\- ]{3,10}$", ErrorMessage = "Use 3 to 10 letters, numbers, spaces or dashes.")]
    public string PostalCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Pick a country.")]
    public string Country { get; set; } = string.Empty;

    [StringLength(120, ErrorMessage = "Keep the note under 120 characters.")]
    public string? GiftNote { get; set; }
}
