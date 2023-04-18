using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WYMS_Zaliczenie_API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase {


        private readonly ILogger<WorkersController> _logger;

        public WorkersController (ILogger<WorkersController> logger) {
            _logger = logger;
        }

        [HttpGet(Name = "GetWorker")]
        public async Task<ActionResult<WebResponse>> Get() {
            return Ok();
        }
    }
}