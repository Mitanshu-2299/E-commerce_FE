using ECommerce.Components;
using ECommerce.Config;
using ECommerce.Service.API;
using ECommerce.Service.API.AuthService;
using ECommerce.Service.CountryService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<ToastService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register a HttpClient with BaseUrl (for direct injection)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(APIEndPoints.BaseUrl) });


// Register API related services
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddHttpClient("ECommAPI", client =>
{
    client.BaseAddress = new Uri(APIEndPoints.BaseUrl);
});

// Authentication + Authorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Optional: CORS if your API is remote
// app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
