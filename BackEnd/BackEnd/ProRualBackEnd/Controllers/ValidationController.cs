using Microsoft.AspNetCore.Mvc;
using Services.ValidationInterfaces;
using Services.ValidationServices;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly IidentificaciontService _identificationService;

        public ValidationController(IidentificaciontService identificationService)
        {
            _identificationService = identificationService;
        }

        [HttpGet("validate/{id}")]
        public async Task<IActionResult> ValidateIdentification(string id)
        {
            bool isValid = await _identificationService.ValidateIdentification(id);
            return Ok(new { isValid = isValid });
        }
    }
}
