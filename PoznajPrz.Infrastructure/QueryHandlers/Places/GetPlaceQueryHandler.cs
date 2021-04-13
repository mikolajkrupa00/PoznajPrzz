using MediatR;
using PoznajPrz.Application.Queries.Places.GetPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Places
{
    public class GetPlaceQueryHandler : IRequestHandler<GetPlaceQuery, PlaceDto>
    {
        private readonly PoznajPrzContext _context;

        public GetPlaceQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<PlaceDto> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      where p.PlaceId == request.PlaceId
                      select new PlaceDto(p.PlaceId, p.Latitude, p.Attitude, p.Name, p.Description,
                      p.Address, c.Name))
            .FirstAsync();
    }
}
