using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectA.Application;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.Categories;
using ProjectA.Application.Exceptions.CategoryExceptions;
using ProjectA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Persistance.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IUnitOfWorks _unitOfWorks;

        public CategoryService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public Task<bool> CreateAllAsync(IEnumerable<DTO_CreateCategory> createCategories)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(DTO_CreateCategory createCategory)
        {
            Category newCat = new Category
            {
                Name = createCategory.Name,
            };
            if (createCategory.ParentId != null)
            {
                if (await _unitOfWorks.CategoryReadRepository.GetByIdAsync(createCategory.ParentId) == null)
                {
                    throw new CategoryNotFoundException();
                }
                newCat.Parent = Guid.Parse(createCategory.ParentId);
            }
            bool result = await _unitOfWorks.CategoryWriteRepository.AddAsync(newCat);
            await _unitOfWorks.SaveChangesAsync();
            return result;
        }


        public Task<Category> GetByIdAsync(string id, bool isTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetSingleAsync(Expression<Func<Category, bool>> exp, bool isTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllAsync(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            bool result = _unitOfWorks.CategoryWriteRepository.Remove(id);
            await _unitOfWorks.SaveChangesAsync();
            return result;
        }

        public Task<bool> UpdateAsync(DTO_UpdateCategory updateCategory)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll(bool isTracking = false)
            => _unitOfWorks.CategoryReadRepository.GetAll();

        public IQueryable<Category> GetWhere(Expression<Func<Category, bool>> exp, bool isTracking = false)
            => _unitOfWorks.CategoryReadRepository.GetWhere(exp);
        public async Task<bool> ContainsAsync(Expression<Func<Category, bool>> exp)
        {
            return await _unitOfWorks.CategoryReadRepository.Table.AnyAsync(exp);
        }
    }
}
