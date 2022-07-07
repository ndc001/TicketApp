using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

namespace API
{
    public static class Application_Service
    {
        public static IServiceCollection Configure_Application_Services(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}