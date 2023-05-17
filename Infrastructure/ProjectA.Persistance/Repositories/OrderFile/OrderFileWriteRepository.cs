using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class OrderFileWriteRepository : WriteRepository<OrderFile>, IOrderFileWriteRepository
    {
        public OrderFileWriteRepository(ProjectADbContext dbContext) : base(dbContext)
        {
        }
    }
}
