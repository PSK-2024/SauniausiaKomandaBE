using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
