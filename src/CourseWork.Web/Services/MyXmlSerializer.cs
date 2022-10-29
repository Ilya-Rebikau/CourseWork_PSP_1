// <copyright file="MyXmlSerializer.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Services
{
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using CourseWork.Web.Interfaces;

    /// <summary>
    /// Helper for work with XML serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">Object for serialization and deserialization.</typeparam>
    internal class MyXmlSerializer<T> : ISerializer<T>
    {
        /// <inheritdoc/>
        public T ReadObject(string path)
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var xmlSerializer = new XmlSerializer(typeof(T));
            var myObject = (T)xmlSerializer.Deserialize(stream);
            return myObject;
        }

        /// <inheritdoc/>
        public byte[] WriteObjectToByteArray(T myObject)
        {
            using var writer = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(writer, myObject);
            byte[] bytes = Encoding.ASCII.GetBytes(writer.ToString());
            return bytes;
        }
    }
}
