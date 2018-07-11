using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamo.Core.Domain.Entities.Auditing
{
    public interface ICreateAudited : ICreateAudited<long>
    {
        /// <summary>
        /// Id of the creator user of this entity.
        /// </summary>
        new long? CreateBy { get; set; }
    }

    public interface ICreateAudited<TPrimaryKey> : IHasCreateTime
    {
        /// <summary>
        /// Reference to the creator user of this entity.
        /// </summary>
        TPrimaryKey CreateBy { get; set; }
    }
}
