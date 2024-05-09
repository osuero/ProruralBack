using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Dtos;
using ProRualBackEnd.Dtos.project;
using Services.EntityInterfaces;
using Services.EntityServices;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper; // IMapper inyectado
        
        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null) return NotFound();

            var projectDto = _mapper.Map<ProjectReadDto>(project); // Mapeo a DTO

            return Ok(projectDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();

            var projectDtos = _mapper.Map<IEnumerable<ProjectReadDto>>(projects); // Mapeo a DTOs

            return Ok(projectDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectCreateDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _mapper.Map<Project>(projectDto);

            await _projectService.AddAsync(project);

            var projectReadDto = _mapper.Map<ProjectReadDto>(project);

            return CreatedAtAction(nameof(Get), new { id = projectReadDto.Id }, projectReadDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProjectUpdateDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _mapper.Map(projectDto, project); // Aplica los cambios del DTO a la entidad existente

            await _projectService.UpdateAsync(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("assign")]
        public async Task<IActionResult> AssignProjectToOrganization([FromBody] ProjectAssignDto assignDto)
        {
            if (string.IsNullOrEmpty(assignDto.ProjectId) || string.IsNullOrEmpty(assignDto.OrganizationId))
            {
                return BadRequest("OrganizationId and ProjectId are required.");
            }

            Guid projectId;
            Guid organizationId;

            if (!Guid.TryParse(assignDto.ProjectId, out projectId))
            {
                return BadRequest("Invalid ProjectId.");
            }

            if (!Guid.TryParse(assignDto.OrganizationId, out organizationId))
            {
                return BadRequest("Invalid OrganizationId.");
            }

            projectId = projectId == Guid.Empty ? Guid.Empty : projectId;
            organizationId = organizationId == Guid.Empty ? Guid.Empty : organizationId;

            try
            {
                await _projectService.UpdateOrganizationAndAssignProject(organizationId, projectId);
                return NoContent();  // Retorna un 204 No Content en caso de éxito
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}
