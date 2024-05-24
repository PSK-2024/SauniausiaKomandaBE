using System.Linq.Expressions;

namespace SauniausiaKomanda.DAL.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? itemsToSkip = null,
            int? itemsToTake = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task CreateAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAllAsync();
        Task SaveAsync();
    }
}
