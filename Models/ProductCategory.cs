namespace Boopin.Models;

/// <summary>Categories used by the shop filter buttons.</summary>
public enum ProductCategory
{
    Ghosts,
    Bats,
    Cryptids,
    Clowns,
    Patchwork
}

public static class ProductCategoryExtensions
{
    public static string ToDisplayName(this ProductCategory category) => category switch
    {
        _ => category.ToString()
    };

    public static string ToEmoji(this ProductCategory category) => category switch
    {
        ProductCategory.Ghosts => "👻",
        ProductCategory.Bats => "🦇",
        ProductCategory.Cryptids => "🐉",
        ProductCategory.Clowns => "🤡",
        ProductCategory.Patchwork => "🧵",
        _ => "✨"
    };
}
