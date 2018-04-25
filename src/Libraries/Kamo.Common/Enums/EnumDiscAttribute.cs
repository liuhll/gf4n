using System;

namespace Kamo.Common.Enums
{
    [AttributeUsageAttribute(AttributeTargets.Enum, Inherited = true, AllowMultiple = false)]
    public class EnumDiscAttribute : Attribute
    {
        private readonly string _description;

        public EnumDiscAttribute(string description)
        {
            _description = description;
        }

        public string Description => _description;
    }
}