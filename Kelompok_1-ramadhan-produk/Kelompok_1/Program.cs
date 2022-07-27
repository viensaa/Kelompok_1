using Kelompok_1.Data;
using Kelompok_1.Data.DAL;
using Kelompok_1.Data.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//menambahkan konfigurasi EF
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EcommerceConnection")).EnableSensitiveDataLogging());

//menambahkan automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//inject class DAL
builder.Services.AddScoped<IKategori, KategoriDAL>();
builder.Services.AddScoped<IProduk, ProdukDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
