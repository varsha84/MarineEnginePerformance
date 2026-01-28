using EnginePerformance.Data;
using EnginePerformance.Interfaces;
using EnginePerformance.Model;
using Microsoft.EntityFrameworkCore;

namespace EnginePerformance.Manager
{
    public class EngineManager : IEngineManager
    {
        private readonly EngineContext _context;

        public EngineManager(EngineContext context)
        {
            _context = context;
        }

        public async Task<List<Engine>> GetAllEnginesAsync()
        {
            return await _context.Engines
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<Engine?> GetEngineByIdAsync(int engineId)
        {
            return await _context.Engines
                .FirstOrDefaultAsync(e => e.EngineId == engineId);
        }

        public async Task<Engine> CreateEngineAsync(Engine engine)
        {
            _context.Engines.Add(engine);
            await _context.SaveChangesAsync();
            return engine;
        }

        public async Task<bool> DeleteEngineAsync(int engineId)
        {
            var engine = await _context.Engines.FindAsync(engineId);
            if (engine == null)
                return false;

            _context.Engines.Remove(engine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
