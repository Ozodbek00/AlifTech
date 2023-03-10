using AlifTech.Data.DbContexts;
using AlifTech.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlifTech.Data.Repositories
{
    public sealed class Repository<TSource> : IRepository<TSource> where TSource : class
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TSource> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TSource>();
        }

        /// <summary>
        /// Add tsource.
        /// </summary>
        public async Task<TSource> CreateAsync(TSource source)
        {
            var result = await dbSet.AddAsync(source);

            await dbContext.SaveChangesAsync();

            return result.Entity;
        }

        /// <summary>
        /// Delete tsource.
        /// </summary>
        public async Task DeleteAsync(Expression<Func<TSource, bool>> expression)
        {
            var result = await dbSet.FirstOrDefaultAsync(expression);

            if (result is not null)
                dbSet.Remove(result);

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all tsource.
        /// </summary>
        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string[]? includes = null)
        {
            IQueryable<TSource> pagedResult = expression is null? dbSet : dbSet.Where(expression);

            if (includes is not null)
                foreach (var include in includes)
                    pagedResult = pagedResult.Include(include);

            return pagedResult;
        }

        /// <summary>
        /// Get tsource by id.
        /// </summary>
        public async Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// Update tsource.
        /// </summary>
        public async Task<TSource> UpdateAsync(TSource source)
        {
            TSource result = dbSet.Update(source).Entity;

            await dbContext.SaveChangesAsync();

            return result;
        }
    }
}
