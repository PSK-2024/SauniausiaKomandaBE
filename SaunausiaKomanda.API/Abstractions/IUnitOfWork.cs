using SaunausiaKomanda.API.Abstractions.Repositories;

namespace SaunausiaKomanda.API.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }
        ITagRepository Tags { get; }
        IUserRepository Users { get; }
        IImageRepository Images { get; }

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
