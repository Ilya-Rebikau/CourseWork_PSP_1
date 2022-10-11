// <copyright file="IXmlHelper.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DAL.Interfaces
{
    /// <summary>
    /// Helper for work with XML files.
    /// </summary>
    public interface IXmlHelper
    {
        /// <summary>
        /// Reading matrix from XML file.
        /// </summary>
        /// <param name="xml">XML string data.</param>
        /// <returns>Matrix.</returns>
        double[,] ReadMatrix(string xml);

        /// <summary>
        /// Reading vector from XML file.
        /// </summary>
        /// <param name="xml">XML string data.</param>
        /// <returns>Vector.</returns>
        double[] ReadVector(string xml);
    }
}
