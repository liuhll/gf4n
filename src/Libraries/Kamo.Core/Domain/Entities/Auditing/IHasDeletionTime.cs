using System;

namespace Kamo.Core.Domain.Entities.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// Deletion time of this entity.
        /// </summary>
        DateTime? DeleteTime { get; set; }
    }
}
