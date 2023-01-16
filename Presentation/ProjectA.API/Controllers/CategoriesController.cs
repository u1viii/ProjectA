using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Application;
using ProjectA.Application.Features.Commands.Categories.CreateCategory;
using ProjectA.Application.Features.Queries.Categories.GetAllCategories;

namespace ProjectA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> Post(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
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
