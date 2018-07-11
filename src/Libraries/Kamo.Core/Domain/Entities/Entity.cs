using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamo.Core.Domain.Entities
{
    public abstract class Entity : Entity<long>, IEntity
    {
    }

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}
