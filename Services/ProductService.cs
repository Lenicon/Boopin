using Boopin.Models;

namespace Boopin.Services;

/// <summary>Strongly-typed in-memory catalog of spooky-cute plushies.</summary>
public class ProductService : IProductService
{
    private static readonly IReadOnlyList<Product> Catalog = new List<Product>
    {
        new()
        {
            Id = 1,
            Name = "Mochi the Phantom Bat",
            Description = "A squishy little night-flyer with velvet wings, tiny fangs and the softest belly in the belfry. Best friends with insomniacs.",
            Price = 24.99m,
            ImageUrl = "images/mochi-phantom-bat.svg",
            Category = ProductCategory.Bats,
            StockQuantity = 12,
            Rating = 4.9,
            IsFeatured = true
        },
        new()
        {
            Id = 2,
            Name = "Pudding the Pastel Reaper",
            Description = "Death, but make it dessert. Comes with a bendy candy scythe and a hood lined with cloud-soft fleece.",
            Price = 29.99m,
            ImageUrl = "images/pudding-pastel-reaper.svg",
            Category = ProductCategory.PastelGoths,
            StockQuantity = 8,
            Rating = 4.8,
            IsFeatured = true
        },
        new()
        {
            Id = 3,
            Name = "Boba the Alien Ghost",
            Description = "Not from this world, not quite from the next one either. Antennae wobble when you hug it.",
            Price = 26.50m,
            ImageUrl = "images/boba-alien-ghost.svg",
            Category = ProductCategory.Ghosts,
            StockQuantity = 15,
            Rating = 4.7,
            IsFeatured = true
        },
        new()
        {
            Id = 4,
            Name = "Marshmallow Boo",
            Description = "A plump lavender ghost wearing a bow it absolutely did not steal from your grandma's attic.",
            Price = 22.00m,
            ImageUrl = "images/marshmallow-boo.svg",
            Category = ProductCategory.Ghosts,
            StockQuantity = 20,
            Rating = 4.6,
            IsFeatured = false
        },
        new()
        {
            Id = 5,
            Name = "Nibbles the Vampire Bat",
            Description = "Only drinks strawberry milk. Hangs upside down on your shelf and judges your snack choices.",
            Price = 21.99m,
            ImageUrl = "images/nibbles-vampire-bat.svg",
            Category = ProductCategory.Bats,
            StockQuantity = 3,
            Rating = 4.5,
            IsFeatured = false
        },
        new()
        {
            Id = 6,
            Name = "Sprout the Moth Cryptid",
            Description = "Drawn to lamplight and bedtime stories. Fuzzy antennae, dusty wings, enormous sparkly eyes.",
            Price = 27.99m,
            ImageUrl = "images/sprout-moth-cryptid.svg",
            Category = ProductCategory.Cryptids,
            StockQuantity = 10,
            Rating = 4.9,
            IsFeatured = true
        },
        new()
        {
            Id = 7,
            Name = "Lulu the Lavender Lich",
            Description = "A very small, very polite undead ruler with a pastel crown. Rules over your desk with gentle authority.",
            Price = 31.00m,
            ImageUrl = "images/lulu-lavender-lich.svg",
            Category = ProductCategory.PastelGoths,
            StockQuantity = 6,
            Rating = 4.8,
            IsFeatured = false
        },
        new()
        {
            Id = 8,
            Name = "Gumdrop the Lake Cryptid",
            Description = "Rarely spotted, endlessly huggable. Surfaces only for cuddles and the occasional blueberry.",
            Price = 28.50m,
            ImageUrl = "images/gumdrop-lake-cryptid.svg",
            Category = ProductCategory.Cryptids,
            StockQuantity = 0,
            Rating = 4.7,
            IsFeatured = false
        }
    };

    public Task<IReadOnlyList<Product>> GetAllAsync() => Task.FromResult(Catalog);

    public Task<IReadOnlyList<Product>> GetFeaturedAsync() =>
        Task.FromResult<IReadOnlyList<Product>>(Catalog.Where(p => p.IsFeatured).ToList());

    public Task<IReadOnlyList<Product>> GetByCategoryAsync(ProductCategory? category) =>
        Task.FromResult<IReadOnlyList<Product>>(
            category is null ? Catalog : Catalog.Where(p => p.Category == category).ToList());

    public Task<Product?> GetByIdAsync(int id) =>
        Task.FromResult(Catalog.FirstOrDefault(p => p.Id == id));
}
