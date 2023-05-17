using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class ProjectFileReadRepository : ReadRepository<ProjectFile>, IProjectFileReadRepository
    {
        public ProjectFileReadRepository(ProjectADbContext dbContext) : base(dbContext)
        {
        }
    }
}
