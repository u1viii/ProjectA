using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class OrderFileReadRepository : ReadRepository<OrderFile>, IOrderFileReadRepository
    {
        public OrderFileReadRepository(ProjectADbContext dbContext) : base(dbContext) { }
    }
}
