using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Downloads.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure authentication services
builder.Services.AddDbContext<NotForzaContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Specify the path to your login page
        options.AccessDeniedPath = "/error"; // Specify the path for access denied
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Set cookie expiration
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // This must come before UseAuthorization
app.UseAuthorization();

app.MapRazorPages();

app.Run();