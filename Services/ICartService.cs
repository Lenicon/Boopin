using Boopin.Models;

namespace Boopin.Services;

public interface ICartService
{
    CartState State { get; }

    /// <summary>Raised after every change, including the initial load from localStorage.</summary>
    event Action? OnChange;

    /// <summary>Loads the saved cart from localStorage. Safe to call more than once.</summary>
    Task InitializeAsync();

    /// <summary>Returns false when the product is sold out or the cart already holds all available stock.</summary>
    Task<bool> AddAsync(Product product, int quantity = 1);

    Task IncrementAsync(int productId);
    Task DecrementAsync(int productId);
    Task SetQuantityAsync(int productId, int quantity);
    Task RemoveAsync(int productId);
    Task ClearAsync();
}
