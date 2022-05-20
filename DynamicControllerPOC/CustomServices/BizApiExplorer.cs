using System.Collections.ObjectModel;
using System.Web.Http.Description;
//using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DynamicControllerPOC.CustomServices;

public class BizApiExplorer: IApiExplorer
{
    public BizApiExplorer()
    {
        Console.WriteLine("testr");
    }
    public Collection<ApiDescription> ApiDescriptions { get; }
}