﻿using Microsoft.EntityFrameworkCore;
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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly PoznajPrzContext _context;

        public PlaceRepository(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Place place)
        {
            await _context.AddAsync(DbPlace.Create(place));
            await _context.SaveChangesAsync();
        }

        public async Task<Place> GetAsync(Guid placeId)
            => await (from p in _context.Places
                      where p.PlaceId == placeId
                      select new Place(p.PlaceId, p.Latitude, p.Attitude, p.Name, p.Description, p.Address, p.CategoryId, p.IsConfirmed))
                      .FirstAsync();

        public async Task UpdateAsync(Place place)
        {
            var _place = await (from p in _context.Places
                                where p.PlaceId == place.PlaceId
                                select p).FirstAsync();
            _place.Latitude = place.Latitude;
            _place.Name = place.Name;
            _place.Address = place.Address;
            _place.Attitude = place.Attitude;
            _place.CategoryId = place.CategoryId;
            _place.IsConfirmed = place.IsConfirmed;
            _place.Description = place.Description;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid placeId)
        {
            var place = await (from p in _context.Places
                               where p.PlaceId == placeId
                               select p).FirstAsync();
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }
    }
}
