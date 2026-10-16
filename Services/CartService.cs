using System.Text.Json;
using Boopin.Models;
using Microsoft.JSInterop;

namespace Boopin.Services;

/// <summary>
/// Holds the in-memory <see cref="CartState"/> and mirrors it to browser localStorage
/// after every mutation (add, update quantity, remove, clear).
/// </summary>
public class CartService : ICartService
{
    private const string StorageKey = "boopin.cart.v1";

    private readonly IJSRuntime _js;
    private readonly IProductService _products;
    private bool _initialized;

    public CartService(IJSRuntime js, IProductService products)
    {
        _js = js;
        _products = products;
    }

    public CartState State { get; private set; } = new();

    public event Action? OnChange;

    public async Task InitializeAsync()
    {
        if (_initialized) return;
        _initialized = true;

        State = await LoadAsync();
        await PersistAsync();
        OnChange?.Invoke();
    }

    public async Task<bool> AddAsync(Product product, int quantity = 1)
    {
        var added = State.Add(product, quantity);
        if (added) await CommitAsync();
        return added;
    }

    public async Task IncrementAsync(int productId)
    {
        State.SetQuantity(productId, State.QuantityOf(productId) + 1);
        await CommitAsync();
    }

    public async Task DecrementAsync(int productId)
    {
        State.SetQuantity(productId, State.QuantityOf(productId) - 1);
        await CommitAsync();
    }

    public async Task SetQuantityAsync(int productId, int quantity)
    {
        State.SetQuantity(productId, quantity);
        await CommitAsync();
    }

    public async Task RemoveAsync(int productId)
    {
        State.Remove(productId);
        await CommitAsync();
    }

    public async Task ClearAsync()
    {
        State.Clear();
        await CommitAsync();
    }

    private async Task CommitAsync()
    {
        // Notify first so the UI feels instant, then write to localStorage.
        OnChange?.Invoke();
        await PersistAsync();
    }

    private async Task PersistAsync()
    {
        try
        {
            var json = JsonSerializer.Serialize(State);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }
        catch (JSException)
        {
            // Storage can be blocked (private mode, quota). The cart still works in memory.
        }
    }

    private async Task<CartState> LoadAsync()
    {
        try
        {
            var json = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
            if (string.IsNullOrWhiteSpace(json)) return new CartState();

            var saved = JsonSerializer.Deserialize<CartState>(json);
            if (saved is null) return new CartState();

            // Re-link saved lines to the current catalog so prices and stock are never stale,
            // and drop anything that no longer exists or is sold out.
            var catalog = (await _products.GetAllAsync()).ToDictionary(p => p.Id);
            var clean = new CartState();
            foreach (var line in saved.Items)
            {
                if (catalog.TryGetValue(line.Product.Id, out var current))
                    clean.Add(current, line.Quantity);
            }
            return clean;
        }
        catch (Exception ex) when (ex is JsonException or JSException or InvalidOperationException)
        {
            return new CartState();
        }
    }
}
