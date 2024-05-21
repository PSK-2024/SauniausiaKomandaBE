using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Data.Repositories
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
