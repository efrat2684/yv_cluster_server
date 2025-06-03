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
        //JSON פונקצית נסיון לשליפת הודעה מתוך קובץ 
        [Route("test")]
        [HttpGet]
        public IActionResult GetWeather()
        {
            var msg = _service.GetMessageFromService();
            return Ok(new { message = msg });
        }

        //TableGroupIdDetailsComponent שליפת נתונים לקומפוננטת     
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
        //PieComponentDistributionModalComponent שליפת נתונים לקומפוננטת     
        [Route("GetStatisticData")]
        [HttpGet]
        public ActionResult<StatisticData> GetStatisticData()
        {
            try
            {
                var result = _service.GetStatisticData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
