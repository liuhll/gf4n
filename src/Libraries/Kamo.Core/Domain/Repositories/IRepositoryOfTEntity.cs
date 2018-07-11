using Kamo.Core.Domain.Entities;

namespace Kamo.Core.Domain.Repositories
{
    public interface IKamoRepository<TEntity> : IKamoRepository<TEntity, long> where TEntity : IEntity
    {
    }
}