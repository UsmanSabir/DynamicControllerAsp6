using System.Reflection;
using System.Text.Json;
using DynamicControllerPOC.CustomServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicControllerPOC.Core
{
    [Route("api/[controller]")]
    [ApiController]
    [BusinessControllerNameConvention]
    public class BusinessServiceHostController<T> : ControllerBase where T:IBusinessService
    {
        private T _instance;


        // POST api/<BusinessServiceHostController>
        public BusinessServiceHostController(T instance)
        {
            _instance = instance;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequestModel input)
        {
            var methodInfo = _instance.GetType().GetMethod(input.MethodName);
                //todo parameters
                object?[]? parm = input.Parameters?.Split("^::^");
                var response = methodInfo.Invoke(_instance, null);//parm
            var json = JsonSerializer.Serialize(response);
            var r = new ResponseModel()
            {
                IsSuccess = true,
                Result = json
            };
            return Ok(r);
        }
    }
}
