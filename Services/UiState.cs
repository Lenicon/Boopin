namespace Boopin.Services;

/// <summary>Tracks which overlay (cart drawer or checkout modal) is open.</summary>
public class UiState
{
    public bool IsCartOpen { get; private set; }
    public bool IsCheckoutOpen { get; private set; }

    public event Action? OnChange;

    public void OpenCart()
    {
        IsCartOpen = true;
        IsCheckoutOpen = false;
        OnChange?.Invoke();
    }

    public void CloseCart()
    {
        IsCartOpen = false;
        OnChange?.Invoke();
    }

    public void OpenCheckout()
    {
        IsCartOpen = false;
        IsCheckoutOpen = true;
        OnChange?.Invoke();
    }

    public void CloseCheckout()
    {
        IsCheckoutOpen = false;
        OnChange?.Invoke();
    }
}
