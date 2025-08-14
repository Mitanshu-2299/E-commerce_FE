using ECommerce.Components;
using ECommerce.Config;
using ECommerce.Service.API;
using ECommerce.Service.API.AuthService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ToastService>();

builder.Services.AddRazorComponents();



// Bind the "ApiSettings" section from appsettings.json to ApiSettings class
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Register other services like ApiService, AuthService, etc.
builder.Services.AddHttpClient<ApiService>();
builder.Services.AddSingleton<ApiService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
