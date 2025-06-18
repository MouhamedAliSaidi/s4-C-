using Microsoft.EntityFrameworkCore;
using LoginRegistrationProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Retrieve the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Entity Framework to use MySQL (Pomelo provider)
// AutoDetect will set the correct MySQL server version based on your connection string.
builder.Services.AddDbContext<MyContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure session with a 30-minute idle timeout.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Ensure session middleware is added

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();