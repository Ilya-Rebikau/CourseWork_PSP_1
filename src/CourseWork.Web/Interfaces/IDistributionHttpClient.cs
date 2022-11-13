// <copyright file="IDistributionHttpClient.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Interfaces
{
    using CourseWork.Models;
    using RestEase;

    /// <summary>
    /// HttpClient for api.
    /// </summary>
    public interface IDistributionHttpClient
    {
        /// <summary>
        /// Sending file data to API.
        /// </summary>
        /// <param name="fileData">File data.</param>
        /// <returns>Task with DataModel and vector-result in it.</returns>
        [Post("Distribution/DistributeFiles")]
        Task<DataModel> SendFileToServer([Body] DataModel fileData);
    }
}
