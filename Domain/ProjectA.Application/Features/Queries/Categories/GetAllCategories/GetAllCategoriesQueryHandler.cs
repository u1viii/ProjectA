using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Core.Entities;

namespace ProjectA.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Category> categories = _categoryService.GetAll().Skip(request.Page * request.Take).Take(request.Take).Include(c=>c.Children).ThenInclude(c=>c.Children);
            return new GetAllCategoriesQueryResponse{ Categories=categories};
        }
    }
}
