using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingMicroservice.Models;

namespace OrderProcessingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected IActionResult HttpMessage(string errorCode)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                ReasonPhrase = errorCode,
                StatusCode = HttpStatusCode.InternalServerError
            };

            return StatusCode((int)HttpStatusCode.InternalServerError, responseMessage);
        }

        protected IActionResult HttpMessage(string errorCode, ErrorResponse objResponse)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                ReasonPhrase = errorCode,
                StatusCode = HttpStatusCode.InternalServerError
            };
            objResponse.HttpResponseMsg = responseMessage;
            return StatusCode((int)HttpStatusCode.InternalServerError, objResponse);
        }
    }
}