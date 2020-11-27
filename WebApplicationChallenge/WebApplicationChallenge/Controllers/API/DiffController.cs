using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Domain.Services.Communication;

namespace VincitWebApplication.Controllers
{
    /// <summary>
    /// API endpoints for api/diff
    /// </summary>
    [Route("api/diff")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public DiffController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/diff/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDifference(string id)
        {
            try{
                var difference = await _sensorService.GetDifferenceAsync(id);

                DiffResponse response = new DiffResponse("Success", difference);

                return Ok(response);
            }
            catch(InvalidOperationException )
            {
                // TODO log exception
                return NotFound(new DiffResponse(id));
            }
            catch(Exception)
            {
                //TODO log exception
                return StatusCode(500, new DiffResponse("Internal server error"));
            }
        }
    }
}
