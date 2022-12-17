using Microsoft.EntityFrameworkCore;

namespace ProjectA.Application.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
