using System.Text.Json.Serialization;

namespace Boopin.Models;

public class CartItem
{
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }

    [JsonIgnore]
    public decimal TotalPrice => Product.Price * Quantity;
}
