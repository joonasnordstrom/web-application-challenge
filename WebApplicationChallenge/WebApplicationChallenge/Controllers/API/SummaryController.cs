using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VincitWebApplication.Domain.Services;
using VincitWebApplication.Domain.Services.Communication;
using VincitWebApplication.DTOs;

namespace VincitWebApplication.Controllers
{
    /// <summary>
    /// API endpoints for api/summary
    /// </summary>
    [Route("api/summary")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SummaryController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/summary
        [HttpGet]
        [ProducesResponseType(typeof(List<SummaryDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSummary()
        {
            try
            {
                SummaryResponse response;
                var sensors = await _sensorService.GetSummaryAsync();

                response = new SummaryResponse("Success", sensors);

                return Ok(response);
            }
            catch (Exception )
            {
                //TODO log exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
