using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ProjectADbContext dbContext) : base(dbContext)
        {
        }
    }
}
