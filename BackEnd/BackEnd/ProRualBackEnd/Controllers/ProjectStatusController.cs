using Microsoft.AspNetCore.Mvc;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController : Controller
    {
        private readonly IProjectStatusService _projectStatusService;

        public ProjectStatusController(IProjectStatusService projectStatusService)
        {
            _projectStatusService = projectStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var statuses = await _projectStatusService.GetAllProjectStatusesAsync();
            return View(statuses);
        }
    }
}
