using EnginePerformance.Data;
using EnginePerformance.Model;
using Microsoft.EntityFrameworkCore;

namespace EnginePerformance.Data
{
    public static class SeedData
    {
        public static void Initialize(EngineContext context)
        {
            // Ensure database exists (safe for LocalDB / demo projects)
            //context.Database.EnsureCreated();
            context.Database.Migrate();
            // ------------------------
            // ENGINES
            // ------------------------
            if (!context.Engines.Any())
            {
                context.Engines.AddRange(
                    new Engine
                    {
                        Name = "ME-C 6S60",
                        Cylinders = 6,
                        Displacement = 12.5m,
                        MaxRPM = 1000,
                        FuelType = "Diesel",
                        BasePower = 5000m,
                        BaseTorque = 25000m
                    },
                    new Engine
                    {
                        Name = "ME-C 8S70",
                        Cylinders = 8,
                        Displacement = 16.0m,
                        MaxRPM = 900,
                        FuelType = "Diesel",
                        BasePower = 7200m,
                        BaseTorque = 36000m
                    }
                );

                context.SaveChanges();
            }

            // ------------------------
            // TURBOCHARGERS
            // ------------------------
            if (!context.Turbochargers.Any())
            {
                context.Turbochargers.AddRange(
                    new Turbocharger
                    {
                        Name = "TCR18",
                        MaxFlow = 4500m,
                        PressureRatio = 2.0m
                    },
                    new Turbocharger
                    {
                        Name = "TCR20",
                        MaxFlow = 7000m,
                        PressureRatio = 2.5m
                    }
                );

                context.SaveChanges();
            }

            // ------------------------
            // ENGINE TEST PARAMETERS
            // ------------------------
            if (!context.EngineTestParameters.Any())
            {
                context.EngineTestParameters.AddRange(
                    new EngineTestParameter
                    {
                        EngineId = context.Engines.First().EngineId,
                        TestRPM = 800,
                        LoadPercentage = 50,
                        FuelConsumption = 1200,
                        ExhaustTemp = 450
                    },
                    new EngineTestParameter
                    {
                        EngineId = context.Engines.Skip(1).First().EngineId,
                        TestRPM = 850,
                        LoadPercentage = 75,
                        FuelConsumption = 1500,
                        ExhaustTemp = 480
                    }
                );

                context.SaveChanges();
            }

            // ------------------------
            // TURBO SELECTION RESULTS
            // ------------------------
            if (!context.TurboSelectionResults.Any())
            {
                var engine1 = context.Engines.First();
                var turbo1 = context.Turbochargers.First();

                context.TurboSelectionResults.Add(
                    new TurboSelectionResult
                    {
                        EngineId = engine1.EngineId,
                        TurboId = turbo1.TurboId,
                        CalculatedFlow = 4200m,
                        CalculatedPressure = 1.9m,
                        Timestamp = DateTime.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
