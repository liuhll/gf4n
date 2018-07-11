using Dapper.Extensions.Linq.Core;
using Dapper.Extensions.Linq.Core.Attributes;
using Dapper.Extensions.Linq.Mapper;
using Kamo.Common.Extensions;
using Kamo.Core.Domain.Entities;
using System;
using System.Reflection;

namespace Kamo.Dapper.Mapper
{
    public class KamoClassMapper<TEntity> : AutoClassMapper<TEntity> where TEntity : Entity
    {
        public override void Table(string tableName)
        {
            if (Attribute.IsDefined(EntityType, typeof(TableNameAttribute)))
            {
                tableName = ((TableNameAttribute)EntityType.GetCustomAttribute(typeof(TableNameAttribute))).Name;
            }
            else
            {
                var type = typeof(TEntity);
                tableName = type.Name.UnderScoreName();
            }

            base.Table(tableName);
        }
    }
}
