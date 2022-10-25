// <copyright file="ConfigureApiServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Configuration
{
    using CourseWork.DAL.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDalServices();
            services.AddControllers();
            return services;
        }
    }
}
