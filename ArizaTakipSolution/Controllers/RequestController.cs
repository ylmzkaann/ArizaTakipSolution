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
    public class RequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository<Request> _repository;

        public RequestController(AppDbContext context, IRepository<Request> repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestListDto>>> GetRequests()
        {
            var requests = await _repository.GetAllAsync();
            var response = requests.Adapt<IEnumerable<RequestListDto>>();
            return Ok(response);
        }

        // POST: api/request
        [HttpPost]
        public async Task<ActionResult<RequestListDto>> CreateRequest(RequestCreateDto dto)
        {
            var request = dto.Adapt<Request>();

            await _repository.AddAsync(request);
            await _repository.SaveChangesAsync();

            var result = request.Adapt<RequestListDto>();
            return CreatedAtAction(nameof(GetRequests), new { id = request.Id }, result);
        }

        // PUT: api/request/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, UpdateRequestStatusDto dto)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return NotFound();

            request.Status = dto.Status;
            _repository.Update(request);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/request/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return NotFound();

            _repository.Delete(request);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}