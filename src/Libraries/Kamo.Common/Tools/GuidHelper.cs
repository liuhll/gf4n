using System;

namespace Kamo.Common.Tools
{
    public class GuidHelper
    {
        public static string NewId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string NewIdWithNoLine()
        {
            return NewId().Replace("-", "");
        }
    }
}