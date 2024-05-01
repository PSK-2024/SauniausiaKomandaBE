using Microsoft.EntityFrameworkCore;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using System.Linq.Expressions;

namespace SaunausiaKomanda.API.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IApplicationDbContext _context;

        public Repository(IApplicationDbContext context) => _context = context;

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().AnyAsync(predicate);
        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task CreateAsync(IEnumerable<T> entities) => await _context.Set<T>().AddRangeAsync(entities);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _context.Set<T>().Where(predicate).ToListAsync();
            _context.Set<T>().RemoveRange(entities);
        }
        public async Task DeleteAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            _context.Set<T>().RemoveRange(entities);
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().FirstOrDefaultAsync(predicate);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Update(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);
    }
}
