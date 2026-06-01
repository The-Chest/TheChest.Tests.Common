using System;

namespace TheChest.Tests.Common.Attributes
{
    /// <summary>
    /// Attribute to ignore test methods when the provided type is a value type (struct, enum, etc).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class SkipIfValueTypeAttribute : TypeConditionAttribute
    {
        /// <summary>
        /// Determines whether the test should be skipped based on whether the type is a value type.
        /// </summary>
        /// <param name="type">The type to be evaluated.</param>
        /// <returns><see langword="true"/> if the type is a value type; otherwise, <see langword="false"/>.</returns>
        protected override bool ShouldSkip(Type type) => type.IsValueType;

        /// <summary>
        /// The reason why the test was skipped.
        /// </summary>
        protected override string Reason => "Skipped because test does not apply to value types.";
    }
}
