using Microsoft.EntityFrameworkCore;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Entity Framenwork
builder.Services.AddDbContext<PizzaStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
