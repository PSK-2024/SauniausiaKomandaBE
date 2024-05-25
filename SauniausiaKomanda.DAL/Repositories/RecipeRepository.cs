using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
