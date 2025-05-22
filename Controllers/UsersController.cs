using Microsoft.AspNetCore.Mvc;
using LibreriaDigital.Models;
using LibreriaDigital.Repositories;

namespace LibreriaDigital.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase {
    private readonly IUserRepository _repo;
    public UsersController(IUserRepository repo) => _repo = repo;

    [HttpGet] public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _repo.GetByIdAsync(id));
    [HttpPost] public async Task<IActionResult> Post(User user) { await _repo.AddAsync(user); return Ok(); }
    [HttpPut("{id}")] public async Task<IActionResult> Put(int id, User user) {
      if (id != user.Id) return BadRequest();
      await _repo.UpdateAsync(user); return Ok();
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) {
      await _repo.DeleteAsync(id); return Ok();
    }
  }
}
