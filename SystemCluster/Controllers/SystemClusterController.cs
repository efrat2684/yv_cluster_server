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
        //פונקצית נסיון לשליפת הודעה מתוך קובץ JSON
        [Route("test")]
        [HttpGet]
        public IActionResult GetWeather()
        {
            var msg = _service.GetMessageFromService();
            return Ok(new { message = msg });
        }
        //שליפת נתונים לקומפוננטת  TableGroupIdDetailsComponent
        [Route("GetClusterGroupDetails")]
        [HttpGet]
        public ActionResult<RootObjectOfClusterGroupDetails> GetClusterGroupDetails()
        {
            try
            {
                var result = _service.GetClusterGroupDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
