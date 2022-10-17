// <copyright file="ConfigureDalServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.API.Configuration
{
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
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddDalServices();
            return services;
        }
    }
}
