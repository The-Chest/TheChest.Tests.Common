using System;

namespace TheChest.Tests.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ReflectionExceptionHandleAttribute : Attribute { }
}
