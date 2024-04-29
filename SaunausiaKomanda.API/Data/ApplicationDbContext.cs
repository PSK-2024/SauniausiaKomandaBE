using Microsoft.EntityFrameworkCore;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Entities;

namespace SaunausiaKomanda.API.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recipe>().HasKey(r => r.Id);
        }
    }
}
