using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}
