using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context) : base(context) { }
    }
}
