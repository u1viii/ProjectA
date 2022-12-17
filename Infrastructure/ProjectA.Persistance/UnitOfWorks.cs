using ProjectA.Application;
using ProjectA.Application.Repositories;
using ProjectA.Persistance.Context;
using ProjectA.Persistance.Repositories;

namespace ProjectA.Persistance
{
    public class UnitOfWorks : IUnitOfWorks
    {
        ProjectADbContext _dbContext;
        ICategoryReadRepository _categoryRead;
        ICategoryWriteRepository _categoryWrite;
        public UnitOfWorks(ProjectADbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICategoryReadRepository CategoryReadRepository => _categoryRead ?? new CategoryReadRepository(_dbContext);

        public ICategoryWriteRepository CategoryWriteRepository =>_categoryWrite ?? new CategoryWriteRepository(_dbContext);

        public async Task<int> SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            return 0;
        }
    }
}
