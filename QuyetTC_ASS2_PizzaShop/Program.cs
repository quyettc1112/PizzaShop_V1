using Microsoft.EntityFrameworkCore;
using PizzaShopDomain.Implementations;
using PizzaShopDomain.Models;
using PizzaShopDomain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Entity Framenwork
builder.Services.AddDbContext<PizzaStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopConnection")));
builder.Services.AddTransient<UnitOfWork, UnitOfWork>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

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

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
