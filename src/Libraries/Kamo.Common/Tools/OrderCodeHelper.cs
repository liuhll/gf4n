using Kamo.Common.Tools;
using System;

namespace Kamo.Common.Tools
{
    public static class OrderCodeHelper
    {
        public static string GenerateTaskCode(string prefix="",int verificationCodeLength = 3)
        {
            var oderCode = string.Empty;
            var date = DateTime.Now.ToString("yyyyMMdd");
            DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
            var timeStamp = (Math.Ceiling((DateTime.Now - dtFrom).TotalSeconds)).ToString().PadLeft(5, '0');
            var randomStr = RandomHelper.RandomNumStr(verificationCodeLength);
            return prefix + date + timeStamp + randomStr;
        }
    }
}