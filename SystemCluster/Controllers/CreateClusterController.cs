using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace SystemCluster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateClusterController : Controller
    {
        private readonly ICreateClusterService _service;



        public CreateClusterController(ICreateClusterService service)
        {
            _service = service;
        }


        // GET: CreateClusterController
        [Route("GetCreateClusterData")]
        [HttpGet]
        public ActionResult<SapirClusterModel> GetCreateClusterData()
        {
            try
            {
                var result = _service.GetCreateClusterData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



      

        // POST: CreateClusterController/Create
        [Route("createNewCluster")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<SapirClusterModel> CreateNewCluster(SapirClusterModel sapirClusterModel)
        {
            try
            {
                var result= _service.CreateNewCluster(sapirClusterModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
