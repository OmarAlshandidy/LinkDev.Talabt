using LinkDev.Talabat.Core.Domain.Contracts;

namespace LinkDev.Talabat.APIs.Extensions
{
    public static class InitialzierExtensions
    {
       public static async Task<WebApplication> InitalizeStoreContextAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var service = scope.ServiceProvider;
            var storeContextInitializer = service.GetRequiredService<IStoreContextInitializer>();
            // Ask Runtime Env For An Object From "storeContext  " Service Explicitly

            //var logger = service.GetRequiredService<ILogger<Program>>();
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();
            try
            {
                await storeContextInitializer.InitializeAsync();
                await storeContextInitializer.SeedAsync();


            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error has been occured during Applying the migrations And Seeding");
            }
            return app;

        }
    }
}
