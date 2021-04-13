using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Domain.Interfaces.Repositories
{
    public interface IPlaceRepository
    {
        public Task CreateAsync(Place place);
        public Task<Place> GetAsync(Guid placeId);
        public Task UpdateAsync(Place place);
        public Task DeleteAsync(Guid placeId);
    }
}
