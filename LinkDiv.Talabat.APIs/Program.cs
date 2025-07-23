namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configure Service
            // Add services to the container.

            webApplicationBuilder.Services.AddControllers(); //Register Required Service By Asp.Net Core Web APIs To DI Container 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();

            #endregion
            var app = webApplicationBuilder.Build();
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
