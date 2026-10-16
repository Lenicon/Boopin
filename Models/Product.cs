namespace Boopin.Models;

public class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public ProductCategory Category { get; init; }
    public int StockQuantity { get; init; }

    /// <summary>Average rating from 0 to 5.</summary>
    public double Rating { get; init; }

    public bool IsFeatured { get; init; }
}
