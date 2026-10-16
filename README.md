# BOOPIN

THIS WEBSITE IS FOR MIDTERMS

A frontend-only e-commerce demo for **Boopin**, a spooky-cute plushie brand.
Built with **.NET 8 Blazor WebAssembly** and **Tailwind CSS**. There is no backend and no database:
the cart lives in memory and is mirrored to the browser's `localStorage`.

## Run it locally

Requirements: the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and an internet connection
(Tailwind and the Google Fonts load from CDNs).

```bash
cd Boopin

dotnet run          # then open the URL printed in the terminal (http://localhost:5xxx)
# or, with hot reload while you edit:
dotnet watch
```

Publish a static site (host the output on any static host):

```bash
dotnet publish -c Release -o out
# serve out/wwwroot with any static file server
```

## What's inside

```
Boopin/
├── Models/
│   ├── Product.cs            Id, Name, Description, Price, ImageUrl, Category, StockQuantity, Rating, IsFeatured
│   ├── ProductCategory.cs    Ghosts | Bats | Cryptids | PastelGoths (+ display name / emoji helpers)
│   ├── CartItem.cs           Product, Quantity, TotalPrice => Product.Price * Quantity
│   ├── CartState.cs          Items, TotalItemCount, GrandTotal + Add / SetQuantity / Remove / Clear (stock-aware)
│   └── CheckoutDetails.cs    DataAnnotations model for the mock checkout form
├── Services/
│   ├── IProductService.cs / ProductService.cs   8 strongly-typed mock plushies
│   ├── ICartService.cs / CartService.cs         in-memory cart + localStorage persistence via IJSRuntime
│   ├── UiState.cs                               which overlay (cart / checkout) is open
│   └── ToastService.cs                          quick "added to cart" toasts
├── Layout/MainLayout.razor   sticky header with cart badge, footer, hosts the overlays
├── Pages/Home.razor          hero, featured plushies, promo banner, shop with category filters
├── Components/
│   ├── ProductCard.razor     bound to a Product; stock-aware Add to cart + toast
│   ├── CartDrawer.razor      slide-over cart with +, -, remove, clear, grand total
│   ├── CheckoutModal.razor   validated form, simulated processing, success message, cart reset
│   └── ToastHost.razor
└── wwwroot/
    ├── index.html            loads Tailwind (CDN) and the theme
    ├── js/tailwind-theme.js  the Boopin palette, fonts, shadows and animations
    ├── css/app.css           small extras (validation styles, splash, error banner)
    └── images/*.svg          original plushie illustrations
```

### How cart persistence works

`CartService` holds one `CartState` in memory and writes it to `localStorage` (key `boopin.cart.v1`) after every
add, quantity change, removal and clear. On startup it reads the saved cart and re-links each line to the current
catalog, so prices and stock are never stale and unknown or sold-out items are dropped. If storage is blocked
(private mode, quota), the cart keeps working in memory.

Checkout is a simulation: it validates the form, waits a moment, shows
**"Your spooky parcel is being prepared!"**, then clears the cart in memory and in `localStorage`.
No data leaves the browser.

### Theme

Colors are defined once in `wwwroot/js/tailwind-theme.js`: `plum` (dark backgrounds), `lavender` (text and
secondary accents), `blush` (pastel pink primary accent) and `mint` (highlights). Edit that file to re-skin the shop.

## Optional: compile Tailwind instead of using the CDN

The Play CDN is convenient but not meant for production. To ship compiled CSS:

```bash
npm install
npm run css:build      # writes wwwroot/css/tailwind.css (or css:watch while developing)
```

Then in `wwwroot/index.html` remove the three Tailwind `<script>` tags and add
`<link href="css/tailwind.css" rel="stylesheet" />`. `tailwind.config.js` reuses the same theme file,
so the look is identical.

## Ideas for next steps

- Replace `ProductService` with an API-backed implementation (the components only depend on `IProductService`).
- Add a product detail page (`/product/{id}`) using `GetByIdAsync`.
- Add shipping rules or promo codes to `CartState`.
