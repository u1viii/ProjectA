using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;

namespace ProjectA.Persistance.Repositories
{
    public class ProjectFileWriteRepository : WriteRepository<ProjectFile>, IProjectFileWriteRepository
    {
        public ProjectFileWriteRepository(ProjectADbContext dbContext) : base(dbContext)
        {
        }
    }
}
