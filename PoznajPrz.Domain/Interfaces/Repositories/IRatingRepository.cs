using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Domain.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task CreateAsync(Rating rating);
        Task DeleteAsync(Guid ratingId);
        Task<Rating> GetAsync(Guid ratingId);
        Task UpdateAsync(Rating rating);
    }
}
