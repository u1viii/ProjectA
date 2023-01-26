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
        public ICategoryReadRepository CategoryReadRepository 
        {
            get
            {
                if (_categoryRead is null)
                {
                    _categoryRead = new CategoryReadRepository(_dbContext);
                }
                return _categoryRead;
            }
        }
        public ICategoryWriteRepository CategoryWriteRepository
        {
            get
            {
                if (_categoryWrite is null)
                {
                    _categoryWrite = new CategoryWriteRepository(_dbContext);
                }
                return _categoryWrite;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            return 0;
        }
    }
}
