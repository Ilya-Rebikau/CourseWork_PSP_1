// <copyright file="TypeExtension.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Extensions
{
    /// <summary>
    /// Extension for Type.
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Gets controller name without word "Controller" at the end.
        /// </summary>
        /// <param name="controller">Controller.</param>
        /// <returns>Name of controller.</returns>
        public static string GetControllerName(this Type controller)
        {
            var name = controller.Name;
            return name.EndsWith("Controller") ? name[0..^10] : name;
        }
    }
}
