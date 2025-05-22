using Microsoft.AspNetCore.Mvc;
using LibreriaDigital.Models;
using LibreriaDigital.Repositories;

namespace LibreriaDigital.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase {
    private readonly IBookRepository _repo;
    public BooksController(IBookRepository repo) => _repo = repo;

    [HttpGet] public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _repo.GetByIdAsync(id));
    [HttpPost] public async Task<IActionResult> Post(Book book) { await _repo.AddAsync(book); return Ok(); }
    [HttpPut("{id}")] public async Task<IActionResult> Put(int id, Book book) {
      if (id != book.Id) return BadRequest();
      await _repo.UpdateAsync(book); return Ok();
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) {
      await _repo.DeleteAsync(id); return Ok();
    }
  }
}
