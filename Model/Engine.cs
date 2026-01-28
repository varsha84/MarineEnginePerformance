namespace EnginePerformance.Model
{
    public class Engine
    {
        public int EngineId { get; set; }
        public string Name { get; set; }
        public int Cylinders { get; set; }
        public decimal Displacement { get; set; }
        public int MaxRPM { get; set; }
        public string FuelType { get; set; }
        public decimal BasePower { get; set; }
        public decimal BaseTorque { get; set; }

        public ICollection<EngineTestParameter> TestParameters { get; set; }
        public ICollection<TurboSelectionResult> TurboSelectionResults { get; set; }
    }
}
