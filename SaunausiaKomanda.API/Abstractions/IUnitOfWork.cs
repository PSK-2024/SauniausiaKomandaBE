using SaunausiaKomanda.API.Abstractions.Repositories;

namespace SaunausiaKomanda.API.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }
        IUserRepository Users { get; }
        IImageRepository Images { get; }
        ICategoryRepository Categories { get; }
        IStepRepository Steps { get; }

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
