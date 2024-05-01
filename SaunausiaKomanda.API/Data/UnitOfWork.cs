using Microsoft.EntityFrameworkCore.Storage;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;

namespace SaunausiaKomanda.API.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IApplicationDbContext _context;

        public UnitOfWork(
            IApplicationDbContext context,
            IRecipeRepository recipeRepository)
        {
            _context = context;
            Recipes = recipeRepository;
        }

        public IRecipeRepository Recipes { get; }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
