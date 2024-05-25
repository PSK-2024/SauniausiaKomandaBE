using Microsoft.EntityFrameworkCore;
using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;

namespace SauniausiaKomanda.DAL.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Log> Log { get; set; }

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
            inserts.ForEach(e =>
            {
                if (e.GetType().GetProperty("CreationTime") != null)
                {
                    e.Property("CreationTime").CurrentValue = DateTime.Now;
                }
            });

            var updates = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .ToList();

            // TODO: rename to ModifiedDT, also in model store
            updates.ForEach(e =>
            {
                if (e.GetType().GetProperty("ModifiedDate") != null)
                {
                    e.Property("ModifiedDate").CurrentValue = DateTime.Now;
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
