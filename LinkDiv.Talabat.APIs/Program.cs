using System.Threading.Tasks;
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
       
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configure Service
            // Add services to the container.

            webApplicationBuilder.Services.AddControllers(); //Register Required Service By Asp.Net Core Web APIs To DI Container 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();
            webApplicationBuilder.Services.AddPersistenceService(webApplicationBuilder.Configuration); //Register Required Service By Infrastructure Layer To DI Container

            #endregion

            var app = webApplicationBuilder.Build();

            #region Update Database and  Seed Data

            using var scope = app.Services.CreateAsyncScope();
            var service = scope.ServiceProvider;
            var dbContext = service.GetRequiredService<StoreContext>();
            // Ask Runtime Env For An Object From "storeContext  " Service Explicitly

            //var logger = service.GetRequiredService<ILogger<Program>>();
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();
            try
            {
                var pendingMigrations = dbContext.Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    // Apply any pending migrations to the database
                    await dbContext.Database.MigrateAsync();
                }
                await  StoreContextSeed.SeedAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error has been occured during Applying the migrations");
            } 
            #endregion

            #region Cofigure Kestrel MiddleWares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            

            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
