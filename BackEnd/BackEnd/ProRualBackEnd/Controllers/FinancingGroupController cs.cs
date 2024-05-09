using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancingGroupController : ControllerBase
    {
        private readonly IFinancingGroupService _financingGroupService;

        public FinancingGroupController(IFinancingGroupService financingGroupService)
        {
            _financingGroupService = financingGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFinancingGroup(FinancingGroup financingGroup)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _financingGroupService.AddFinancingGroupAsync(financingGroup);
            return CreatedAtAction(nameof(GetFinancingGroup), new { id = financingGroup.Id }, financingGroup);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancingGroup(Guid id)
        {
            var financingGroup = await _financingGroupService.GetFinancingGroupByIdAsync(id);
            if (financingGroup == null)
                return NotFound();

            return Ok(financingGroup);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinancingGroups()
        {
            var financingGroups = await _financingGroupService.GetAllFinancingGroupsAsync();
            return Ok(financingGroups);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFinancingGroup(Guid id, FinancingGroup financingGroup)
        {
            if (id != financingGroup.Id)
                return BadRequest("ID mismatch");

            var existingGroup = await _financingGroupService.GetFinancingGroupByIdAsync(id);
            if (existingGroup == null)
                return NotFound();

            await _financingGroupService.UpdateFinancingGroupAsync(financingGroup);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancingGroup(Guid id)
        {
            var financingGroup = await _financingGroupService.GetFinancingGroupByIdAsync(id);
            if (financingGroup == null)
                return NotFound();

            await _financingGroupService.DeleteFinancingGroupAsync(id);
            return NoContent();
        }
    }
}
