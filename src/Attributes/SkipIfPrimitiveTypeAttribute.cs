using System;

namespace TheChest.Tests.Common.Attributes
{
    /// <summary>
    /// Attribute to ignore test methods when the provided type is a primitive type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipIfPrimitiveTypeAttribute : TypeConditionAttribute
    {
        /// <summary>
        /// Determines whether the test should be skipped based on whether the type is a primitive type.
        /// </summary>
        /// <param name="type">The type to be evaluated.</param>
        /// <returns><see langword="true"/> if the type is a primitive type; otherwise, <see langword="false"/>.</returns>
        protected override bool ShouldSkip(Type type) => !type.IsPrimitive;

        /// <summary>
        /// The reason why the test was skipped.
        /// </summary>
        protected override string Reason => "Skipped because test does not apply to primitive types.";
    }
}
