using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamo.Core.Domain.Entities.Auditing
{
    public interface IFullAudited : IAudited, IHasDeletionTime
    {

    }


    public interface IFullAudited<TPrimaryKey> : IAudited<TPrimaryKey>, IHasDeletionTime
    {

    }
}
