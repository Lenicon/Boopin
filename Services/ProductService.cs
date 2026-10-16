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
            Name = "Clownbear",
            Description = "A cheerful clown bear featuring a squeezable red nose and soft fuzzy fur. Guaranteed to bring giggles to the darkest room.",
            Price = 24.99m,
            ImageUrl = "images/clownbear.jpg",
            Category = ProductCategory.Clowns,
            StockQuantity = 12,
            Rating = 4.8,
            IsFeatured = true
        },
        new()
        {
            Id = 2,
            Name = "Emily",
            Description = "A sweet pink patchwork cat stitched together with love, mismatched buttons, and a whole lot of snuggly charm.",
            Price = 22.99m,
            ImageUrl = "images/emily.jpg",
            Category = ProductCategory.Patchwork,
            StockQuantity = 15,
            Rating = 4.9,
            IsFeatured = true
        },
        new()
        {
            Id = 3,
            Name = "Jesta",
            Description = "A mischievous jester bunny with floppy ears and playful multi-colored bells that chime softly when hugged.",
            Price = 23.99m,
            ImageUrl = "images/jesta.jpg",
            Category = ProductCategory.Clowns,
            StockQuantity = 10,
            Rating = 4.7,
            IsFeatured = false
        },
        new()
        {
            Id = 4,
            Name = "Kooble",
            Description = "A compact bear party clown wearing a bright blue hat. Smaller than Clownbear, but packing twice the circus fun!",
            Price = 19.99m,
            ImageUrl = "images/kooble.jpg",
            Category = ProductCategory.Clowns,
            StockQuantity = 18,
            Rating = 4.6,
            IsFeatured = false
        },
        new()
        {
            Id = 5,
            Name = "Pumpo",
            Description = "A plump white pumpkin plushie sporting a vibrant green body. The ultimate cuddle buddy for autumn nights.",
            Price = 21.99m,
            ImageUrl = "images/pumpo.jpg",
            Category = ProductCategory.Cryptids,
            StockQuantity = 14,
            Rating = 4.9,
            IsFeatured = false
        },
        new()
        {
            Id = 6,
            Name = "Slocotion",
            Description = "A festive pumpkin dressed head-to-toe in a playful jester costume. Ready to juggle your worries away.",
            Price = 25.99m,
            ImageUrl = "images/slocotion.jpg",
            Category = ProductCategory.Clowns,
            StockQuantity = 8,
            Rating = 4.8,
            IsFeatured = false
        },
        new()
        {
            Id = 7,
            Name = "Wiznoc",
            Description = "A mystical wizard plushie with a singular watchful eye for its head. Knows all the spells for ultimate relaxation.",
            Price = 26.99m,
            ImageUrl = "images/wiznoc.jpg",
            Category = ProductCategory.Cryptids,
            StockQuantity = 9,
            Rating = 5.0,
            IsFeatured = true
        },
        new()
        {
            Id = 8,
            Name = "Batto",
            Description = "A gentle white bat embroidered with a bright red heart on its chest. Flutters straight into your arms at bedtime.",
            Price = 21.99m,
            ImageUrl = "images/batto.jpg",
            Category = ProductCategory.Bats,
            StockQuantity = 20,
            Rating = 4.9,
            IsFeatured = true
        },
        new()
        {
            Id = 9,
            Name = "Skellybat",
            Description = "A velvety black bat plushie detailed with spooky glow-in-the-dark skeleton bone markings. Spookily soft for late-night cuddles.",
            Price = 23.99m,
            ImageUrl = "images/skellybat.jpg",
            Category = ProductCategory.Bats,
            StockQuantity = 11,
            Rating = 4.8,
            IsFeatured = false
        },
        new()
        {
            Id = 10,
            Name = "Sacko",
            Description = "A delightfully wicked little sack man plushie with stitched-up grins and a surprisingly cuddly burlap-style texture.",
            Price = 19.99m,
            ImageUrl = "images/sacko.jpg",
            Category = ProductCategory.Patchwork,
            StockQuantity = 16,
            Rating = 4.7,
            IsFeatured = false
        },
        new()
        {
            Id = 11,
            Name = "Mortem",
            Description = "A sleepy-eyed ghost plushie wrapped in a dreamy shroud, perfect for floating right alongside you into dreamland.",
            Price = 20.99m,
            ImageUrl = "images/mortem.jpg",
            Category = ProductCategory.Ghosts,
            StockQuantity = 14,
            Rating = 4.9,
            IsFeatured = false
        },
        new()
        {
            Id = 12,
            Name = "Bookii",
            Description = "A friendly little ghost sporting a tiny pumpkin right on his head, always ready to whisper a cute 'boo!' and keep you company.",
            Price = 22.99m,
            ImageUrl = "images/bookii.jpg",
            Category = ProductCategory.Ghosts,
            StockQuantity = 13,
            Rating = 4.9,
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
