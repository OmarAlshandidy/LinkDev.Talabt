using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Entites.Products;
using LinkDev.Talabat.Core.Domain.Contracts;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories.Genaric_Repository
{
    public class GenericRepository<TEntity, TKey>(StoreContext dbContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {  
            if(withTracking) return await dbContext.Set<TEntity>().ToListAsync();
            return  await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> spec, bool withTracking = false)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }

        public async Task<TEntity?> GetAsync(TKey id)
        {

           return await dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity?> GetWithSpecAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }
        public async Task AddAsync(TEntity entity)
        {
             await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity id)
        {
            dbContext.Set<TEntity>().Remove(id);
        }

        #region Healper
        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> spec)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetQuery(dbContext.Set<TEntity>(), spec);
        }

        #endregion

    }
}
