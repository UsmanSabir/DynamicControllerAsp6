using DynamicControllerPOC.Core;

namespace DynamicControllerPOC.Services;

public class BizService : SomeOtherInterface, IContractService
{
    public string Execute()
    {
        return $"Resp: 5";
    }
}

public interface SomeOtherInterface
{
    string Execute();
}