
using INDWalks.API.Data;
using INDWalks.API.Mapping;
using INDWalks.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace INDWalks.API
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
            builder.Services.AddDbContext<INDWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("INDWalksConnectionString")));

            builder.Services.AddScoped<IRegionRepository,SqlRegionRepository>();

            builder.Services.AddScoped<IWalksRepository, SqlWalksRepository>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
