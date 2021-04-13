using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajPrz.Application.Queries.Places.GetPlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Places
{
    public class GetPlacesQueryHandler : IRequestHandler<GetPlacesQuery, List<PlaceDto>>
    {
        private readonly PoznajPrzContext _context;

        public GetPlacesQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<List<PlaceDto>> Handle(GetPlacesQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      join v in _context.Visits.Where(x => x.VisitedById == request.UserId) on p.PlaceId equals v.PlaceId into visit
                      from subv in visit.DefaultIfEmpty()
                      select new PlaceDto(p.PlaceId, p.Latitude, p.Attitude, p.Name, p.Description, p.Address, c.Name, 
                          subv != null))
            .ToListAsync();
    }
}
