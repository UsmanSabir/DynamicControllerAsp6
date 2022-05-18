using DynamicControllerPOC.Core;

namespace DynamicControllerPOC.Services;

public class BizService : IBusinessService
{
    public string Execute()
    {
        return $"Resp: 5";
    }
}