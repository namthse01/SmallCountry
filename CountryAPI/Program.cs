using CountryAPI.IRepository;
using CountryAPI.IService;
using CountryAPI.Models;
using CountryAPI.Repository;
using CountryAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Service:
//Town
builder.Services.AddScoped<ITownRepository, TownRepository>();
builder.Services.AddScoped<ITownService, TownService>();
//Commune
builder.Services.AddScoped<ICommuneRepository, CommnuneRepository>();
builder.Services.AddScoped<ICommnuneService, CommuneService>();
//District
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();

//City
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

//Country
builder.Services.AddScoped<ICountryService, CountryService>();

//Connect to DB:
builder.Services.AddDbContext<CountryApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryAPI")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
