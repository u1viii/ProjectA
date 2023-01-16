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
        Task<bool> CreateCategoryAsync(DTO_CreateCategory createCategory);
        Task<bool> CreateAllCategoryAsync(IEnumerable<DTO_CreateCategory> createCategories);
        Task<bool> RemoveCategoryAsync(string id);
        Task<bool> RemoveAllCategoriesAsync(IEnumerable<string> ids);
        Task<bool> UpdateAsync(DTO_UpdateCategory updateCategory);
        IQueryable<Category> GetAll();
        IQueryable<Category> GetWhere(Expression<Func<Category, bool>> exp);
        Task<Category> GetByIdAsync(string id);
        Task<Category> GetSingleAsync(Expression<Func<Category, bool>> exp);
    }
}
