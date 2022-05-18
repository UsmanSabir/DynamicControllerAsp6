using DynamicControllerPOC.CustomServices;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var feature = new ControllerFeature();
builder.Services.AddControllers().PartManager.PopulateFeature(feature);
foreach (var featureController in feature.Controllers)
{
    builder.Services.TryAddTransient(featureController.AsType());
}

builder.Services.AddSingleton<IControllerActivator, MyControllerActivator>();
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, MyControllerActivator>());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
