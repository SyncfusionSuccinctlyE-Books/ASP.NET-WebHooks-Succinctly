using System;

namespace ActivityTracker.Attributes
{
    /// <summary>
    ///  A custom attribute used to associate a display code with an enum
    ///     value
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class EnumDisplayCodeAttribute : Attribute
    {
        /// <summary>
        /// initializes an instance of <see cref="EnumDisplayCodeAttribute"/>
        /// custome attribute with the specified displaycode
        /// </summary>
        /// <param name="displayCode">
        /// thie displayCode to associate with the
        /// custome attribute
        /// </param>
        public EnumDisplayCodeAttribute(string displayCode)
        {
            DisplayCode = displayCode;
        }

        /// <summary>
        /// Gets the displaycode property for the <see cref="EnumDisplayCodeAttribute"/>
        /// custome attribute
        /// </summary>
        public string DisplayCode { get; }
    }
}
