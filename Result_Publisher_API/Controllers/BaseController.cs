using Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Result_Publisher_API.Controllers
{
    public class BaseController : ControllerBase
    {
       public IActionResult GetApiResponse<T>(Exception ex)
        {
            if(ex is ValidationErrorHandler<T> exception)
            {
                return StatusCode(400, exception.ValidationError());
            }
            return BadRequest(ex.Message);
        }
    }
}
