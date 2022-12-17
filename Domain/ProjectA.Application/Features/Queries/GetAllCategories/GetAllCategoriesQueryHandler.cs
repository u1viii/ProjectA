using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectA.Core.Entities;

namespace ProjectA.Application.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        readonly IUnitOfWorks _unitOfWorks;

        public GetAllCategoriesQueryHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Category> categories = _unitOfWorks.CategoryReadRepository.GetAll().Skip(request.Page * request.Take).Take(request.Take);
            return new GetAllCategoriesQueryResponse{ Categories=categories};
        }
    }
}
