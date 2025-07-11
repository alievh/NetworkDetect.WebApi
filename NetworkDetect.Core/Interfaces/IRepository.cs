﻿using System.Linq.Expressions;

namespace NetworkDetect.Core.Interfaces;

public interface IRepository<TEntity>
{
	Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
	Task<List<TEntity>> GetAllAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
	Task<List<TEntity>> PaginationAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, Expression<Func<TEntity, bool>>? predicate = null, int skip = 0, int take = int.MaxValue, params string[] includes);
	Task CreateAsync(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task DeleteAsync(TEntity entity);
}
