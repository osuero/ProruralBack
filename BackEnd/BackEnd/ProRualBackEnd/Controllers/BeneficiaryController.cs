namespace ProRualBackEnd.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Services.EntityInterfaces;
    using Data.Entities;
    using ProRualBackEnd.Dtos.Beneficiary;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ProRualBackEnd.Dtos;

    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryService _beneficiaryService;
        private readonly IMapper _mapper;

        public BeneficiaryController(IBeneficiaryService beneficiaryService, IMapper mapper)
        {
            _beneficiaryService = beneficiaryService;
            _mapper = mapper;
        }

        // GET: api/Beneficiary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficiaryReadDto>>> GetAllBeneficiaries()
        {
            var beneficiaries = await _beneficiaryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BeneficiaryReadDto>>(beneficiaries));
        }

        [HttpGet("GetNotAssigned")]
        public async Task<ActionResult<IEnumerable<BeneficiaryReadDto>>> GetNotAssignedBeneficiaries()
        {
            var beneficiaries = await _beneficiaryService.GetNotAssigned();
            return Ok(_mapper.Map<IEnumerable<BeneficiaryReadDto>>(beneficiaries));
        }

        // GET: api/Beneficiary/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiaryReadDto>> GetBeneficiary(Guid id)
        {
            var beneficiary = await _beneficiaryService.GetByIdAsync(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return _mapper.Map<BeneficiaryReadDto>(beneficiary);
        }

        // POST: api/Beneficiary
        [HttpPost]
        public async Task<ActionResult<BeneficiaryReadDto>> CreateBeneficiary(BeneficiaryCreateDto createDto)
        {
            var beneficiary = _mapper.Map<Beneficiary>(createDto);
            await _beneficiaryService.AddAsync(beneficiary);

            var beneficiaryReadDto = _mapper.Map<BeneficiaryReadDto>(beneficiary);
            return CreatedAtAction(nameof(GetBeneficiary), new { id = beneficiaryReadDto.Id }, beneficiaryReadDto);
        }

        // PUT: api/Beneficiary/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeneficiary(Guid id, BeneficiaryUpdateDto updateDto)
        {
            var beneficiaryFromRepo = await _beneficiaryService.GetByIdAsync(id);
            if (beneficiaryFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, beneficiaryFromRepo);
            await _beneficiaryService.UpdateAsync(beneficiaryFromRepo);

            return NoContent();
        }

        [HttpPost("associate-organization")]
        public async Task<IActionResult> AssociateWithOrganization(AssociateRequest request)
        {
            if (request.BeneficiaryIds == null || !request.BeneficiaryIds.Any() || request.OrganizationId == Guid.Empty)
            {
                return BadRequest("Invalid data provided.");
            }

            await _beneficiaryService.AssociateWithOrganizationAsync(request.BeneficiaryIds, request.OrganizationId);
            return Ok();
        }


        [HttpPost("remove-organization")]
        public async Task<IActionResult> RemoveOrganization(AssociateRequest request)
        {
            if (request.BeneficiaryIds == null || !request.BeneficiaryIds.Any() || request.OrganizationId == Guid.Empty)
            {
                return BadRequest("Invalid data provided.");
            }

            await _beneficiaryService.RemoveOrganizationAsync(request.BeneficiaryIds, Guid.Empty);
            return Ok();
        }

        // DELETE: api/Beneficiary/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiary(Guid id)
        {
            await _beneficiaryService.DeleteAsync(id);
            return NoContent();
        }
    }

}
