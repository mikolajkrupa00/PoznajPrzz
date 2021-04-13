using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajPrz.Application.Commands.Places.CreatePlace;
using PoznajPrz.Application.Commands.Places.DeletePlace;
using PoznajPrz.Application.Commands.Places.UpdatePlace;
using PoznajPrz.Application.Queries.Places.GetPlace;
using PoznajPrz.Application.Queries.Places.GetPlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPrz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getPlaces/{userId?}")]
        public async Task<IActionResult> GetPlaces([FromRoute]Guid? userId = null)
            => Ok(await _mediator.Send(new GetPlacesQuery
            {
                UserId = userId
            }));

        [HttpGet("{placeId}")]
        public async Task<IActionResult> GetPlace([FromRoute] Guid placeId)
            => Ok(await _mediator.Send(new GetPlaceQuery
            {
                PlaceId = placeId
            }));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePlace([FromBody] CreatePlaceCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePlace([FromBody] UpdatePlaceCommand command)
            => Ok(await _mediator.Send(command));

        [HttpDelete("{placeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlace([FromBody] DeletePlaceCommand command)
            => Ok(await _mediator.Send(command));
    }
}
