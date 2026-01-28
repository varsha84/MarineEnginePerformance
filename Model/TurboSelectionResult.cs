namespace EnginePerformance.Model
{
    public class TurboSelectionResult
    {
        public int ResultId { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int TurboId { get; set; }
        public Turbocharger Turbocharger { get; set; }
        public decimal CalculatedFlow { get; set; }
        public decimal CalculatedPressure { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
