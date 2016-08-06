using System;

namespace ActivityTracker.Attributes
{
    /// <summary>
    ///     A custom attribute used to associate a display name with an enum
    ///     value
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class EnumDisplayNameAttribute : Attribute
    {
        /// <summary>
        ///     initializes an instance of the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute with the specified displayName
        /// </summary>
        /// <param name="displayName">
        ///     the displayName to associate with the
        ///     custom attribute
        /// </param>
        public EnumDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        /// <summary>
        ///     gets the displayName property for the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute
        /// </summary>
        public string DisplayName { get; }
    }
}
