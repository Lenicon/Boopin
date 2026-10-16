using Boopin;
using Boopin.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Catalog is static mock data. Swap this registration for an API-backed
// implementation of IProductService later without touching any component.
builder.Services.AddScoped<IProductService, ProductService>();

// Cart state lives in memory and is mirrored to browser localStorage.
builder.Services.AddScoped<ICartService, CartService>();

// Small UI helpers shared by the layout and components.
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<UiState>();

await builder.Build().RunAsync();
