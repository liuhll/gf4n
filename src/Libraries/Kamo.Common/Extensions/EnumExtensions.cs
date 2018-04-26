using Kamo.Common.Enums;
using System;
using System.Linq;

namespace Kamo.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescribe(this Enum enumval)
        {
            var type = enumval.GetType();
            var fieldName = Enum.GetName(type, enumval);
            var attributes = type.GetField(fieldName).GetCustomAttributes(false);
            var enumDisplayAttribute = attributes.FirstOrDefault(p => p.GetType().Equals(typeof(EnumDiscAttribute))) as EnumDiscAttribute;
            return enumDisplayAttribute == null ? fieldName : enumDisplayAttribute.Description;
        }
    }
}