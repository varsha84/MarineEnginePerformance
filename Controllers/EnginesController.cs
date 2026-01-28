using EnginePerformance.Interfaces;
using EnginePerformance.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/engines")]
public class EnginesController : ControllerBase
{
    private readonly IEngineManager _engineManager;

    public EnginesController(IEngineManager engineManager)
    {
        _engineManager = engineManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _engineManager.GetAllEnginesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var engine = await _engineManager.GetEngineByIdAsync(id);
        return engine == null ? NotFound() : Ok(engine);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Engine engine)
    {
        var created = await _engineManager.CreateEngineAsync(engine);
        return CreatedAtAction(nameof(GetById), new { id = created.EngineId }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _engineManager.DeleteEngineAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
