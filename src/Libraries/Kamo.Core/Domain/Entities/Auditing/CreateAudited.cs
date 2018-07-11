using Dapper.Extensions.Linq.Core;
using System;
namespace Kamo.Core.Domain.Entities.Auditing
{
    public abstract class CreateAudited : CreateAudited<long>
    {

    }


    public abstract class CreateAudited<TPrimaryKey> : Entity<TPrimaryKey>, ICreateAudited<TPrimaryKey>
    {
        public TPrimaryKey CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
