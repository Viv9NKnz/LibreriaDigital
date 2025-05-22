using Microsoft.AspNetCore.Mvc;
using LibreriaDigital.Models;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewRepository _repository;

    public ReviewsController(IReviewRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var review = await _repository.GetById(id);
        return review == null ? NotFound() : Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Review review)
    {
        var created = await _repository.Add(review);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Review review)
    {
        if (id != review.Id) return BadRequest();
        return Ok(await _repository.Update(review));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return await _repository.Delete(id) ? NoContent() : NotFound();
    }
}
