using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        public StepRepository(IApplicationDbContext context) : base(context) { }
    }
}
