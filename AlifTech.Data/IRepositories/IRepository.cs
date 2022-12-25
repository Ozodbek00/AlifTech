﻿using System.Linq.Expressions;

namespace AlifTech.Data.IRepositories
{
    public interface IRepository<TSource> where TSource : class
    {
        /// <summary>
        /// Add tsource to database.
        /// </summary>
        Task<TSource> CreateAsync(TSource source);

        /// <summary>
        /// Update tsource.
        /// </summary>
        Task<TSource> UpdateAsync(TSource source);

        /// <summary>
        /// Delete tsource by id.
        /// </summary>
        Task DeleteAsync(Expression<Func<TSource, bool>> expression);

        /// <summary>
        /// Get tsource by id.
        /// </summary>
        Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression);

        /// <summary>
        /// Get all tsources from db + with pagination.
        /// </summary>
        Task<TSource[]> GetAllAsync(int pageIndex, int pageSize, string[]? include = null);
    }
}
