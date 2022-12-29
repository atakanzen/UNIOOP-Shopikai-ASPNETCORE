using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using ShopApp.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesReceiptContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesReceiptContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesReceiptContext' not found.")));
builder.Services.AddDbContext<RazorPagesOrderContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesOrderContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesOrderContext' not found.")));
builder.Services.AddDbContext<RazorPagesCategoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesCategoryContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesCategoryContext' not found.")));
builder.Services.AddDbContext<RazorPagesProductContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesProductContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesProductContext' not found.")));

var app = builder.Build();

// Seed Initial Data 
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  SeedData.Initialize(services);
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
