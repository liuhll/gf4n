using System;

namespace Kamo.Core.Domain.Entities.Auditing
{
    public interface IHasCreateTime
    {
        /// <summary>
        /// Creation time of this entity.
        /// </summary>
        DateTime CreateTime { get; set; }
    }
}
