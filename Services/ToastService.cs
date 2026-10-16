namespace Boopin.Services;

public record ToastMessage(Guid Id, string Text, string Emoji);

/// <summary>Tiny fire-and-forget toast queue; <c>ToastHost</c> renders it.</summary>
public class ToastService
{
    private readonly List<ToastMessage> _toasts = new();

    public IReadOnlyList<ToastMessage> Toasts => _toasts.ToArray();

    public event Action? OnChange;

    public void Show(string text, string emoji = "👻", int durationMs = 2600)
    {
        var toast = new ToastMessage(Guid.NewGuid(), text, emoji);
        _toasts.Add(toast);
        OnChange?.Invoke();
        _ = DismissLaterAsync(toast, durationMs);
    }

    private async Task DismissLaterAsync(ToastMessage toast, int durationMs)
    {
        await Task.Delay(durationMs);
        _toasts.Remove(toast);
        OnChange?.Invoke();
    }
}
