﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajPrz.Application.Queries.Visits.GetStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Visits
{
    public class GetStatsQueryHandler : IRequestHandler<GetStatsQuery, List<StatsDto>>
    {
        private readonly PoznajPrzContext _context;

        public GetStatsQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<List<StatsDto>> Handle(GetStatsQuery request, CancellationToken cancellationToken)
            => await (from v in _context.Visits
                      where v.VisitDate > DateTime.UtcNow.AddDays(-request.Days)
                      join p in _context.Places on v.PlaceId equals p.PlaceId into place
                      from pp in place.DefaultIfEmpty()
                      group v by new { pp.PlaceId, pp.Name, pp.Address, pp.Description }  into visits
                      select new StatsDto(visits.Key.PlaceId, visits.Count(), visits.Key.Name, visits.Key.Address, visits.Key.Description))
            .ToListAsync();

            //var x = await(from p in _context.Places
            //      join v in _context.Visits on p.PlaceId equals v.PlaceId into visits
            //      join r in _context.Ratings on p.PlaceId equals r.PlaceId into ratings
            //      let numv = visits.ToArray().Count()
            //      let numr = ratings.ToArray().Count()
            //      let mr = ratings.Sum(x => x.Value) / ratings.ToArray().Count()
            //      select new { numOfVisits = numv, numOfRatings = numr, averangeRating = mr })
            //       .ToListAsync();
            //return new List<StatsDto>();
    }
}
