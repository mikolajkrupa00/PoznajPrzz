using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajPrz.Application.Commands.Categories.CreateCategory;
using PoznajPrz.Application.Commands.Categories.DeleteCategory;
using PoznajPrz.Application.Queries.Categories.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPrz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
            => Ok(await _mediator.Send(command));

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid categoryId)
            => Ok(await _mediator.Send(new DeleteCategoryCommand
            {
                CategoryId = categoryId
            }));

        [HttpGet]
        public async Task<IActionResult> GetCategories()
            => Ok(await _mediator.Send(new GetCategoriesQuery { }));
    }
}
