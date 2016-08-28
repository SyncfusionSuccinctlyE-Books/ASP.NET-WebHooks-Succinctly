namespace ActivityTracker.Extensions
{
    /// <summary>
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return System.Enum.TryParse(value, true, out result) ? result : defaultValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }
    }
}
