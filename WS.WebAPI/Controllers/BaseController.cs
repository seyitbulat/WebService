using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace WS.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public async Task<IActionResult> SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == 204)
                return  new ObjectResult(null) { StatusCode = 204 };

            return  new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
