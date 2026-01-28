using EnginePerformance.Model;

namespace EnginePerformance.Interfaces
{
    public interface IPerformanceManager
    {
        Task<TurboSelectionResult?> CalculatePerformanceAsync(
        int engineId,
        int rpm,
        decimal load);

    }
}
