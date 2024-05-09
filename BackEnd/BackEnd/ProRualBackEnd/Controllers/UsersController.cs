using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Dtos.User;
using Services.EntityInterfaces;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper; // Agrega el IMapper
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Username = await _userService.GenerateUniqueUsername(userDto.Name, userDto.LastName);

            string defaultPassword = "Minombre.1";
            user.PasswordHash = defaultPassword;

            var createdUser = await _userService.CreateAsync(user);
            if (createdUser == null)
            {
                return BadRequest("No se pudo crear el usuario.");
            }

            var userResponse = _mapper.Map<UserResponseDto>(createdUser);
            return CreatedAtAction(nameof(GetUserById), new { id = userResponse.Id }, userResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResponse = _mapper.Map<UserResponseDto>(user);

            return Ok(userResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var userResponses = _mapper.Map<IEnumerable<UserResponseDto>>(users);

            return Ok(userResponses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateDto userDto)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"No se encontró el usuario con ID {id}.");
            }

            _mapper.Map(userDto, user);

            try
            {
                await _userService.UpdateAsync(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al actualizar el usuario");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}