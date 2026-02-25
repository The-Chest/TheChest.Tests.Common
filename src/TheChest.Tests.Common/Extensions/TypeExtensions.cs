using System;
using System.Linq;
using System.Reflection;

namespace TheChest.Tests.Common.Extensions
{
    internal static class TypeExtensions
    {
        internal static ConstructorInfo GetSmallerConstructor(this Type implType)
        {
            return implType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault()
                ?? throw new InvalidOperationException("No public constructor found for " + implType.FullName);
        }
    }
}
