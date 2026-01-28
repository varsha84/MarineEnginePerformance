using EnginePerformance.Model;

namespace EnginePerformance.Interfaces
{
    public interface IEngineManager
    {
        Task<List<Engine>> GetAllEnginesAsync();
        Task<Engine?> GetEngineByIdAsync(int engineId);
        Task<Engine> CreateEngineAsync(Engine engine);
        Task<bool> DeleteEngineAsync(int engineId);
    }
}
