using ActivityTracker.Attributes;
using ActivityTracker.Enums;
using ActivityTracker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ActivityTracker.Helpers
{
    /// <summary>
    ///     Helper class for working with enums that are decorated with the
    ///     <see cref="EnumDisplayNameAttribute" /> ,
    ///     <see cref="EnumDisplayCodeAttribute" />  attribute.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        ///     Retrieves the display name (specified in the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute) for the passed in <see cref="System.Enum" /> instance.
        /// </summary>
        /// <param name="enumObj">an Enum whose displayName is being requested</param>
        /// <param name="enumProp">and Enum property for display type </param>
        /// <returns>the display name for the specified enum</returns>
        /// <remarks>
        ///     The enum specified must implement the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute.  If it does not, an empty string is returned
        /// </remarks>
        public static string GetEnumDisplayValue<T>(T enumObj, EnumProp enumProp)
        {
            if (enumObj is System.Enum == false)
            {
                throw new ArgumentException("The specified generic type must derive from System.Enum");
            }
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            if (fieldInfo == null)
                return string.Empty;

            return GetEnumDisplay(enumObj, enumProp, fieldInfo);
        }

        private static string GetEnumDisplay<T>(T enumObj, EnumProp enumProp, FieldInfo fieldInfo)
        {
            var attribArray = GetCustomAttributes(fieldInfo, enumProp);
            return attribArray.Length == 0
                ? enumObj.ToString()
                : GetEnumDisplay(enumProp, attribArray);
        }

        private static string GetEnumDisplay(EnumProp enumProp, object[] attribArray)
        {
            switch (enumProp)
            {
                case EnumProp.DisplayName:
                    {
                        var attrib = attribArray[0] as EnumDisplayNameAttribute;
                        return attrib != null ? attrib.DisplayName : string.Empty;
                    }
                case EnumProp.DisplayCode:
                    {
                        var attrib = attribArray[0] as EnumDisplayCodeAttribute;
                        return attrib != null ? attrib.DisplayCode : string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }

        private static object[] GetCustomAttributes(FieldInfo fieldInfo, EnumProp enumProp)
        {
            return enumProp == EnumProp.DisplayName
                ? fieldInfo.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                : fieldInfo.GetCustomAttributes(typeof(EnumDisplayCodeAttribute), false);
        }

        /// <summary>
        ///     Retrieves the display name (specified in the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute) for the passed in <see cref="System.Enum" /> instance.
        /// </summary>
        /// <returns>the display name for the specified enum</returns>
        /// <remarks>
        ///     The enum specified must implement the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute.  If it does not, an empty string is returned
        /// </remarks>
        /// <summary>
        /// </summary>
        /// <param name="enumeratedValue"></param>
        /// <param name="enumProp"></param>
        /// <returns></returns>
        public static string GetEnumDisplayName(System.Enum enumeratedValue, EnumProp enumProp)
        {
            var fieldInfo = enumeratedValue.GetType().GetField(enumeratedValue.ToString());
            var attribArray = GetCustomAttributes(fieldInfo, enumProp);
            return attribArray.Length == 0
                ? string.Empty
                : GetEnumDisplay(enumProp, attribArray);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>()
        {
            return (from fieldInfo in typeof(T).GetFields()
                    where fieldInfo.FieldType == typeof(T)
                    select (T)fieldInfo.GetValue(fieldInfo)).ToList();
        }

        /// <summary>
        ///     Gets the field of the specified enum type who's displayName matches the
        ///     specified enumDisplayValue
        /// </summary>
        /// <typeparam name="T">
        ///     the enum type who's field's are decorated with the
        ///     <see cref="EnumDisplayNameAttribute" />
        /// </typeparam>
        /// <param name="enumDisplayValue">the displayName to search for</param>
        /// <param name="enumProp"></param>
        /// <param name="throwExceptionIfNotFound">
        ///     flag indicating whether or not
        ///     to throw an exception if no field is found with a displayName that matches
        ///     the specified displayName
        /// </param>
        /// <returns>a field of the specified enum Type (T)</returns>
        public static T GetEnumValue<T>(string enumDisplayValue, EnumProp enumProp, bool throwExceptionIfNotFound)
        {
            var retVal = default(T);
            var found = false;
            if (enumDisplayValue != null)
            {
                foreach (var fieldInfo in typeof(T).GetFields())
                {
                    if (fieldInfo.FieldType != typeof(T)) continue;
                    var attribArray = enumProp == EnumProp.DisplayName
                        ? fieldInfo.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                        : fieldInfo.GetCustomAttributes(typeof(EnumDisplayCodeAttribute), false);
                    switch (attribArray.Length)
                    {
                        case 0:
                            continue;
                        default:
                            if (enumDisplayValue.ToUpper() ==
                                (enumProp == EnumProp.DisplayName
                                    ? ((EnumDisplayNameAttribute)attribArray[0]).DisplayName.ToUpper()
                                    : ((EnumDisplayCodeAttribute)attribArray[0]).DisplayCode.ToUpper()))
                            {
                                found = true;
                                retVal = (T)fieldInfo.GetValue(fieldInfo);
                            }
                            break;
                    }
                }
            }

            if (!found && throwExceptionIfNotFound)
                throw new ArgumentException(string.Format("No value of Enum {0} has a display name of {1}",
                    typeof(T).Name, enumDisplayValue));

            return retVal;
        }

        /// <summary>
        ///     Same as GetEnumValue, but using the actual enum values, not a EnumDIsplayNameAttribute.
        /// </summary>
        public static T GetEnumValueFromString<T>(string enumName, bool throwExceptionIfNotFound)
        {
            var retVal = default(T);
            var found = false;
            foreach (
                var fieldInfo in
                    typeof(T).GetFields()
                        .Where(fieldInfo => fieldInfo.FieldType == typeof(T))
                        .Where(fieldInfo => enumName == fieldInfo.Name))
            {
                found = true;
                retVal = (T)fieldInfo.GetValue(fieldInfo);
                break;
            }

            if (!found && throwExceptionIfNotFound)
                throw new ArgumentException(string.Format("No value of Enum {0} has a  name of {1}", typeof(T).Name,
                    enumName));

            return retVal;
        }

        /// <summary>
        ///     Gets a list of all display names for the specified enum type.
        /// </summary>
        /// <typeparam name="T">An enum who's field's are decorated with the <see cref="EnumDisplayNameAttribute" /></typeparam>
        /// <returns>List of all display names for the specified enum type</returns>
        /// <remarks>
        ///     All fields of the enum must implement the <see cref="EnumDisplayNameAttribute" />
        ///     custom attribute.  If it does not, an empty string is returned
        /// </remarks>
        /// <summary>
        ///     Creates a dictionary out of an enum where the fields use the EnumDisplayNameAttribute.
        ///     The dictionary keys are the enum fields and the value is the display name.
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns></returns>
        /// <summary>
        ///     Creates a list of KeyValuePairs out of an enum where the fields use the EnumDisplayNameAttribute.
        ///     The key represents the enum field and the value is the display name.
        /// </summary>
        /// <typeparam name="T">The type of the enum</typeparam>
        /// <typeparam name="Y">The numeric type of the enum value (i.e., byte)</typeparam>
        /// <returns>a list of KeyValuePair objects where the key is the id of the enum and </returns>
        /// <summary>
        ///     Creates a list of KeyValuePairs out of an enum where the fields use the EnumDisplayNameAttribute.
        ///     The key represents the enum field and the value is the display name.
        /// </summary>
        /// <typeparam name="T">The type of the enum</typeparam>
        /// <returns>a list of KeyValuePair objects where the key is the id of the enum and </returns>
        /// <summary></summary>
        public static List<string> GetToStringDisplayList<T>()
        {
            return (from T value in System.Enum.GetValues(typeof(T)) select value.ToString()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="displayCode"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static string GetEnumDisplayName<T>(string lst, EnumProp displayCode)
        {
            var enumratedValue = lst.ToEnum<T>();
            return GetEnumDisplayName(enumratedValue as System.Enum, displayCode);
        }
    }
}