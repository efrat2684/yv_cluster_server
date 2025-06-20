﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;

namespace SystemCluster.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AddBookIdOrClusterController : Controller
    {
        private readonly IAddBookIdOrClusterService _service;

        public AddBookIdOrClusterController(IAddBookIdOrClusterService service)
        {
            _service = service;
        }




        // POST: EnterBookIdOrClusterController/Create
        [Route("AddBookId")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<RootObject> AddBookId([FromBody]string bookId)
        {
            try
            {
                var result= _service.AddBookId(bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Route("AddBookIdsByClusterId")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<RootObject> AddBookIdsByClusterId([FromBody] string clusterId)
        {
            try
            {
                var result = _service.AddBookId(clusterId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
