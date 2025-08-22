using System.Threading.Tasks;
using LinkDev.Talabat.APIs.Extensions;
using LinkDev.Talabat.APIs.Services;
using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkDev.Talabat.Core.Application;
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
            webApplicationBuilder.Services.AddHttpContextAccessor(); //Register Required Service By Asp.Net Core Web APIs To DI Container
            webApplicationBuilder.Services.AddScoped(typeof(ILoggedInUserService), typeof(LoggedInUserService));

            webApplicationBuilder.Services.AddPersistenceService(webApplicationBuilder.Configuration); //Register Required Service By Infrastructure Layer To DI Container
            webApplicationBuilder.Services.AddApplicationServices(); //Register Required Service By Application Layer To DI Container

            #endregion

            var app = webApplicationBuilder.Build();

            #region Database  Initialization 

            await app.InitalizeStoreContextAsync();
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
