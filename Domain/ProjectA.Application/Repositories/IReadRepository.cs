using System.Linq.Expressions;

namespace ProjectA.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = false);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> exp, bool isTracking = false);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> exp, bool isTracking = false);
        Task<T> GetByIdAsync(string id, bool isTracking = false);
    }
}
