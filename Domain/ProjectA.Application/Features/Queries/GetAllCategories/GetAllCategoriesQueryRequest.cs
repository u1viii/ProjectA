using MediatR;
using ProjectA.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest:IRequest<GetAllCategoriesQueryResponse>
    {
        //public Pagination? Pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Take { get; set; } = 5;
    }
}
