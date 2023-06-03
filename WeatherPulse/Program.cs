using Microsoft.EntityFrameworkCore;
using WeatherPulse.Data;
using WeatherPulse.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json", true);

var con = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDB")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWeatherForecast, WeatherForecast>();
builder.Services.AddScoped<IMessager, Messager>();

builder.Services.AddControllers();

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
