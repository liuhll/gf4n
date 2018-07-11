using System;
using System.Text;

namespace Kamo.Common.Tools
{
    public static class RandomHelper
    {
        public static string RandomNumStr(int count)
        {
            var random = new Random();
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                sb.Append(random.Next(0, 9));
            }
            return sb.ToString();
        }
    }
}