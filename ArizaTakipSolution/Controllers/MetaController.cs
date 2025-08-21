using Microsoft.AspNetCore.Mvc;
using ArizaTakip.Domain;
using System.Linq;

namespace ArizaTakipSolution.Controllers
{
    [ApiController]
    [Route("api/meta")]
    public class MetaController : ControllerBase
    {
        // GET: /api/meta/request-status
        [HttpGet("request-status")]
        public IActionResult GetRequestStatuses()
        {
            var list = System.Enum.GetValues(typeof(RequestStatus))
                .Cast<RequestStatus>()
                .Select(e => new
                {
                    value = (int)e,
                    name = e.ToString()
                })
                .ToList();

            return Ok(list);
        }

        // GET: /api/meta/request-types
        [HttpGet("request-types")]
        public IActionResult GetRequestTypes()
        {
            var list = System.Enum.GetValues(typeof(RequestType))
                .Cast<RequestType>()
                .Select(e => new
                {
                    value = (int)e,
                    name = e.ToString()
                })
                .ToList();

            return Ok(list);
        }
    }
}