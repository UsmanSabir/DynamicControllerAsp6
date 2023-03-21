using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DynamicControllerPOC.CustomServices
{

    public class MyDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Dynamically generate controllers here
            //var dynamicControllers = GetDynamicControllers();

            // Add dynamically generated controllers to Swagger specification
            //foreach (var controller in dynamicControllers)
            {
                var controllerType = "DynaController";// controller.GetType();
                var controllerName = "DynaController";// controllerType.Name.Replace("Controller", "");
                var controllerPath = $"/api/{controllerName}";

                var operation = new OpenApiOperation
                {
                    Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Custom123" } },
                    Summary = "Custom operation summary",
                    Description = "Custom operation description",
                    OperationId = "CustomOperation",
                    Parameters = new List<OpenApiParameter> {
                        new OpenApiParameter
                        {
                            Name = "param",
                            In = ParameterLocation.Path,
                            Description = "Custom parameter description",
                            Required = true,
                            Schema = new OpenApiSchema
                            {
                                Type = "string",
                                Default = new OpenApiString("default value")
                            }
                        }
                    },
                    Responses = new OpenApiResponses
                    {
                        { "200", new OpenApiResponse { Description = "OK" } }
                    }
                };
                var operations = new OpenApiOperation[]
                {
                    // Add your OpenAPI operations here
                    operation
                };

                swaggerDoc.Paths[controllerPath] = new OpenApiPathItem
                {
                    Operations = new Dictionary<OperationType, OpenApiOperation>()
                    {
                        { OperationType.Get, operations[0] },
                        //{ OperationType.Post, operations[1] },
                        //{ OperationType.Put, operations[2] },
                        //{ OperationType.Delete, operations[3] }
                    }
                };
            }
        }

        //public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        //{
        //    throw new NotImplementedException();
        //}

        //private IEnumerable<object> GetDynamicControllers()
        //{
        //    // Implement your logic to dynamically generate controllers here
        //    // Return a list of dynamically generated controllers
        //}
    }

    public class CustomSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // Only apply the filter to the specified type
            if (context.Type == typeof(WeatherForecast))
            {
                schema.Description = "Custom model description";
                schema.Type = "object";

                // Add properties to the model
                schema.Properties.Add("Property1", new OpenApiSchema
                {
                    Description = "Property 1 description",
                    Type = "string"
                });
                schema.Properties.Add("Property2", new OpenApiSchema
                {
                    Description = "Property 2 description",
                    Type = "integer"
                });
            }
        }
    }

    public class CustomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomModelSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CustomModel))
            {
                schema.Type = "object";
                schema.Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "id", new OpenApiSchema { Type = "integer" } },
                    { "name", new OpenApiSchema { Type = "string" } }
                };
            }
        }
    }

    public class CustomDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Add("CustomModel", new OpenApiSchema
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "id", new OpenApiSchema { Type = "integer" } },
                    { "name", new OpenApiSchema { Type = "string" } }
                }
            });
        }
    }
}
