using MediatR;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.Categories.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
    {
        ICategoryService _categoryService { get; }
        ICategoryReadRepository _categoryReadRepository { get; }

        public RemoveCategoryCommandHandler(ICategoryService categoryService, ICategoryReadRepository categoryReadRepository)
        {
            _categoryService = categoryService;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryService.RemoveAsync(request.Id);
            return new();
        }
    }
}
