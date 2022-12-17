using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;
using ProjectA.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Persistance.Repositories
{
    public class CategoryWriteRepository:WriteRepository<Category>,ICategoryWriteRepository
    {
        public CategoryWriteRepository(ProjectADbContext context):base(context)
        {

        }
    }
}
