using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Dtos.Fund;
using Services.EntityInterfaces;
using Services.EntityServices;

namespace ProRualBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly IFundService _fundService;
        private readonly IMapper _mapper;

        public FundsController(IFundService fundService, IMapper mapper)
        {
            _fundService = fundService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fund = await _fundService.GetByIdAsync(id);
            if (fund == null) return NotFound();
            var fundDto = _mapper.Map<FundReadDto>(fund);
            return Ok(fundDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var funds = await _fundService.GetAllAsync();
            var fundDtos = _mapper.Map<IEnumerable<FundReadDto>>(funds);
            return Ok(fundDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FundCreateDto fundDto)
        {
            var fund = _mapper.Map<Fund>(fundDto);
            await _fundService.AddAsync(fund);
            var readDto = _mapper.Map<FundReadDto>(fund);
            return CreatedAtAction(nameof(Get), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FundCreateDto fundDto)
        {
            if (id == Guid.Empty || fundDto == null)
                return BadRequest("Invalid data");

            var existingFund = await _fundService.GetByIdAsync(id);
            if (existingFund == null) return NotFound();

            _mapper.Map(fundDto, existingFund);
            await _fundService.UpdateAsync(existingFund);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fund = await _fundService.GetByIdAsync(id);
            if (fund == null) return NotFound();

            await _fundService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ByProject/{projectId}")]
        public async Task<IActionResult> GetFundsByProjectId(Guid projectId)
        {
            var funds = await _fundService.GetFundsByProjectId(projectId);
            if (funds == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<FundReadDto>>(funds));
        }
    }
}