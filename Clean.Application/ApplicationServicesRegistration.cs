﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clean.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //// MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
