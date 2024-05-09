using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Dtos.Ruble;
using Data.Entities;
using AutoMapper;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionCategoryController : ControllerBase
    {
        private readonly IProductionCategoryService _productionCategoryService;
        private readonly IMapper _mapper;

        public ProductionCategoryController(IProductionCategoryService rubleService, IMapper mapper)
        {
            _productionCategoryService = rubleService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionCategoryDto>> GetRubleById(Guid id)
        {
            var ruble = await _productionCategoryService.GetProductionCategoryByIdAsync(id);
            if (ruble == null)
            {
                return NotFound();
            }

            var rubleDto = _mapper.Map<ProductionCategoryDto>(ruble);
            return Ok(rubleDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionCategoryDto>>> GetRubles()
        {
            var rubles = await _productionCategoryService.GetAllProductionCategoryAsync();
 
            var rubleDtos = _mapper.Map<IEnumerable<ProductionCategoryDto>>(rubles); // Map list of entities to list of DTOs
            return Ok(rubleDtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductionCategoryDto>> CreateRuble([FromBody] ProductionCategoryCreateDto rubleCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ruble = _mapper.Map<ProductionCategory>(rubleCreateDto);
            await _productionCategoryService.CreateProductionCategoryAsync(ruble);

            var rubleDto = _mapper.Map<ProductionCategoryDto>(ruble);
            return CreatedAtAction(nameof(GetRubleById), new { id = ruble.Id }, rubleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRuble(Guid id, [FromBody] ProductionCategoryDto rubleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rubleDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var ruble = await _productionCategoryService.GetProductionCategoryByIdAsync(id);
            if (ruble == null)
            {
                return NotFound();
            }

            _mapper.Map(rubleDto, ruble);
            await _productionCategoryService.UpdateProductionCategoryAsync(ruble);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuble(Guid id)
        {
            var ruble = await _productionCategoryService.GetProductionCategoryByIdAsync(id);
            if (ruble == null)
            {
                return NotFound();
            }

            await _productionCategoryService.DeleteProductionCategoryAsync(id);
            return NoContent();
        }
    }
}
