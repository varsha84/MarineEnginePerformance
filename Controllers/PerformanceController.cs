using EnginePerformance.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/performance")]
public class PerformanceController : ControllerBase
{
    private readonly IPerformanceManager _performanceManager;

    public PerformanceController(IPerformanceManager performanceManager)
    {
        _performanceManager = performanceManager;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate([FromBody] PerformanceRequest request)
    {
        var result = await _performanceManager.CalculatePerformanceAsync(
            request.EngineId,
            request.RPM,
            request.Load);

        return result == null
            ? NotFound("Engine not found")
            : Ok(result);
    }
}

public class PerformanceRequest
{
    public int EngineId { get; set; }
    public int RPM { get; set; }
    public decimal Load { get; set; }
}
