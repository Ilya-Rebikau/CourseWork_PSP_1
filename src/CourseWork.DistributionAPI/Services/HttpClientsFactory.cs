// <copyright file="HttpClientsFactory.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Services
{
    using CourseWork.DistributionAPI.Interfaces;
    using RestEase;

    /// <summary>
    /// Factory for http clients.
    /// </summary>
    public class HttpClientsFactory : IFactory<IComputingHttpClient>
    {
        /// <summary>
        /// Configuration object.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientsFactory"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object.</param>
        public HttpClientsFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Creates list of http client.
        /// </summary>
        /// <returns>Http client.</returns>
        public List<IComputingHttpClient> CreateList()
        {
            var servers = new List<IComputingHttpClient>();
            var serversCount = int.Parse(_configuration["ServersCount"]);
            for (int i = 0; i < serversCount; i++)
            {
                var baseUrl = _configuration["BaseUrl"] + ":" + (5002 + i);
                servers.Add(RestClient.For<IComputingHttpClient>(baseUrl));
            }

            return servers;
        }
    }
}
