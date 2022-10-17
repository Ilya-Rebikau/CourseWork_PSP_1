// <copyright file="ISerializer.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DAL.Interfaces
{
    /// <summary>
    /// Helper for work with serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">Object for serialization and deserialization.</typeparam>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Reading object from byte data.
        /// </summary>
        /// <param name="data">Byte data.</param>
        /// <returns>Serialized object.</returns>
        T ReadObject(byte[] data);

        /// <summary>
        /// Write object to file.
        /// </summary>
        /// <param name="myObject">Object for deserialization.</param>
        /// <param name="path">Path to file.</param>
        void WriteObject(T myObject, string path);
    }
}
