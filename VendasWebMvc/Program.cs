using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasWebMvc.Data;
using VendasWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("VendasWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("VendasWebMvcContext")),
    builder => builder.MigrationsAssembly("VendasWebMvc")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();

builder.Services.AddScoped<SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
