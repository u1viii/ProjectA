using Microsoft.EntityFrameworkCore;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities.Common;
using ProjectA.Persistance.Context;
using System.Linq.Expressions;

namespace ProjectA.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        ProjectADbContext _dbContext { get; }
        public ReadRepository(ProjectADbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll(bool isTracking = false)
            => _checkTracking(Table.AsQueryable(), isTracking);
        public async Task<T> GetByIdAsync(string id, bool isTracking = false)
            => await _checkTracking(Table.AsQueryable(),isTracking).FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> exp, bool isTracking = false)
            => await _checkTracking(Table.AsQueryable(), isTracking).FirstOrDefaultAsync(exp);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> exp, bool isTracking = false)
            => _checkTracking(Table.Where(exp).AsQueryable(), isTracking);

        IQueryable<T> _checkTracking(IQueryable<T> query,bool isTracking)
        {
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
