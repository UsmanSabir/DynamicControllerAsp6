using Swashbuckle.AspNetCore.SwaggerGen;

namespace DynamicControllerPOC.CustomServices
{
    public class SwaggerConfig
    {
        public static void ConfigureSwagger(SwaggerGenOptions options)
        {
            //var customModelSchema = new OpenApiDocument
            //{
            //    Components = new OpenApiComponents
            //    {
            //        Schemas =
            //        {
            //            { "CustomModel", new OpenApiSchema { Type = "object", Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "CustomModel" } } }
            //        }
            //    }
            //};

            //options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //options.SchemaFilter<CustomModelSchemaFilter>();
            //options.IncludeXmlComments("<path to your XML documentation file>");
            options.DocumentFilter<CustomDocumentFilter>();
        }
    }
}
