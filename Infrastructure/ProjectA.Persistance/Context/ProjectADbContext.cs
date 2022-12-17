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
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas =ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeletedTime = DateTime.UtcNow,
                    EntityState.Unchanged => null
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
