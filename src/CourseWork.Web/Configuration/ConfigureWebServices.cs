﻿// <copyright file="ConfigureWebServices.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Configuration
{
    using CourseWork.Models;
    using CourseWork.Web.Interfaces;
    using CourseWork.Web.Services;
    using Microsoft.Extensions.DependencyInjection;
    using RestEase;

    /// <summary>
    /// Configure services from Web.
    /// </summary>
    public static class ConfigureWebServices
    {
        /// <summary>
        /// Extension method for IServiceCollection to add web services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Added services.</returns>
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddScoped<ISerializer<Matrix>, MyXmlSerializer<Matrix>>();
            services.AddScoped<ISerializer<Vector>, MyXmlSerializer<Vector>>();
            services.AddHttpClient();
            services.AddScoped(scope =>
            {
                var baseUrl = configuration["DistributionApiAddress"];
                return RestClient.For<IDistributionHttpClient>(baseUrl);
            });

            return services;
        }
    }
}
