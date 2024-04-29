using SaunausiaKomanda.API.Abstractions.Repositories;

namespace SaunausiaKomanda.API.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
