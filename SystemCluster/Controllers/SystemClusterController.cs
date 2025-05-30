using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Service.Services.Interfaces;

namespace SystemCluster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemClusterController : Controller
    {
       
        private readonly ISystemClusterService _service;

        public SystemClusterController(ISystemClusterService service)
        {
            _service = service;
        }
        [Route("test")]
        [HttpGet]
        public IActionResult GetWeather()
        {
            var msg = _service.GetMessageFromService();
            return Ok(new { message = msg });
        }
        [Route("GetClusterGroupDetails")]
        [HttpGet]
        public ActionResult<RootObjectOfClusterGroupDetails> GetClusterGroupDetailsFromJson()
        {
            try
            {
                var result = _service.GetClusterGroupDetailsFromJson();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
