using ProjectA.Application.DTOs.Categories;
using ProjectA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(DTO_CreateCategory createCategory);
        Task<bool> CreateAllAsync(IEnumerable<DTO_CreateCategory> createCategories);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> RemoveAllAsync(IEnumerable<string> ids);
        Task<bool> UpdateAsync(DTO_UpdateCategory updateCategory);
        IQueryable<Category> GetAll(bool isTracking = false);
        IQueryable<Category> GetWhere(Expression<Func<Category, bool>> exp, bool isTracking = false);
        Task<Category> GetByIdAsync(string id, bool isTracking = false);
        Task<Category> GetSingleAsync(Expression<Func<Category, bool>> exp, bool isTracking = false);
        Task<bool> ContainsAsync(Expression<Func<Category, bool>> exp);
    }
}
