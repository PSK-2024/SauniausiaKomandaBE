using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context) : base(context) { }
    }
}
