using System;

namespace Kamo.Core.Domain.Entities.Auditing
{
    public interface IHasUpdateTime
    {
        /// <summary>
        /// The last modified time for this entity.
        /// </summary>
        DateTime UpdateTime { get; set; }
    }
}
