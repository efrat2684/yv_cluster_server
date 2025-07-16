
using Data.Repositories.Interfaces;
using Data.Repositories;
using Service.Services.Interfaces;
using Service.Services;

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
                        policy.WithOrigins("http://localhost:60530") // הכתובת של ה-frontend שלך
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
            builder.Services.AddScoped<IAutoclusterService, AutoClusterService>();
            builder.Services.AddScoped<IAutoClusterRepository, AutoClusterRepository>();
            builder.Services.AddScoped<IConnectionFactory, SqlConnectionFactory>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           

            app.UseCors("AllowAngularApp");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowFrontend");

            app.Run();
        }
    }
}
