using Microsoft.AspNetCore.Mvc;
using Services.GeographicalInterface;
using Services.GeographicalsServices;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeographicController : ControllerBase
    {
        private readonly IGeographicalService _geographicalService;

        public GeographicController(IGeographicalService geographicalService)
        {
            _geographicalService = geographicalService;
        }

        // GET: api/Geographic
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _geographicalService.GetAllRegionsAsync();
            if (regions == null)
            {
                return NotFound();
            }
            return Ok(regions);
        }
    }
}
