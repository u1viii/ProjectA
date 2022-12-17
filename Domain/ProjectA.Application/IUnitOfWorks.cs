using ProjectA.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application
{
    public interface IUnitOfWorks
    {
        ICategoryReadRepository CategoryReadRepository { get; }
        ICategoryWriteRepository CategoryWriteRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
