using EnginePerformance.Data;
using EnginePerformance.Interfaces;
using EnginePerformance.Model;
using Microsoft.EntityFrameworkCore;

namespace EnginePerformance.Manager
{
    public class PerformanceManager : IPerformanceManager
    {
        private readonly EngineContext _context;

        public PerformanceManager(EngineContext context)
        {
            _context = context;
        }

        public async Task<TurboSelectionResult?> CalculatePerformanceAsync(
            int engineId,
            int rpm,
            decimal load)
        {
            var engine = await _context.Engines.FindAsync(engineId);
            if (engine == null)
                return null;

            // --- Example ENGINE PERFORMANCE LOGIC ---
            decimal normalizedLoad = load / 100m;
            decimal calculatedFlow = engine.BasePower * normalizedLoad;
            decimal calculatedPressure = (decimal)rpm / engine.MaxRPM * 3.0m;

            var turbo = await _context.Turbochargers
                .OrderBy(t => t.MaxFlow)
                .FirstOrDefaultAsync(t => t.MaxFlow >= calculatedFlow);

            var result = new TurboSelectionResult
            {
                EngineId = engine.EngineId,
                TurboId = turbo?.TurboId ?? 0,
                CalculatedFlow = calculatedFlow,
                CalculatedPressure = calculatedPressure,
                Timestamp = DateTime.UtcNow
            };

            _context.TurboSelectionResults.Add(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
