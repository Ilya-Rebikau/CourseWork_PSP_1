// <copyright file="ISerializer.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Interfaces
{
    /// <summary>
    /// Helper for work with serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">Object for serialization and deserialization.</typeparam>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Reading object from file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Serialized object.</returns>
        T ReadObject(string path);

        /// <summary>
        /// Write object to bytes array.
        /// </summary>
        /// <param name="myObject">Object for deserialization.</param>
        /// <returns>Array of bytes with object in xml format.</returns>
        byte[] WriteObjectToByteArray(T myObject);
    }
}
