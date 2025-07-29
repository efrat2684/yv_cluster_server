
using Data.Repositories.Interfaces;
using Data.Repositories;
using Service.Services.Interfaces;
using Service.Services;
using Microsoft.EntityFrameworkCore;

namespace SystemCluster
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // ������ �� �-frontend ���
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ISystemClusterService, SystemClusterService>();
            builder.Services.AddScoped<ISystemClusterRepository, SystemClusterRepository>();
            builder.Services.AddScoped<ICreateClusterService, CreateClusterService>();
            builder.Services.AddScoped<ICreateClusterRepository, CreateClusterRepository>();



            builder.Services.AddScoped<IAutoclusterService, AutoClusterService>();
            builder.Services.AddScoped<IAutoClusterRepository, AutoClusterRepository>();
            builder.Services.AddScoped<IConnectionFactory, SqlConnectionFactory>();



            ////builder.Services.AddCors(options =>
            ////{
            ////    options.AddDefaultPolicy(policy =>
            ////    {
            ////        policy.WithOrigins("http://localhost:52748")
            ////              .AllowAnyHeader()
            ////              .AllowAnyMethod();
            ////    });
            ////});


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
<<<<<<< HEAD
            //app.UseCors();
=======
           
>>>>>>> origin/main

            app.UseCors("AllowAngularApp");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowFrontend");

            app.Run();
        }
    }
}
