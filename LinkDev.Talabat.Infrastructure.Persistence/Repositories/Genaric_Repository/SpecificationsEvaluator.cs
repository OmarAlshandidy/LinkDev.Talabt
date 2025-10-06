using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Contracts;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories.Genaric_Repository
{
    internal class SpecificationsEvaluator<TEntity ,TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public static  IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecifications<TEntity,TKey> spec)
        {
            var query = inputQuery;
            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            if(spec.OrderByDesc is not null) 
                query = query.OrderByDescending(spec.OrderByDesc);
            else if( spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);
            if (spec.IsPagingEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            return query;
        }
    }
}
