using Microsoft.AspNetCore.Mvc;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcvController : ControllerBase
    {
        private readonly IIcvService _icvService;

        public IcvController(IIcvService icvService)
        {
            _icvService = icvService;
        }

        [HttpGet]
        [Route("icvtypes")]
        public async Task<IActionResult> GetAllIcvTypes()
        {
            try
            {
                var icvTypes = await _icvService.GetAllIcvTypesAsync();
                return Ok(icvTypes);
            }
            catch (Exception ex)
            {
                // Log the exception details here as necessary
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
