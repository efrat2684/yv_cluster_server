using Data.Models;
using Data.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Services.Interfaces;

namespace SystemCluster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoClusterController : ControllerBase
    {
        private readonly IAutoclusterService _autoclusterService;

        public AutoClusterController(IAutoclusterService autoclusterService)
        {
            _autoclusterService = autoclusterService;
        }

        [HttpGet("/SapirClusters")]
        public ChunkResult<SapirClusterTab> GetSapirClusters([FromQuery] int chunk = 0)
        {
            return _autoclusterService.GetSapirClusters(chunk);
        }
        [HttpGet("/MissingFields")]
        public IActionResult GetMissingFields([FromQuery] int chunk = 0)
        {
            var result = _autoclusterService.GetMissingFields(chunk);
            return Ok(result);
        }
        [HttpGet("/ApprovalGroups")]
        public IActionResult GetApprovalGroups([FromQuery] int chunk = 0)
        {
            var result = _autoclusterService.GetApprovalGroups(chunk);
            return Ok(result);
        }

        [HttpGet("/DifferentClusters")]
        public IActionResult GetDifferentClusters([FromQuery] int chunk = 0)
        {
            var result = _autoclusterService.GetDifferentClusters(chunk);
            return Ok(result);
        }
        [HttpGet("/CheckListsItems")]
        public IActionResult GetCheckListItems([FromQuery] int chunk = 0)
        {
            var result = _autoclusterService.GetCheckListItems(chunk);
            return Ok(result);
        }
        [HttpGet("/ErrorMessages")]
        public IActionResult GetErrorMessages([FromQuery] int chunk = 0)
        {
            var result = _autoclusterService.GetErrorMessages(chunk);
            return Ok(result);
        }
        [HttpPatch("/updateAssygnee")]
        public void updateAssygnee([FromQuery] int clusterId, [FromQuery] int assygneeId, [FromQuery]string tableName)
        {
            _autoclusterService.updateAssignee(clusterId, assygneeId, tableName);
        }
        [HttpPatch("/updateStatus")]
        public void updateStatus([FromQuery] int clusterId, [FromQuery] string tableName)
        {
            _autoclusterService.updateStatus(clusterId, tableName);
        }


    }
}
