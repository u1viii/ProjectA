using ProjectA.Core.Entities;

namespace ProjectA.Application.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public IQueryable<Category> Categories { get; set; }
    }
}
