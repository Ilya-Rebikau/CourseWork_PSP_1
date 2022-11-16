// <copyright file="IFactory.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Interfaces
{
    /// <summary>
    /// Factory interface.
    /// </summary>
    /// <typeparam name="T">Type of created model.</typeparam>
    public interface IFactory<T>
    {
        /// <summary>
        /// Create list of T models.
        /// </summary>
        /// <returns>Created list of model.</returns>
        public List<T> CreateList();
    }
}
