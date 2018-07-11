using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Extensions.Linq.Core.Sessions;
using Dapper.Extensions.Linq.Repositories;
using Kamo.Core.Domain.Entities;
using Kamo.Core.Domain.Repositories;

namespace Kamo.Dapper.Repositories
{
    public class KamoDapperRepository<TEntity> : DapperRepository<TEntity>, IKamoRepository<TEntity> where TEntity : class, IEntity
    {
        public KamoDapperRepository(IDapperSessionContext sessionContext) : base(sessionContext)
        {          
        }

        public TEntity FirstOrDefault(long id)
        {
            return FirstOrDefault(p => p.Id == id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var result = base.Query(predicate).FirstOrDefault();
            if (result != null && result is ISoftDelete)
            {
                if (((ISoftDelete)result).IsDeleted)
                {
                    result = null;
                }
            }
            return result;
        }

        public Task<TEntity> FirstOrDefaultAsync(long id)
        {
            return Task.FromResult<TEntity>(FirstOrDefault(id));
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<TEntity>(FirstOrDefault(predicate));
        }


        public List<TEntity> GetAllList()
        {
            if (typeof(TEntity).IsSubclassOf(typeof(ISoftDelete)))
            {

            }
            var result = base.Query(p=> true);
            return null;
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public long InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public new T Query<T>(Expression<Func<TEntity, bool>> queryMethod)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IKamoRepository<TEntity, long>.Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
