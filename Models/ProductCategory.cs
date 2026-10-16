namespace Boopin.Models;

/// <summary>Categories used by the shop filter buttons.</summary>
public enum ProductCategory
{
    Ghosts,
    Bats,
    Cryptids,
    PastelGoths
}

public static class ProductCategoryExtensions
{
    public static string ToDisplayName(this ProductCategory category) => category switch
    {
        ProductCategory.PastelGoths => "Pastel Goths",
        _ => category.ToString()
    };

    public static string ToEmoji(this ProductCategory category) => category switch
    {
        ProductCategory.Ghosts => "👻",
        ProductCategory.Bats => "🦇",
        ProductCategory.Cryptids => "🐉",
        ProductCategory.PastelGoths => "🪦",
        _ => "✨"
    };
}
