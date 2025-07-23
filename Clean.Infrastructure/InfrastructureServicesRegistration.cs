using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServices(this IServiceCollection services,
       IConfiguration configuration)
        {

            //services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
