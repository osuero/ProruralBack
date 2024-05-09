using Microsoft.AspNetCore.Mvc;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProjectTypeController : ControllerBase
    {
        private readonly IProjectTypeService _projectTypeService;

        public ProjectTypeController(IProjectTypeService projectTypeService)
        {
            _projectTypeService = projectTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projectTypes = await _projectTypeService.GetAllProjectTypesAsync();
                return Ok(projectTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
