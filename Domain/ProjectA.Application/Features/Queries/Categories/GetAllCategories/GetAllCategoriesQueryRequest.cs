using MediatR;

namespace ProjectA.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryRequest:IRequest<GetAllCategoriesQueryResponse>
    {
        //public Pagination? Pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Take { get; set; } = 5;
    }
}
