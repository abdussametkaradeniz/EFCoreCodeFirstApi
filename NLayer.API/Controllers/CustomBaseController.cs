using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase {

        [NonAction] //swagger bunu endpoint olarak algılamasın diye bunu yazdık.
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204) //no content geriye bir şey dönme
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }
            return new ObjectResult(response)
            {
                StatusCode = response?.StatusCode,
            };
        }
    }
}
