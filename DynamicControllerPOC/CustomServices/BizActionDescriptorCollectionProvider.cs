using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Primitives;

namespace DynamicControllerPOC.CustomServices;

public class BizActionDescriptorCollectionProvider: ActionDescriptorCollectionProvider
{
    public override IChangeToken GetChangeToken()
    {
        throw new NotImplementedException();
    }

    public override ActionDescriptorCollection ActionDescriptors
    {
        get
        {
            return null;
        }
    }
}