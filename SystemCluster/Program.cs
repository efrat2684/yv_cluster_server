
using Data.Repositories.Interfaces;
using Data.Repositories;
using Service.Services.Interfaces;
using Service.Services;
using Data.context;
using Microsoft.EntityFrameworkCore;

namespace SystemCluster
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // הוספת שירותי CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // הכתובת של ה-frontend שלך
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




            builder.Services.AddDbContext<SystemClusterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SystemClusterDb")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowFrontend");

            app.Run();
        }
    }
}
