using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Application;
using ProjectA.Application.DTOs.Categories;
using ProjectA.Application.Features.Queries.GetAllCategories;
using ProjectA.Application.Repositories;
using ProjectA.Application.RequestParameters;
using ProjectA.Core.Entities;

namespace ProjectA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        readonly IUnitOfWorks _unitOfWorks;
        readonly IMediator _mediator;
        public CategoriesController(IUnitOfWorks unitOfWorks, IMediator mediator)
        {
            _unitOfWorks = unitOfWorks;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetAllCategoriesQueryRequest request)
        {
            return Ok(_mediator.Send(request));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _unitOfWorks.CategoryReadRepository.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(DTO_CreateCategory category)
        {
            
            Category newCat = new Category
            {
                Name = category.Name,
            };
            if (category.ParentId != null &&
                await _unitOfWorks.CategoryReadRepository.GetByIdAsync(category.ParentId) != null)
            {
                newCat.Parent = Guid.Parse(category.ParentId);
            }
            await _unitOfWorks.CategoryWriteRepository.AddAsync(newCat);
            await _unitOfWorks.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var cat = await _unitOfWorks.CategoryReadRepository.GetByIdAsync(Id);
            if (cat != null) _unitOfWorks.CategoryWriteRepository.Remove(cat);
            await _unitOfWorks.SaveChangesAsync();
            return Ok();
        }
    }
}
