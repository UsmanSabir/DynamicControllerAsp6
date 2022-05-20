using DynamicControllerPOC.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DynamicControllerPOC.Services;

public class BizService : IBusinessService
{
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

    public BizService(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    }

    public string Execute()
    {
        //_actionDescriptorCollectionProvider.
        return $"Resp: 5";
    }
}