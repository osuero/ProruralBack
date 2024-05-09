using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Dtos.Organization;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;
        private IBeneficiaryService _bioService;
        public OrganizationController(IOrganizationService organizationService,IBeneficiaryService beneficiaryService, IMapper mapper)
        {
            _organizationService = organizationService;
          
            //  _bioService = beneficiaryService
            
            
            _mapper = mapper;
        }

        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationReadDto>>> GetAllOrganizations()
        {
            var organizations = await _organizationService.GetAllAsync();
            var organizationDtos = _mapper.Map<IEnumerable<OrganizationReadDto>>(organizations);
            return Ok(organizationDtos);
        }

        // GET: api/Organization/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationReadDto>> GetOrganization(Guid id)
        {
            var organization = await _organizationService.GetByIdAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            var organizationDto = _mapper.Map<OrganizationReadDto>(organization);
            return Ok(organizationDto);
        }

        // POST: api/Organization
        [HttpPost]
        public async Task<ActionResult<OrganizationReadDto>> CreateOrganization(OrganizationCreateDto createDto)
        {
            var organization = _mapper.Map<Organization>(createDto);
            await _organizationService.AddAsync(organization);

           
           // _bioService.AssociateWithOrganizationAsync()

            var organizationReadDto = _mapper.Map<OrganizationReadDto>(organization);



            return CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organizationReadDto);
        }

        // PUT: api/Organization/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(Guid id, OrganizationUpdateDto updateDto)
        {
            var organization = await _organizationService.GetByIdAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, organization);
            await _organizationService.UpdateAsync(organization);

            return NoContent();
        }

        // DELETE: api/Organization/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            await _organizationService.DeleteAsync(id);
            return NoContent();
        }
    }

}
