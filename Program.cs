using Microsoft.EntityFrameworkCore;
using Shopikai.Data;
using ShopApp.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// TODO: Update pages with new fields
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShopikaiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ShopikaiContext") ?? throw new InvalidOperationException("Connection string 'ShopikaiContext' not found.")));


var app = builder.Build();

// Seed Initial Data 
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  var context = services.GetRequiredService<ShopikaiContext>();
  context.Database.EnsureCreated();

  // This is to initialize dummy data. 
  // SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
