namespace Contract.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Models.Interfaces;

    using MongoDB.Driver;

    public interface IRepository<T>
        where T : IEntity
    {
        Task Add(T entity);

        Task AddMany(ICollection<T> entities);

        Task BulkInsert(ICollection<T> entities);

        Task<long> Count(Expression<Func<T, bool>> filter);

        Task Delete(T entity);

        Task Delete(Expression<Func<T, bool>> filter);

        Task<ICollection<T>> GetByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        Task<ICollection<T>> GetAll(SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null);

        Task<ICollection<T>> GetByPageAndQuantity(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        Task<T> GetSingleByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1);
    }
}