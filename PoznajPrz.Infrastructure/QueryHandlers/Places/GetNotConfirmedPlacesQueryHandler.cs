using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajPrz.Application.Queries.Places.GetNotConfirmedPlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Places
{
    public class GetNotConfirmedPlacesQueryHandler : IRequestHandler<GetNotConfirmedPlacesQuery, List<PlaceDto>>
    {
        private readonly PoznajPrzContext _context;

        public GetNotConfirmedPlacesQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<List<PlaceDto>> Handle(GetNotConfirmedPlacesQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      where !p.IsConfirmed
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      join v in _context.Visits on p.PlaceId equals v.PlaceId into visit
                      from subv in visit.DefaultIfEmpty()
                      select new PlaceDto(p.PlaceId, p.Name, p.Description, p.Address, c.Name))
            .ToListAsync();
    }
}
