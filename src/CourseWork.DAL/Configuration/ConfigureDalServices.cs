// <copyright file="ConfigureDalServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DAL.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Configure services from DAL.
    /// </summary>
    public static class ConfigureDalServices
    {
        /// <summary>
        /// Extension method for IServiceCollection to add dal services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>Added services.</returns>
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
