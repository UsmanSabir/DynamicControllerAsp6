namespace DynamicControllerPOC.Core;

public interface IBusinessService
{
    ResponseModel Execute(RequestModel input);
}