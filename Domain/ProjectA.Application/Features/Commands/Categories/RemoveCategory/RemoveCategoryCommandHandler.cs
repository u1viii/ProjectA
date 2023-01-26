using MediatR;
using ProjectA.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.Categories.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        readonly ICategoryService _categoryService;

        public RemoveCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryService.RemoveAsync(request.Id);
            return new();
        }
    }
}
