using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }
        IUserRepository Users { get; }
        IImageRepository Images { get; }
        ICategoryRepository Categories { get; }
        IStepRepository Steps { get; }
        IReviewRepository Reviews { get; }

        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
