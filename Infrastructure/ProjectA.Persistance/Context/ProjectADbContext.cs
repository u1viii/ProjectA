using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectA.Core.Entities;
using ProjectA.Core.Entities.Common;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Persistance.Context
{
    public class ProjectADbContext:IdentityDbContext<AppUser,IdentityRole<Guid>, Guid>
    {
        public ProjectADbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderCategory> OrderCategories { get; set; } = null!;
        public DbSet<ProjectFile> ProjectFiles { get; set; } = null!;
        public DbSet<OrderFile> OrderFiles { get; set; } = null!;
        public DbSet<OrderImageFile> OrderImageFiles { get; set; } = null!;
        public DbSet<OrderDocumentFile> OrderDocumentFiles { get; set; } = null!;
        public DbSet<AppUserCategory> AppUserCategories { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas =ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    EntityState.Unchanged => null,
                    EntityState.Deleted => null
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
