namespace EnginePerformance.Model
{
    public class Turbocharger
    {
        public int TurboId { get; set; }
        public string Name { get; set; }
        public decimal MaxFlow { get; set; }
        public decimal PressureRatio { get; set; }

        public ICollection<TurboSelectionResult> TurboSelectionResults { get; set; }
    }
}
