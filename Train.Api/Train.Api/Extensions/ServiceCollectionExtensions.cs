using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Train.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void WithMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Train.Services");
            services.AddMediatR(assembly);
        }
    }
}
