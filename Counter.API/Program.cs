using Microsoft.EntityFrameworkCore;
using Counter.DAL;
using Counter.Core.Interfaces;
using Counter.Core.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Counter");

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<CounterContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
 );
//
builder.Services.AddTransient<ICounterService, CounterService>();

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

ControllerActionEndpointConventionBuilder controllerActionEndpointConventionBuilder = app.MapControllers();

app.Run();
