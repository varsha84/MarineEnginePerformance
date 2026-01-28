namespace EnginePerformance.Model
{
    public class EngineTestParameter
    {
        public int Id { get; set; }
        public int EngineId { get; set; }  // FK to Engine
        public int TestRPM { get; set; }
        public double LoadPercentage { get; set; }
        public double FuelConsumption { get; set; }
        public double ExhaustTemp { get; set; }  // <-- Add this
        public Engine Engine { get; set; } = null!;
    }
}
