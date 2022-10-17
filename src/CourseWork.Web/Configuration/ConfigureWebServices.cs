// <copyright file="ConfigureWebServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Configure services from Web.
    /// </summary>
    public static class ConfigureWebServices
    {
        /// <summary>
        /// Extension method for IServiceCollection to add web services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>Added services.</returns>
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            return services;
        }
    }
}
