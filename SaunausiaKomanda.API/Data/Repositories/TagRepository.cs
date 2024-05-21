using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
