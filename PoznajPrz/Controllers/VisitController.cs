using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajPrz.Application.Commands.Visits.CreateVisit;
using PoznajPrz.Application.Queries.Visits.GetPlaceStats;
using PoznajPrz.Application.Queries.Visits.GetStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajPrz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getStats/{placeId}/{days}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPlaceStats([FromRoute]Guid placeId, [FromRoute]int days)
            => Ok(await _mediator.Send(new GetPlaceStatsQuery
            {
                Days = days,
                PlaceId = placeId
            }));

        [HttpGet("getStats/{days}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStats(int days)
            => Ok(await _mediator.Send(new GetStatsQuery
            {
                Days = days
            }));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVisit([FromBody] CreateVisitCommand command)
            => Ok(await _mediator.Send(command));
    }
}
