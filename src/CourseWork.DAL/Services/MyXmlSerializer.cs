// <copyright file="MyXmlSerializer.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DAL.Services
{
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Xml.Serialization;
    using CourseWork.DAL.Interfaces;

    /// <summary>
    /// Helper for work with XML serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">Object for serialization and deserialization.</typeparam>
    internal class MyXmlSerializer<T> : ISerializer<T>
    {
        /// <inheritdoc/>
        public T ReadObject(byte[] data)
        {
            string stringData = Encoding.ASCII.GetString(data);
            using var reader = new StringReader(stringData);
            var xmlSerializer = new XmlSerializer(typeof(T));
            var myObject = (T)xmlSerializer.Deserialize(reader);
            return myObject;
        }

        /// <inheritdoc/>
        public byte[] WriteObject(T myObject)
        {
            using var writer = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(writer, myObject);
            byte[] bytes = Encoding.ASCII.GetBytes(writer.ToString());
            return bytes;
        }
    }
}
