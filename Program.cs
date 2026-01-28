
using EnginePerformance.Data;
using EnginePerformance.Interfaces;
using EnginePerformance.Manager;
using Microsoft.EntityFrameworkCore;

namespace EnginePerformance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // ?? 2. Add DbContext
            builder.Services.AddDbContext<EngineContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // ?? 3. REGISTER YOUR MANAGERS HERE ???
            builder.Services.AddScoped<IEngineManager, EngineManager>();
            builder.Services.AddScoped<IPerformanceManager, PerformanceManager>();
            var app = builder.Build();
            // Seed data
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EngineContext>();
                SeedData.Initialize(context);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
