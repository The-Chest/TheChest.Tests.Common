using System;

namespace TheChest.Tests.Common.Attributes.Reflection
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ReflectionExceptionHandleAttribute : Attribute { }
}
