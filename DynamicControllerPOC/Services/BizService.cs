using DynamicControllerPOC.Core;

namespace DynamicControllerPOC.Services;

public class BizService : IBusinessService
{
    public ResponseModel Execute(RequestModel input)
    {
        return new ResponseModel()
        {
            IsSuccess = true,
            Result = "Resp:" + input.Request
        };
    }
}