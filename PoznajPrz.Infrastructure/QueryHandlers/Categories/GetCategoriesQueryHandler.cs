using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajPrz.Application.Queries.Categories.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly PoznajPrzContext _context;

        public GetCategoriesQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            => await (from c in _context.Categories
                      select new CategoryDto(c.PlaceCategoryId, c.Name))
            .ToListAsync();
    }
}
