using System;
using System.Reflection;

namespace TheChest.Tests.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for working with container types, including checking interface implementations and accessing specific fields.
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Determines the container type that implements the specified interface.
        /// </summary>
        /// <param name="containerType">The type to check for implementation of the specified interface.</param>
        /// <param name="interfaceType">The interface type to verify against the container type.</param>
        /// <returns>The <paramref name="containerType"/> if it implements the specified <paramref name="interfaceType"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="interfaceType"/> is not an interface or if <paramref name="containerType"/> does not implement <paramref name="interfaceType"/>.</exception>
        public static Type GetTypeIfImplements(this Type containerType, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException($"'{interfaceType.FullName}' is not an interface.");

            if (!interfaceType.IsAssignableFrom(containerType))
                throw new ArgumentException($"Type '{containerType.FullName}' does not implement '{interfaceType.FullName}'.");

            return containerType;
        }

        /// <summary>
        /// Retrieves the value of the non-public or public instance field named "slots" from the specified container.
        /// </summary>
        /// <param name="container">The container object from which to retrieve the "slots" field value.</param>
        /// <returns>The value of the "slots" field from the specified container.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the "slots" field does not exist on the container's type.</exception>
        public static object GetSlotsField(this object container)
        {
            var type = container.GetType();

            var field = type.GetField(
                "slots",
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public | BindingFlags.FlattenHierarchy
            ) ?? throw new InvalidOperationException("Field 'slots' not found.");

            return field.GetValue(container);
        }
    }
}
