using System.Text.Json.Serialization;

namespace Boopin.Models;

/// <summary>
/// The whole cart. This is the object that gets serialized to localStorage.
/// All mutation rules (stock limits, removing at zero) live here so they can
/// be reasoned about without any UI or storage concerns.
/// </summary>
public class CartState
{
    public List<CartItem> Items { get; set; } = new();

    [JsonIgnore]
    public int TotalItemCount => Items.Sum(i => i.Quantity);

    [JsonIgnore]
    public decimal GrandTotal => Items.Sum(i => i.TotalPrice);

    [JsonIgnore]
    public bool IsEmpty => Items.Count == 0;

    public int QuantityOf(int productId) =>
        Items.FirstOrDefault(i => i.Product.Id == productId)?.Quantity ?? 0;

    /// <summary>
    /// Adds units of a product, never exceeding its stock.
    /// Returns false when nothing could be added (sold out or already at the limit).
    /// </summary>
    public bool Add(Product product, int quantity = 1)
    {
        if (quantity <= 0) return false;

        var item = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        var current = item?.Quantity ?? 0;
        var target = Math.Min(current + quantity, product.StockQuantity);
        if (target <= current) return false;

        if (item is null)
            Items.Add(new CartItem { Product = product, Quantity = target });
        else
            item.Quantity = target;

        return true;
    }

    /// <summary>Sets an exact quantity. Zero or less removes the line; values above stock are capped.</summary>
    public void SetQuantity(int productId, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.Product.Id == productId);
        if (item is null) return;

        if (quantity <= 0)
            Items.Remove(item);
        else
            item.Quantity = Math.Min(quantity, item.Product.StockQuantity);
    }

    public void Remove(int productId) => Items.RemoveAll(i => i.Product.Id == productId);

    public void Clear() => Items.Clear();
}
