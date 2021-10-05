using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooksUdemy.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.2")]
    [ApiVersion("1.3")]
    [ApiVersion("1.4")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-data")]
        public IActionResult Get1()
        {
            return Ok("This is From V1");
        }
        [HttpGet("get-data"), MapToApiVersion("1.2")]
        public IActionResult GetV12()
        {
            return Ok("This is From V1.2");
        }
        [HttpGet("get-data"), MapToApiVersion("1.3")]
        public IActionResult Get13()
        {
            return Ok("This is From V1.3");
        }
        [HttpGet("get-data"), MapToApiVersion("1.4")]
        public IActionResult Get14()
        {
            return Ok("This is From V1.4");
        }
    }
}
