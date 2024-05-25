using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Repositories.Abstractions;
using SauniausiaKomanda.DAL.Entities;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(IApplicationDbContext context) : base(context) { }
    }
}
