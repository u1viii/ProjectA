using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities.Common;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        ProjectADbContext _dbContext { get; }

        public DbSet<T> Table => _dbContext.Set<T>();

        public WriteRepository(ProjectADbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(T item)
        {
            EntityEntry<T> entity = await Table.AddAsync(item);
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(List<T> items)
        {
            await Table.AddRangeAsync(items);
            return true;
        }

        public bool Remove(T item)
        {
            EntityEntry<T> entity = Table.Remove(item);
            return entity.State == EntityState.Deleted;
        }

        public bool Remove(string id)
            =>Remove(Table.Find(id));

        public bool RemoveAll(List<T> items)
        {
            Table.RemoveRange(items);
            return true;
        }

        public bool Update(T item)
        {
            EntityEntry entity = Table.Update(item);
            return entity.State == EntityState.Modified;
        }

        public bool UpdateAll(List<T> items)
        {
            Table.UpdateRange(items);
            return true;
        }
    }
}
