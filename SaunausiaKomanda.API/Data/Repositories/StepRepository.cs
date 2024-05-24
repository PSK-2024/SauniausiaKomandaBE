using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Data.Repositories
{
    public class StepRepository : Repository<Step>, IStepRepository
    {
        public StepRepository(IApplicationDbContext context) : base(context) { }
    }
}
