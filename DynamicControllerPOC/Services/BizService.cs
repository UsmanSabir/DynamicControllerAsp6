using DynamicControllerPOC.Core;

namespace DynamicControllerPOC.Services;

public class BizService : IContractService
{
    public string Execute()
    {
        return $"Resp: 5";
    }
}