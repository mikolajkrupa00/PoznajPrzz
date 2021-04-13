using Microsoft.EntityFrameworkCore;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using PoznajPrz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly PoznajPrzContext _context;

        public VisitRepository(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Visit place)
        {
            await _context.Visits.AddAsync(DbVisit.Create(place));
            await _context.SaveChangesAsync();
        }

        public async Task<Visit> GetAsync(Guid placeId, Guid userId)
            => await (from v in _context.Visits
                      where v.PlaceId == placeId && v.VisitedById == userId
                      select new Visit(v.VisitId, v.VisitDate, v.VisitedById, v.PlaceId))
            .FirstAsync();

        public async Task UpdateAsync(Visit place)
        {
            var _place = await (from v in _context.Visits
                                where v.VisitId == place.VisitId
                                select v).FirstAsync();
            _place.VisitDate = place.VisitDate;
        }
    }
}
