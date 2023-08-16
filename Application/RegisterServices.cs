using Application.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class RegisterServices
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidatorBehavior<,>));
        }
    }
}
