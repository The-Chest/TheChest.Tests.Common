using System;

namespace TheChest.Tests.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class TypeConditionAttribute : Attribute
    {
        protected abstract string Reason { get; }
        protected abstract bool ShouldIgnore(Type type);
    }
}
