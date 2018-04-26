using System;

namespace Kamo.Web.WebApi.Result
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method)]
    public class DontWrapResultAttribute : WrapResultAttribute
    {
        public DontWrapResultAttribute()
            : base(false, false)
        {
        }
    }
}