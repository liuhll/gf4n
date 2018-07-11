using DapperLinqCore = Dapper.Extensions.Linq.Core;
namespace Kamo.Core.Domain.Entities
{
    public interface IEntity<TPrimaryKey> : DapperLinqCore.IEntity
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}