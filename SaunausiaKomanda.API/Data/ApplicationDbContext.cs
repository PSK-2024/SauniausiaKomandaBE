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

            builder.Entity<Image>()
                .Property(e => e.ImageLocation)
                .HasConversion<int>();
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            var inserts = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .ToList();

            // TODO: rename to CreatedDT, also in model store
            inserts.ForEach(E =>
            {
                E.Property("CreationTime").CurrentValue = DateTime.Now;
            });

            var updates = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .ToList();

            // TODO: rename to ModifiedDT, also in model store
            updates.ForEach(e =>
            {
                e.Property("ModifiedDate").CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
