// <copyright file="ConfigureApiServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Configuration
{
    using CourseWork.DistributionAPI.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using RestEase;

    /// <summary>
    /// Configure services from API.
    /// </summary>
    public static class ConfigureApiServices
    {
        /// <summary>
        /// Extension method for IServiceCollection to add API services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>Added services.</returns>
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped(scope =>
            {
                var baseUrl = configuration["ComputingApiAddress"];
                return RestClient.For<IComputingHttpClient>(baseUrl);
            });
            return services;
        }
    }
}
