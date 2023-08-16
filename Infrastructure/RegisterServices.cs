using Application.Context;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //register db
            services.AddDbContext<ResultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("dbConnection")));

            services.AddScoped<IResultDbContext, ResultDbContext>();
        }
    }
}
