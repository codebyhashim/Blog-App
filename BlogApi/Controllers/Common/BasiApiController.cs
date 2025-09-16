using System.Net;
using Application.model.ResponseWrapper;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.BlogConstants;

namespace BlogApi.Controllers.Common
{
    [Route("api/controller")]
    public abstract class BasiApiController : ControllerBase
    {
        [NonAction]
        public IActionResult HandleResponse(object response)
        {
            if (response != null)
            {
                if (response is ErrorResult result)
                {
                    var responseCode = result.Error[0];
                    return responseCode.StatusCode switch
                    {
                        CustomStatusCodes.BadRequest => BadRequest(response),
                        CustomStatusCodes.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                        CustomStatusCodes.Unauthorized => Unauthorized(response),
                        CustomStatusCodes.Forbidden => StatusCode((int)HttpStatusCode.Forbidden, response),
                        CustomStatusCodes.NotFound => NotFound(response),
                        _ => BadRequest(response),
                    };
                }
                else
                {
                    return Ok(response);
                }
            }
            return Ok(response);
        }
    }
}
