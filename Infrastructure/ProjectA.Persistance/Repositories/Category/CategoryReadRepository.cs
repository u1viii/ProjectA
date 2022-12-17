using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(ProjectADbContext dbContext) : base(dbContext)
        {
        }
    }
}
