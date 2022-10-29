// <copyright file="IComputingHttpClient.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Interfaces
{
    using CourseWork.Models;
    using RestEase;

    /// <summary>
    /// Http client for computing API.
    /// </summary>
    public interface IComputingHttpClient
    {
        /// <summary>
        /// Sending data to computing API.
        /// </summary>
        /// <param name="fileData">File data.</param>
        /// <returns>Task with result.</returns>
        [Post("Maths/GetResult")]
        Task<DataModel> GetResult([Body] DataModel fileData);
    }
}
