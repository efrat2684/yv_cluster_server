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

        //TableGroupIdDetailsComponent שליפת נתונים לקומפוננטת     
        [Route("GetClusterGroupDetails/{groupId}")]
        [HttpGet]
        public ActionResult<ClusterGroupWithCrmLinks> GetClusterGroupDetails(int groupId)
        {
            //if (string.IsNullOrEmpty(groupId))
            //    return BadRequest("groupId is required");
            try
            {

                var result = _service.GetClusterGroupDetails(groupId);
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


        // POST: EnterBookIdOrClusterController/Create
        [Route("AddBookId")]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult<BookIdDetails> AddBookId(string bookId)
        {
            try
            {
                var result = _service.AddBookId(bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Route("AddBookIdsByClusterId")]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult<List<BookIdDetails>> AddBookIdsByClusterId(string clusterId)
        {
            try
            {
                var result = _service.AddBookIdsByClusterId(clusterId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("AddNewBookIdToExistCluster")]
        [HttpPost]
        public IActionResult AddNewBookIdToExistCluster([FromBody] string[] bookIds, [FromQuery] string clusterId)
        {
            try
            {
                _service.AddNewBookIdToExistCluster(bookIds,clusterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Route("GetCreateClusterData")]
        [HttpGet]
        public ActionResult<List<BookIdDetails>> GetCreateClusterData([FromQuery]List<string> bookIds)
        {
            try
            {
                var result = _service.GetCreateClusterData(bookIds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}