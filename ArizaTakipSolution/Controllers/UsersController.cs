using ArizaTakip.Application.Dtos;
using ArizaTakip.Domain;
using ArizaTakip.Infrastructure;
using ArizaTakip.Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ArizaTakipSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _repository.GetAllAsync();
            var result = users.Adapt<IEnumerable<UserDto>>();
            return Ok(result);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var result = user.Adapt<UserDto>();
            return Ok(result);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserCreateDto dto)
        {
            var user = dto.Adapt<User>();

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            var result = user.Adapt<UserDto>();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, result);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            // dto'dan gelen değerleri mevcut entity'e uygula
            dto.Adapt(user);

            _repository.Update(user);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            _repository.Delete(user);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}