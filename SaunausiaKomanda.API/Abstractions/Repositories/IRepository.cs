using System.Linq.Expressions;

namespace SaunausiaKomanda.API.Abstractions.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task CreateAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAllAsync();
        Task SaveAsync();
    }
}
