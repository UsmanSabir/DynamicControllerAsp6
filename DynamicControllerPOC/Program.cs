using System.Reflection;
using DynamicControllerPOC.Controllers;
using DynamicControllerPOC.CustomServices;
using DynamicControllerPOC.Services;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.RegisterBusinessServices();

//var feature = new ControllerFeature();
//var closedControllerTypes = new List<TypeInfo>();
//closedControllerTypes.Add(typeof(BizService).GetTypeInfo());

//builder.Services.AddControllers()
//    .ConfigureApplicationPartManager(
//        manager =>
//        {
//            //manager.FeatureProviders.Add(new MyControllerFeatureProvider());
//            //manager.ApplicationParts.Add(new GenericControllerApplicationPart(closedControllerTypes));

//            manager.FeatureProviders.Add(new BusinessControllerFeatureProvider());
//        });

//.PartManager.PopulateFeature(feature);
//foreach (var featureController in feature.Controllers)
//{
//    builder.Services.TryAddTransient(featureController.AsType());
//}

//builder.Services.AddSingleton<IControllerActivator, MyControllerActivator>();
//builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, MyControllerActivator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
         c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
         c.DocumentFilter<MyDocumentFilter>();
         c.SchemaFilter<CustomSchemaFilter>(); // Register the custom schema filter
                                               // Register a custom implementation of IApiDescriptionGroupCollectionProvider
                                               //c.ServiceCollection.AddTransient<IApiDescriptionGroupCollectionProvider, MyApiDescriptionGroupCollectionProvider>();
         SwaggerConfig.ConfigureSwagger(c);    
});

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
